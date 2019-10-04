using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ayaty.Context.Enums;
using Ayaty.Context.Models;
using Ayaty.Clinic.Management.Bll.Interfaces;
using Ayaty.Clinic.Management.Dtos.Clinic;
using Ayaty.Clinic.Management.Enums;
using Ayaty.Clinic.Management.Helper;
using Microsoft.EntityFrameworkCore;
using Ayaty.Shared.Dto;
using Ayaty.Shared.Helper;

namespace Ayaty.Clinic.Management.Bll.Business
{
    /// <inheritdoc />
    public class ClinicManagement : IClinic
    {
        #region Feilds

        private readonly AyatyContext _db;
        private readonly IMapping _mapping;

        #endregion Feilds

        #region Ctor

        /// <inheritdoc />
        public ClinicManagement(AyatyContext db, IMapping mapping)
        {
            _db = db;
            _mapping = mapping;
        }

        #endregion Ctor

        #region Public Methods

        /// <inheritdoc />
        public async Task<BllResponse<ClinicDto>> Add(ClinicDto dto)
        {
            var validation = await ValidateClinic(dto);
            if (validation != null) return validation;

            var dbClinic = _mapping.MapToModel(dto);
            await _db.Clinic.AddAsync(dbClinic);
            if (await _db.SaveChangesAsync() <= 0) return new BllResponse<ClinicDto>(ErrorCode.ItemNotSaved);
            dto.Id = dbClinic.Id;
           return new BllResponse<ClinicDto>(dto);
        }

        public void ChangeLogo()
        {
            throw new NotImplementedException();
        }

        #endregion Public Methods

        #region private Methods
        
        /// <summary>
        /// validate if any duplication with Db in Case of add or edit
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        private async Task<BllResponse<ClinicDto>> ValidateClinic(ClinicDto dto)
        {
            var languageIds = (int[]) Enum.GetValues(typeof(LanguageEnum));
            if (dto.ClinicLanguages.Count() != languageIds.Length)
                return new BllResponse<ClinicDto>(ErrorCode.ClinicMissingLanguages);
            if (dto.ClinicLanguages.Any(t => !languageIds.Contains(t.LanguageId)))
                return new BllResponse<ClinicDto>(ErrorCode.ClinicInvalidLanguage);
            var comminicationWayIds = (int[])Enum.GetValues(typeof(ComminicationWayEnum));
            if (dto.ClinicComminicationWays.Any(t => !comminicationWayIds.Contains(t.CommincationWayId)))
                return new BllResponse<ClinicDto>(ErrorCode.ClinicInvalidCommincationWay);
            List<ValidateDeferred<bool>> validateDeferreds = ValidateDeferredsForLanguage(dto);

            validateDeferreds.AddRange(ValidateDeferredsForComminicationWay(dto));

            foreach (var validate in validateDeferreds)
                if (await validate.Func(validate.FutureValue))
                    return new BllResponse<ClinicDto>(validate.ErrorCode);

            return null;
        }

        private List<ValidateDeferred<bool>> ValidateDeferredsForLanguage(ClinicDto dto)
        {
            return dto.ClinicLanguages.Select(clinicLanguage => new ValidateDeferred<bool>
            {
                //check if any name with language duplicated in Db
                FutureValue = _db.ClinicLanguage.AnyDeferred(t =>
                    t.Name.ToLower() == clinicLanguage.Name.ToLower() && t.LanguageId == clinicLanguage.LanguageId
                    //if add skip this condition, in case of edit check duplicated with other Clinics
                    && (dto.Id == 0 || dto.Id != t.ClinicId)),
                ErrorCode = ErrorCode.ClientDuplicatename,
                Func = async futureValue => await futureValue.ValueAsync()
            }).ToList();
        }

        private List<ValidateDeferred<bool>> ValidateDeferredsForComminicationWay(ClinicDto dto)
        {
            return dto.ClinicComminicationWays.Select(comminicationWay => new ValidateDeferred<bool>
            {
                //check if any value duplicated in Db
                FutureValue = _db.ClinicComminicationWay.AnyDeferred(t =>
                    t.Value.ToLower() == comminicationWay.Value.ToLower()
                    //if add skip this condition, in case of edit check duplicated with other Clinics
                    && (dto.Id == 0 || dto.Id != t.ClinicId)),
                ErrorCode = ErrorCode.ClientDuplicatename,
                Func = async futureValue => await futureValue.ValueAsync()
            }).ToList();
        }
        #endregion private Methods



    }
}