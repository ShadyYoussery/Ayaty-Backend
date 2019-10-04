using System.Linq;
using Ayaty.Context.Models;
using Ayaty.Setup.Bll.Interfaces;
using Ayaty.Setup.Dtos.City;
using Ayaty.Setup.Dtos.City.CityLanguage;
using Ayaty.Setup.Dtos.Country;
using Ayaty.Setup.Dtos.Country.CountryLanguage;
using Ayaty.Setup.Dtos.State;
using Ayaty.Setup.Dtos.State.StateLanguage;

namespace Ayaty.Setup.Bll.Business
{
    /// <inheritdoc />
    /// <summary>
    /// Mapping Management
    /// </summary>
    public class MappingManagement : IMapping
    {
        #region Country

        /// <inheritdoc />
        public Country MapToModel(CountryAddEditDto dto)
        {
            if (dto == null) return null;
            return new Country
            {
                Id = dto.Id,
                CountryLanguage = dto.CountryLanguages?.Select(MapToModel).ToList()
            };
        }

        /// <inheritdoc />
        public CountryLanguage MapToModel(CountryLanguageDto dto)
        {
            if (dto == null) return null;
            return new CountryLanguage
            {
                LanguageId = dto.LanguageId,
                Name = dto.Name,
            };
        }

        /// <inheritdoc />
        public CountryDto MapLanguageToDto(CountryLanguage model)
        {
            if (model == null) return null;
            return new CountryDto
            {
                Id = model.CountryId,
                Name = model.Name
            };
        }

        public CountryLanguageDto MapToDto(CountryLanguage model)
        {
            if (model == null) return null;
            return new CountryLanguageDto
            {
                LanguageId = model.LanguageId,
                Name = model.Name
            };
        }


        public CountryAddEditDto MapToDto(Country model)
        {
            if (model == null) return null;
            return new CountryAddEditDto
            {
                Id = model.Id,
                CountryLanguages = model.CountryLanguage?.Select(MapToDto)
            };
        }
        #endregion Country

        #region State

        /// <inheritdoc />
        public State MapToModel(StateAddEditDto dto)
        {
            if (dto == null) return null;
            return new State
            {
                CountryId = dto.CountryId,
                StateLanguage = dto.StateLanguages?.Select(MapToModel).ToList()
            };
        }

        /// <inheritdoc />
        public StateLanguage MapToModel(StateLanguageDto dto)
        {
            if (dto == null) return null;
            return new StateLanguage
            {
                LanguageId = dto.LanguageId,
                Name = dto.Name
            };
        }

        public StateDto MapLanguageToDto(StateLanguage model)
        {
            if (model == null) return null;
            return new StateDto
            {
                Id = model.StateId,
                Name = model.Name
            };
        }

        public StateAddEditDto MapToDto(State model)
        {
            if (model == null) return null;
            return new StateAddEditDto
            {
                Id = model.Id,
                CountryId = model.CountryId,
                StateLanguages = model.StateLanguage?.Select(MapToDto)
            };
        }

        public StateLanguageDto MapToDto(StateLanguage model)
        {
            if (model == null) return null;
            return new StateLanguageDto
            {
                Name = model.Name,
                LanguageId = model.LanguageId
            };
        }

        #endregion State

        #region City

        /// <inheritdoc />
        public City MapToModel(CityAddEditDto dto)
        {
            if (dto == null) return null;
            return new City
            {
                StateId = dto.StateId,
                CityLanguage = dto.CityLanguages?.Select(MapToModel).ToList()
            };
        }

        /// <inheritdoc />
        public CityLanguage MapToModel(CityLanguageDto dto)
        {
            if (dto == null) return null;
            return new CityLanguage
            {
                LanguageId = dto.LanguageId,
                Name = dto.Name
            };
        }

        public CityDto MapLanguageToDto(CityLanguage model)
        {
            if (model == null) return null;
            return new CityDto
            {
                Name = model.Name,
                Id = model.CityId
            };
        }

        public CityAddEditDto MapToDto(City model)
        {
            if (model == null) return null;
            return new CityAddEditDto
            {
                Id = model.Id,
                StateId = model.StateId,
                CityLanguages = model.CityLanguage?.Select(MapToDto)
            };
        }
        public CityLanguageDto MapToDto(CityLanguage model)
        {
            if (model == null) return null;
            return new CityLanguageDto
            {
                Name = model.Name,
                LanguageId = model.LanguageId
            };
        }
        #endregion City

    }
}