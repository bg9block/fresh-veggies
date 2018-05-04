using System.Collections;
using System.ComponentModel.DataAnnotations;

namespace FreshVeg.API.Validation
{
    public class EnsureMinimumElementsAttribute : ValidationAttribute
    {
        private readonly int _minElements;
        public EnsureMinimumElementsAttribute(int minElements, string errorMessage)
        {
            _minElements = minElements;
            ErrorMessage = errorMessage;
        }

        public override bool IsValid(object value)
        {
            var list = value as IList;
            return list?.Count >= _minElements;
        }
    }
}