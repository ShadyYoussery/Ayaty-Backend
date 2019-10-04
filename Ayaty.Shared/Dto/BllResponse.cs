using System;

namespace Ayaty.Shared.Dto
{
    public class BllResponse<TEntity>
    {
        #region Ctor

        public BllResponse()
        {
        }

        public BllResponse(TEntity data)
        {
            IsSuccess = true;
            Data = data;
        }

        public BllResponse(Enum errorCode)
        {
            IsSuccess = false;
            ErrorCode = errorCode;
        }

        public BllResponse(Exception exception)
        {
            IsSuccess = false;
            Exception = exception;
        }

        #endregion Ctor


        #region Properties

        public TEntity Data { get; set; }
        public bool IsSuccess { get; set; }
        public Enum ErrorCode { get; set; }
        public Exception Exception { get; set; }

        #endregion Properties

    }
}