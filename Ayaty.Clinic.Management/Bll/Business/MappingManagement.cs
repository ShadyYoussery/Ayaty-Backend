using System.Linq;
using Ayaty.Context.Models;
using Ayaty.Clinic.Management.Bll.Interfaces;
using Ayaty.Clinic.Management.Dtos.Clinic;
using Ayaty.Clinic.Management.Dtos.ClinicComminicationWay;
using Ayaty.Clinic.Management.Dtos.ClinicLanguage;

namespace Ayaty.Clinic.Management.Bll.Business
{
    /// <inheritdoc />
    /// <summary>
    /// Mapping Management
    /// </summary>
    public class MappingManagement : IMapping
    {
        #region Clinic

        /// <inheritdoc />
        public Dtos.Clinic.ClinicLanguageDto MapClinicLanguageToDto(ClinicLanguage model)
        {
            if (model == null) return null;
            return new Dtos.Clinic.ClinicLanguageDto
            {
                Id = model.ClinicId,
                Latitude = model.Clinic.Latitude,
                Logo = model.Clinic.Logo,
                Longitude = model.Clinic.Longitude,
                Name = model.Name
            };
        }


        /// <inheritdoc />
        public ClinicLanguageFullDto MapClinicLanguageToFullDto(ClinicLanguage model)
        {
            if (model == null) return null;
            return new ClinicLanguageFullDto(MapClinicLanguageToDto(model))
            {
                ClinicComminicationWays =model.Clinic.ClinicComminicationWay?.Select(MapToDto),
               ClinicLanguages = model.Clinic.ClinicLanguage?.Select(MapToDto)
            };
        }

        /// <inheritdoc />
        public ClinicDto MapToFullDto(Ayaty.Context.Models.Clinic model)
        {
            if (model == null) return null;
            return new ClinicDto
            {
                Id = model.Id,
                Latitude = model.Latitude,
                Longitude = model.Longitude,
                CityId = model.CityId,
                ClinicComminicationWays = model.ClinicComminicationWay?.Select(MapToDto),
                ClinicLanguages = model.ClinicLanguage?.Select(MapToDto)
            };
        }


        /// <inheritdoc />
        public Ayaty.Context.Models.Clinic MapToModel(ClinicDto dto)
        {
            if (dto == null) return null;
            return new Ayaty.Context.Models.Clinic
            {
                Id = dto.Id,
                Longitude = dto.Longitude,
                Latitude = dto.Latitude,
                CityId = dto.CityId,
                ClinicComminicationWay = dto.ClinicComminicationWays?.Select(MapToModel).ToList(),
                ClinicLanguage = dto.ClinicLanguages?.Select(MapToModel).ToList()
            };
        }

        #endregion Clinic

        #region ClinicComminicationWay

        /// <inheritdoc />
        public ClinicComminicationWayDto MapToDto(ClinicComminicationWay model)
        {
            if (model == null) return null;
            return new ClinicComminicationWayDto
            {
                CommincationWayId = model.CommincationWayId,
                Value = model.Value
            };
        }

        /// <inheritdoc />
        public ClinicComminicationWay MapToModel(ClinicComminicationWayDto dto)
        {
            if (dto == null) return null;
            return new ClinicComminicationWay
            {
                CommincationWayId = dto.CommincationWayId,
                Value = dto.Value
            };
        }

        #endregion ClinicComminicationWay

        #region ClinicLanguage

        /// <inheritdoc />
        public Dtos.ClinicLanguage.ClinicLanguageDto MapToDto(ClinicLanguage model)
        {
            if (model == null) return null;
            return new Dtos.ClinicLanguage.ClinicLanguageDto
            {
                LanguageId = model.LanguageId,
                Name = model.Name
            };
        }

        /// <inheritdoc />
        public ClinicLanguage MapToModel(Dtos.ClinicLanguage.ClinicLanguageDto dto)
        {
            if (dto == null) return null;
            return new ClinicLanguage
            {
                LanguageId = dto.LanguageId,
                Name = dto.Name
            };
        }

        #endregion ClinicLanguage
    }
}