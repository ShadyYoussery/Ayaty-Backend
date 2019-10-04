using System;
using System.ComponentModel.DataAnnotations;

namespace Ayaty.Shared.Attributes
{
    public class AyatyRequiredAttribute : RequiredAttribute
    {
        public AyatyRequiredAttribute(int errorCode)
        {
            ErrorMessage = errorCode.ToString();
        }

    }
}