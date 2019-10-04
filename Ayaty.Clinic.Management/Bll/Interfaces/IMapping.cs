using Ayaty.Context.Models;
using Ayaty.Clinic.Management.Dtos.Clinic;
using Ayaty.Clinic.Management.Dtos.ClinicComminicationWay;

namespace Ayaty.Clinic.Management.Bll.Interfaces
{
    /// <summary>
    /// Interface of mapping
    /// </summary>
    public interface IMapping
    {
        #region Clinic

        /// <summary>
        /// Map selected client by language to client Dto
        /// </summary>
        /// <param name="model">model which in db context</param>
        /// <returns>ClinicDto</returns>
        Dtos.Clinic.ClinicLanguageDto MapClinicLanguageToDto(ClinicLanguage model);

        /// <summary>
        /// Map selected client by language to client Dto
        /// </summary>
        /// <param name="model">model which in db context</param>
        /// <returns>full data of Clinic Dto</returns>
        ClinicLanguageFullDto MapClinicLanguageToFullDto(ClinicLanguage model);

        /// <summary>
        /// Map client to client Dto
        /// </summary>
        /// <param name="model">model which in db context</param>
        /// <returns>full data of Clinic Dto</returns>
        ClinicDto MapToFullDto(Ayaty.Context.Models.Clinic model);

        /// <summary>
        /// map add edit dto to Clinic
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        Ayaty.Context.Models.Clinic MapToModel(ClinicDto dto);

        #endregion Clinic

        #region ClinicComminicationWay

        /// <summary>
        /// Map Clinic commincation way to Dto
        /// </summary>
        /// <param name="model">model which in db context</param>
        /// <returns>ClinicComminicationWayDto</returns>
        ClinicComminicationWayDto MapToDto(ClinicComminicationWay model);

        /// <summary>
        /// Map ClinicComminicationWayDto to ClinicComminicationWay
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        ClinicComminicationWay MapToModel(ClinicComminicationWayDto dto);

        #endregion ClinicComminicationWay

        #region ClinicLanguage

        /// <summary>
        /// Map model to dto
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Dtos.ClinicLanguage.ClinicLanguageDto MapToDto(ClinicLanguage model);

        /// <summary>
        /// map to model
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        ClinicLanguage MapToModel(Dtos.ClinicLanguage.ClinicLanguageDto dto);

        #endregion ClinicLanguage

    }
}