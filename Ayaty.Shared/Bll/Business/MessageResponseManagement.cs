using Ayaty.Shared.Bll.Interfaces;
using Ayaty.Shared.Dto;
using Ayaty.Shared.Dto.Paging;
using Ayaty.Shared.Enums;

namespace Ayaty.Shared.Bll.Business
{
    public class MessageResponseManagement : IMessageResponse
    {
        #region Feilds



        #endregion Feilds

        #region Ctor

        public MessageResponseManagement()
        {
        }

        #endregion Ctor

        #region Public Methods

        public MessageResponse<T> Response<T>(BllResponse<T> response)
        {
            if(response.Exception!=null) return new MessageResponse<T>(response.Exception);
            if(!response.IsSuccess) return new MessageResponse<T>(response.ErrorCode);
            return new MessageResponse<T>(response.Data);
        }

        public MessageListResponse<T> Response<T>(BllResponse<PageList<T>> response)
        {
            if (response.Exception != null) return new MessageListResponse<T>(response.Exception);
            if (!response.IsSuccess) return new MessageListResponse<T>(response.ErrorCode);
            return new MessageListResponse<T>(response.Data);
        }

        public MessageResponse<T> ResponseUnAuthorized<T>()
        {
            return new MessageResponse<T> {Status = MessageStatus.UnAthorized};

        }

        #endregion Public Methods

        #region private Methods



        #endregion private Methods



    }
}