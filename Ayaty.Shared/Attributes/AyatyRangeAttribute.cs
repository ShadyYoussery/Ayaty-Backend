using System.ComponentModel.DataAnnotations;

namespace Ayaty.Shared.Attributes
{
    public class AyatyRangeAttribute : RangeAttribute
    {
        public AyatyRangeAttribute(double minimum, double maximum, int errorCode) :base(minimum,maximum)
        {
            ErrorMessage = errorCode.ToString();
        }
    }
}