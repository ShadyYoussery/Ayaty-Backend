using System;
using Ayaty.Shared.Dto.Paging;
using Ayaty.Shared.Enums;

namespace Ayaty.Shared.Dto
{
    public class MessageResponse<T>
    {
        #region Ctor

        public MessageResponse()
        {
            
        }
        public MessageResponse(T data)
        {
            Status = MessageStatus.Ok;
            Data = data;
        }

        public MessageResponse(Enum errorCode)
        {
            Status = MessageStatus.InValid;
            ErrorCode = errorCode;
        }

        public MessageResponse(Exception exception)
        {
            Status = MessageStatus.Exception;
            Exception = exception;
        }

        #endregion Ctor

        public T Data { get; set; }
        public Enum ErrorCode { get; set; }
        public MessageStatus Status { get; set; }
        public Exception Exception { get; set; }
    }

    public class MessageListResponse<T> : MessageResponse<PageList<T>>
    {
        #region Ctor

        public MessageListResponse()
        {
            
        }

        public MessageListResponse(PageList<T> data)
        {
            Status = MessageStatus.Ok;
            CurrentPage = data.CurrentPage;
            TotalCount = data.TotalCount;
            TotalPages = data.TotalPages;
            PageSize = data.PageSize;
            Data = data;
        }

        public MessageListResponse(Enum errorCode) : base(errorCode) { }

        public MessageListResponse(Exception exception) : base(exception) { }
        
        #endregion Ctor
        public int TotalCount { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public int PageSize { get; set; }
    }
}