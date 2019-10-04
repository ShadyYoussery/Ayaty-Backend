using System.Threading.Tasks;
using Ayaty.Setup.Dtos.Country;
using Shared.Dto;
using Shared.Dto.Paging;

namespace Ayaty.Setup.Bll.Interfaces
{
    public interface ICountry
    {
        /// <summary>
        /// Add new Country with each language
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        Task<BllResponse<CountryAddEditDto>> Add(CountryAddEditDto dto);

        /// <summary>
        /// Edit Country Data
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        Task<BllResponse<CountryAddEditDto>> Edit(CountryAddEditDto dto);

        /// <summary>
        /// Get list of Countries
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        Task<BllResponse<PageList<CountryDto>>> List(CountrySearchDto dto);

        /// <summary>
        /// Get Country by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<BllResponse<CountryAddEditDto>> GetById(int id);

        /// <summary>
        /// delete Country By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<BllResponse<bool>> Delete(int id);
    }
}