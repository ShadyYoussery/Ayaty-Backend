using System.Threading.Tasks;
using Ayaty.Setup.Dtos.State;
using Shared.Dto;
using Shared.Dto.Paging;

namespace Ayaty.Setup.Bll.Interfaces
{
    public interface IState
    {
        /// <summary>
        /// Add new State with each language
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        Task<BllResponse<StateAddEditDto>> Add(StateAddEditDto dto);

        /// <summary>
        /// Edit State Data
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        Task<BllResponse<StateAddEditDto>> Edit(StateAddEditDto dto);

        /// <summary>
        /// Get List of States
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        Task<BllResponse<PageList<StateDto>>> List(StateSearchDto dto);

        /// <summary>
        /// get state with id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<BllResponse<StateAddEditDto>> GetById(int id);

        /// <summary>
        /// delete state with Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<BllResponse<bool>> Delete(int id);
    }
}