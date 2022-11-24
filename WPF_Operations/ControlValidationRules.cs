using System.Globalization;
using System.Windows.Controls;

namespace WPF_Operations
{
    public class ControlValidationRules : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (value.ToString().Length > 0)
            {
                return new ValidationResult(true, null);
            }
            else
            {
                return new ValidationResult(false, "Required Field Validation");
            }
        }
    }
}
