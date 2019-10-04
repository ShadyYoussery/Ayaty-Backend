using Ayaty.Shared.Dto;
using Ayaty.Shared.Dto.Paging;

namespace Ayaty.Shared.Bll.Interfaces
{
    public interface IMessageResponse
    {
        MessageResponse<T> Response<T>(BllResponse<T> response);
        MessageListResponse<T> Response<T>(BllResponse<PageList<T>> response);
        MessageResponse<T> ResponseUnAuthorized<T>();
    }
}