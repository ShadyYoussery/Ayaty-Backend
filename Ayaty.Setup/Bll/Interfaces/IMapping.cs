using Ayaty.Context.Models;
using Ayaty.Setup.Dtos.City;
using Ayaty.Setup.Dtos.City.CityLanguage;
using Ayaty.Setup.Dtos.Country;
using Ayaty.Setup.Dtos.Country.CountryLanguage;
using Ayaty.Setup.Dtos.State;
using Ayaty.Setup.Dtos.State.StateLanguage;

namespace Ayaty.Setup.Bll.Interfaces
{
    /// <summary>
    /// Interface of mapping
    /// </summary>
    public interface IMapping
    {
        #region Country

        /// <summary>
        /// map dto to model
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        Country MapToModel(CountryAddEditDto dto);

        /// <summary>
        /// map dto to model
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        CountryLanguage MapToModel(CountryLanguageDto dto);

        /// <summary>
        /// Map language to Dto
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        CountryDto MapLanguageToDto(CountryLanguage model);

        CountryLanguageDto MapToDto(CountryLanguage model);

        CountryAddEditDto MapToDto(Country model);
        #endregion Country

        #region State

        /// <summary>
        /// map dto to model
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        State MapToModel(StateAddEditDto dto);

        /// <summary>
        /// map dto to model
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        StateLanguage MapToModel(StateLanguageDto dto);

        StateDto MapLanguageToDto(StateLanguage model);

        StateAddEditDto MapToDto(State model);
        StateLanguageDto MapToDto(StateLanguage model);

        #endregion State

        #region City

        /// <summary>
        /// map dto to model
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        City MapToModel(CityAddEditDto dto);

        /// <summary>
        /// map dto to model
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        CityLanguage MapToModel(CityLanguageDto dto);

        CityDto MapLanguageToDto(CityLanguage model);
        CityAddEditDto MapToDto(City model);
        CityLanguageDto MapToDto(CityLanguage model);

        #endregion City


    }
}