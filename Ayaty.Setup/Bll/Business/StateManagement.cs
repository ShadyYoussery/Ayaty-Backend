using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ayaty.Context.Models;
using Microsoft.EntityFrameworkCore;
using Ayaty.Setup.Bll.Interfaces;
using Ayaty.Setup.Dtos.State;
using Ayaty.Setup.Enums;
using Shared.Bll.Interfaces;
using Shared.Dto;
using Shared.Dto.Paging;
using Shared.Helper;

namespace Ayaty.Setup.Bll.Business
{
    public class StateManagement : IState
    {
        #region Feilds

        private readonly AyatyContext _db;
        private readonly IMapping _mapping;
        private readonly IAyatyHelper _ayatyHelper;
        private readonly IPaging _paging;

        #endregion Feilds

        #region Ctor

        public StateManagement(AyatyContext db, IMapping mapping, IAyatyHelper ayatyHelper, IPaging paging)
        {
            _db = db;
            _mapping = mapping;
            _ayatyHelper = ayatyHelper;
            _paging = paging;
        }

        #endregion Ctor

        #region Public Methods

        /// <inheritdoc />
        public async Task<BllResponse<StateAddEditDto>> Add(StateAddEditDto dto)
        {
            var validation = await ValidateAddEdit(dto);
            if (validation != null) return validation;

            var dbState = _mapping.MapToModel(dto);
            await _db.State.AddAsync(dbState);
            if (await _db.SaveChangesAsync() <= 0) return new BllResponse<StateAddEditDto>(ErrorCode.ItemNotSaved);
            dto.Id = dbState.Id;
            return new BllResponse<StateAddEditDto>(dto);
        }

        /// <inheritdoc />
        public async Task<BllResponse<StateAddEditDto>> Edit(StateAddEditDto dto) 
        {
            var validation = await ValidateAddEdit(dto);
            if (validation != null) return validation;
            //remove old language and then insert with new values
            var languages = await _db.StateLanguage.Where(t => t.StateId == dto.Id).ToListAsync();
            _db.StateLanguage.RemoveRange(languages);

            var dbState = _mapping.MapToModel(dto);
            _db.Update(dbState);
            if (await _db.SaveChangesAsync() <= 0) return new BllResponse<StateAddEditDto>(ErrorCode.ItemNotSaved);
            dto.Id = dbState.Id;
            return new BllResponse<StateAddEditDto>(dto);
        }

        /// <inheritdoc />
        public async Task<BllResponse<PageList<StateDto>>> List(StateSearchDto dto)
        {
            IQueryable<StateLanguage> data = _db.StateLanguage.WhereByLanguage();
            if (!string.IsNullOrEmpty(dto.Name))
                data = data.Where(t => t.Name.ToLower().Contains(dto.Name.ToLower()));
            PageList<StateDto> list = await _paging.CreateAsync(data, dto, _mapping.MapLanguageToDto);
            return new BllResponse<PageList<StateDto>>(list);
        }

        /// <inheritdoc />
        public async Task<BllResponse<StateAddEditDto>> GetById(int id)
        {
            var dbState = await _db.State.Where(t => t.Id == id).Include(t => t.StateLanguage).FirstOrDefaultAsync();
            if (dbState == null) return new BllResponse<StateAddEditDto>(ErrorCode.StateNotFound);
            var dto = _mapping.MapToDto(dbState);
            return new BllResponse<StateAddEditDto>(dto);
        }

        /// <inheritdoc />
        public async Task<BllResponse<bool>> Delete(int id)
        {
            var dbState = await _db.State.Where(t => t.Id == id).Include(t => t.City)
                .Include(t => t.StateLanguage).FirstOrDefaultAsync();
            if (dbState == null) return new BllResponse<bool>(ErrorCode.StateNotFound);
            if (dbState.City.Any()) return new BllResponse<bool>(ErrorCode.StateRelatedWithCity);
            _db.StateLanguage.RemoveRange(dbState.StateLanguage);
            _db.State.Remove(dbState);
            return await _db.SaveChangesAsync() <= 0 ? new BllResponse<bool>(ErrorCode.ItemNotSaved) : new BllResponse<bool>(true);
        }

        #endregion Public Methods

        #region private Methods

        private async Task<BllResponse<StateAddEditDto>> ValidateAddEdit(StateAddEditDto dto)
        {
            var validateLanguageCount =
                _ayatyHelper.ValidateLanguageCount<StateAddEditDto>(dto.StateLanguages, ErrorCode.StateMissingLanguages,
                    ErrorCode.StateInvalidLanguage);
            if (validateLanguageCount != null) return validateLanguageCount;
            
            var validateDeferreds = ValidateDeferredsForLanguage(dto);
            validateDeferreds.Insert(0, new ValidateDeferred<bool>
            {
                ErrorCode = ErrorCode.StateCountryNotFound,
                FutureValue = _db.Country.AnyDeferred(t => t.Id == dto.CountryId),
                Func = async futureValue => !await futureValue.ValueAsync()
            });
            if (dto.Id > 0)
                validateDeferreds.Insert(0, new ValidateDeferred<bool>
                {
                    ErrorCode = ErrorCode.StateNotFound,
                    FutureValue = _db.State.AnyDeferred(t => t.Id == dto.Id),
                    Func = async futureValue => !await futureValue.ValueAsync()
                });

            foreach (var validate in validateDeferreds)
                if (await validate.Func(validate.FutureValue))
                    return new BllResponse<StateAddEditDto>(validate.ErrorCode);

            return null;
        }

        private List<ValidateDeferred<bool>> ValidateDeferredsForLanguage(StateAddEditDto dto)
        {
            return dto.StateLanguages.Select(stateLanguage => new ValidateDeferred<bool>
            {
                //check if any name with language duplicated in Db
                FutureValue = _db.StateLanguage.AnyDeferred(t =>
                    t.Name.ToLower() == stateLanguage.Name.ToLower() && t.LanguageId == stateLanguage.LanguageId
                    //if add skip this condition, in case of edit check duplicated with other States
                    && (dto.Id == 0 || dto.Id != t.StateId)),
                ErrorCode = ErrorCode.StateDuplicatename,
                Func = async futureValue => await futureValue.ValueAsync()
            }).ToList();
        }

        #endregion private Methods


    }
}