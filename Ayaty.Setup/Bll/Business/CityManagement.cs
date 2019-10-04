using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ayaty.Context.Models;
using Microsoft.EntityFrameworkCore;
using Ayaty.Setup.Bll.Interfaces;
using Ayaty.Setup.Dtos.City;
using Ayaty.Setup.Enums;
using Shared.Bll.Interfaces;
using Shared.Dto;
using Shared.Dto.Paging;
using Shared.Helper;

namespace Ayaty.Setup.Bll.Business
{
    public class CityManagement : ICity
    {
        #region Feilds

        private readonly AyatyContext _db;
        private readonly IMapping _mapping;
        private readonly IAyatyHelper _ayatyHelper;
        private readonly IPaging _paging;

        #endregion Feilds

        #region Ctor

        public CityManagement(AyatyContext db, IMapping mapping, IAyatyHelper ayatyHelper, IPaging paging)
        {
            _db = db;
            _mapping = mapping;
            _ayatyHelper = ayatyHelper;
            _paging = paging;
        }

        #endregion Ctor

        #region Public Methods

        /// <inheritdoc />
        public async Task<BllResponse<CityAddEditDto>> Add(CityAddEditDto dto)
        {
            var validation = await ValidateAddEdit(dto);
            if (validation != null) return validation;

            var dbCity = _mapping.MapToModel(dto);
            await _db.City.AddAsync(dbCity);
            if (await _db.SaveChangesAsync() <= 0) return new BllResponse<CityAddEditDto>(ErrorCode.ItemNotSaved);
            dto.Id = dbCity.Id;
            return new BllResponse<CityAddEditDto>(dto);
        }

        /// <inheritdoc />
        public async Task<BllResponse<CityAddEditDto>> Edit(CityAddEditDto dto) 
        {
            var validation = await ValidateAddEdit(dto);
            if (validation != null) return validation;
            //remove old language and then insert with new values
            var languages = await _db.CityLanguage.Where(t => t.CityId == dto.Id).ToListAsync();
            _db.CityLanguage.RemoveRange(languages);

            var dbCity = _mapping.MapToModel(dto);
            _db.Update(dbCity);
            if (await _db.SaveChangesAsync() <= 0) return new BllResponse<CityAddEditDto>(ErrorCode.ItemNotSaved);
            dto.Id = dbCity.Id;
            return new BllResponse<CityAddEditDto>(dto);
        }

        /// <inheritdoc />
        public async Task<BllResponse<PageList<CityDto>>> List(CitySearchDto dto)
        {
            IQueryable<CityLanguage> data = _db.CityLanguage.WhereByLanguage();
            if (!string.IsNullOrEmpty(dto.Name))
                data = data.Where(t => t.Name.ToLower().Contains(dto.Name.ToLower()));
            PageList<CityDto> list = await _paging.CreateAsync(data, dto, _mapping.MapLanguageToDto);
            return new BllResponse<PageList<CityDto>>(list);
        }

        /// <inheritdoc />
        public async Task<BllResponse<CityAddEditDto>> GetById(int id)
        {
            var dbCity = await _db.City.Where(t => t.Id == id).Include(t => t.CityLanguage).FirstOrDefaultAsync();
            if (dbCity == null) return new BllResponse<CityAddEditDto>(ErrorCode.CityNotFound);
            var dto = _mapping.MapToDto(dbCity);
            return new BllResponse<CityAddEditDto>(dto);
        }

        /// <inheritdoc />
        public async Task<BllResponse<bool>> Delete(int id)
        {
            var dbCity = await _db.City.Where(t => t.Id == id).Include(t => t.Clinic)
                .Include(t => t.CityLanguage).FirstOrDefaultAsync();
            if (dbCity == null) return new BllResponse<bool>(ErrorCode.CityNotFound);
            if (dbCity.Clinic.Any()) return new BllResponse<bool>(ErrorCode.CityRelatedWithClinic);
            _db.CityLanguage.RemoveRange(dbCity.CityLanguage);
            _db.City.Remove(dbCity);
            return await _db.SaveChangesAsync() <= 0 ? new BllResponse<bool>(ErrorCode.ItemNotSaved) : new BllResponse<bool>(true);
        }

        #endregion Public Methods

        #region private Methods

        private async Task<BllResponse<CityAddEditDto>> ValidateAddEdit(CityAddEditDto dto)
        {
            var validateLanguageCount =
                _ayatyHelper.ValidateLanguageCount<CityAddEditDto>(dto.CityLanguages, ErrorCode.CityMissingLanguages,
                    ErrorCode.CityInvalidLanguage);
            if (validateLanguageCount != null) return validateLanguageCount;
            
            var validateDeferreds = ValidateDeferredsForLanguage(dto);
            validateDeferreds.Insert(0, new ValidateDeferred<bool>
            {
                ErrorCode = ErrorCode.CityStateNotFound,
                FutureValue = _db.State.AnyDeferred(t => t.Id == dto.StateId),
                Func = async futureValue => !await futureValue.ValueAsync()
            });
            if (dto.Id > 0)
                validateDeferreds.Insert(0, new ValidateDeferred<bool>
                {
                    ErrorCode = ErrorCode.CityNotFound,
                    FutureValue = _db.City.AnyDeferred(t => t.Id == dto.Id),
                    Func = async futureValue => !await futureValue.ValueAsync()
                });

            foreach (var validate in validateDeferreds)
                if (await validate.Func(validate.FutureValue))
                    return new BllResponse<CityAddEditDto>(validate.ErrorCode);

            return null;
        }

        private List<ValidateDeferred<bool>> ValidateDeferredsForLanguage(CityAddEditDto dto)
        {
            return dto.CityLanguages.Select(cityLanguage => new ValidateDeferred<bool>
            {
                //check if any name with language duplicated in Db
                FutureValue = _db.CityLanguage.AnyDeferred(t =>
                    t.Name.ToLower() == cityLanguage.Name.ToLower() && t.LanguageId == cityLanguage.LanguageId
                    //if add skip this condition, in case of edit check duplicated with other Citys
                    && (dto.Id == 0 || dto.Id != t.CityId)),
                ErrorCode = ErrorCode.CityDuplicatename,
                Func = async futureValue => await futureValue.ValueAsync()
            }).ToList();
        }

        #endregion private Methods


    }
}