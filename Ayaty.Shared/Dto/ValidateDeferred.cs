using System;
using System.Threading.Tasks;
using Z.EntityFramework.Plus;

namespace Ayaty.Shared.Dto
{
    public class ValidateDeferred<T>
    {
        public QueryFutureValue<T> FutureValue { get; set; }
        public Enum ErrorCode { get; set; }
        public bool IsTrueReturn { get; set; }
        public  Func<QueryFutureValue<T>,Task<bool>> Func { get; set; }
    }
}