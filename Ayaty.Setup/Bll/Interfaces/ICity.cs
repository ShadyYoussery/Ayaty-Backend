using System.Threading.Tasks;
using Ayaty.Setup.Dtos.City;
using Shared.Dto;
using Shared.Dto.Paging;

namespace Ayaty.Setup.Bll.Interfaces
{
    public interface ICity
    {
        /// <summary>
        /// Add new City with each language
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        Task<BllResponse<CityAddEditDto>> Add(CityAddEditDto dto);

        /// <summary>
        /// Edit City Data
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        Task<BllResponse<CityAddEditDto>> Edit(CityAddEditDto dto);

        /// <summary>
        /// Get List of Cities
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        Task<BllResponse<PageList<CityDto>>> List(CitySearchDto dto);

        /// <summary>
        /// get City with id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<BllResponse<CityAddEditDto>> GetById(int id);

        /// <summary>
        /// delete City with Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<BllResponse<bool>> Delete(int id);
    }
}