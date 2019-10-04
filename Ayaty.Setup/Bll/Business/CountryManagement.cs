using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ayaty.Context.Interfaces;
using Ayaty.Context.Models;
using Microsoft.EntityFrameworkCore;
using Ayaty.Setup.Bll.Interfaces;
using Ayaty.Setup.Dtos.Country;
using Ayaty.Setup.Enums;
using Shared.Bll.Interfaces;
using Shared.Dto;
using Shared.Dto.Paging;
using Shared.Helper;

namespace Ayaty.Setup.Bll.Business
{
    public class CountryManagement : ICountry
    {
        #region Feilds

        private readonly AyatyContext _db;
        private readonly IMapping _mapping;
        private readonly IAyatyHelper _ayatyHelper;
        private readonly IPaging _paging;

        #endregion Feilds

        #region Ctor

        public CountryManagement(AyatyContext db, IMapping mapping, IAyatyHelper ayatyHelper, IPaging paging)
        {
            _db = db;
            _mapping = mapping;
            _ayatyHelper = ayatyHelper;
            _paging = paging;
        }

        #endregion Ctor

        #region Public Methods

        /// <inheritdoc />
        public async Task<BllResponse<CountryAddEditDto>> Add(CountryAddEditDto dto)
        {
            var validation = await ValidateAddEdit(dto);
            if (validation != null) return validation;

            var dbCountry = _mapping.MapToModel(dto);
            await _db.Country.AddAsync(dbCountry);
            if (await _db.SaveChangesAsync() <= 0) return new BllResponse<CountryAddEditDto>(ErrorCode.ItemNotSaved);
            dto.Id = dbCountry.Id;
            return new BllResponse<CountryAddEditDto>(dto);
        }

        /// <inheritdoc />
        public async Task<BllResponse<CountryAddEditDto>> Edit(CountryAddEditDto dto) 
        {
            var validation = await ValidateAddEdit(dto);
            if (validation != null) return validation;
            //remove old language and then insert with new values
            var languages = await _db.CountryLanguage.Where(t => t.CountryId == dto.Id).ToListAsync();
            _db.CountryLanguage.RemoveRange(languages);

            var dbCountry = _mapping.MapToModel(dto);
            _db.Update(dbCountry);
            if (await _db.SaveChangesAsync() <= 0) return new BllResponse<CountryAddEditDto>(ErrorCode.ItemNotSaved);
            dto.Id = dbCountry.Id;
            return new BllResponse<CountryAddEditDto>(dto);
        }

        /// <inheritdoc />
        public async Task<BllResponse<PageList<CountryDto>>> List(CountrySearchDto dto)
        {
            IQueryable<CountryLanguage> data = _db.CountryLanguage.WhereByLanguage();
            if (!string.IsNullOrEmpty(dto.Name))
                data = data.Where(t => t.Name.ToLower().Contains(dto.Name.ToLower()));
            PageList<CountryDto> list = await _paging.CreateAsync(data, dto, _mapping.MapLanguageToDto);
            return new BllResponse<PageList<CountryDto>>(list);
        }

        /// <inheritdoc />
        public async Task<BllResponse<CountryAddEditDto>> GetById(int id)
        {
            var dbCountry = await _db.Country.Where(t => t.Id == id).Include(t => t.CountryLanguage).FirstOrDefaultAsync();
            if (dbCountry == null) return new BllResponse<CountryAddEditDto>(ErrorCode.CountryNotFound);
            var dto = _mapping.MapToDto(dbCountry);
            return new BllResponse<CountryAddEditDto>(dto);
        }

        /// <inheritdoc />
        public async Task<BllResponse<bool>> Delete(int id)
        {
            var dbCountry = await _db.Country.Where(t => t.Id == id).Include(t => t.State)
                .Include(t => t.CountryLanguage).FirstOrDefaultAsync();
            if(dbCountry==null) return new BllResponse<bool>(ErrorCode.CountryNotFound);
            if(dbCountry.State.Any()) return new BllResponse<bool>(ErrorCode.CountryRelatedWithState);
            _db.CountryLanguage.RemoveRange(dbCountry.CountryLanguage);
            _db.Country.Remove(dbCountry);
            return await _db.SaveChangesAsync() <= 0 ? new BllResponse<bool>(ErrorCode.ItemNotSaved) : new BllResponse<bool>(true);
        }

        #endregion Public Methods

        #region private Methods

        private async Task<BllResponse<CountryAddEditDto>> ValidateAddEdit(CountryAddEditDto dto)
        {
            var validateLanguageCount =
                _ayatyHelper.ValidateLanguageCount<CountryAddEditDto>(dto.CountryLanguages, ErrorCode.CountryMissingLanguages,
                    ErrorCode.CountryInvalidLanguage);
            if (validateLanguageCount != null) return validateLanguageCount;
            
            var validateDeferreds = ValidateDeferredsForLanguage(dto);
            if (dto.Id > 0)
                validateDeferreds.Insert(0, new ValidateDeferred<bool>
                {
                    ErrorCode = ErrorCode.CountryNotFound,
                    FutureValue = _db.Country.AnyDeferred(t => t.Id == dto.Id),
                    Func = async futureValue => !await futureValue.ValueAsync()
                });

            foreach (var validate in validateDeferreds)
                if (await validate.Func(validate.FutureValue))
                    return new BllResponse<CountryAddEditDto>(validate.ErrorCode);

            return null;
        }

        private List<ValidateDeferred<bool>> ValidateDeferredsForLanguage(CountryAddEditDto dto)
        {
            return dto.CountryLanguages.Select(countryLanguage => new ValidateDeferred<bool>
            {
                //check if any name with language duplicated in Db
                FutureValue = _db.CountryLanguage.AnyDeferred(t =>
                    t.Name.ToLower() == countryLanguage.Name.ToLower() && t.LanguageId == countryLanguage.LanguageId
                    //if add skip this condition, in case of edit check duplicated with other Countrys
                    && (dto.Id == 0 || dto.Id != t.CountryId)),
                ErrorCode = ErrorCode.CountryDuplicatename,
                Func = async futureValue => await futureValue.ValueAsync()
            }).ToList();
        }

        #endregion private Methods


    }
}