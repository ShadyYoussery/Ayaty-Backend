using System.Threading.Tasks;
using Ayaty.Clinic.Management.Dtos.Clinic;
using Ayaty.Shared.Dto;

namespace Ayaty.Clinic.Management.Bll.Interfaces
{
    public interface IClinic
    {
        /// <summary>
        /// add new clinic and return data
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        Task<BllResponse<ClinicDto>> Add(ClinicDto dto);
        void ChangeLogo();
    }
}