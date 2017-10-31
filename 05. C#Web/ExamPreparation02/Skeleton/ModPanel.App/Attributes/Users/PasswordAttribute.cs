using SimpleMvc.Framework.Attributes.Validation;
using System.Linq;

namespace ModPanel.App.Attributes.Users
{
    public class PasswordAttribute : PropertyValidationAttribute
    {
        public override bool IsValid(object value)
        {
            var password = value as string;

            if (password == null)
            {
                return true;
            }

            return password.Any(c => char.IsDigit(c))
                && password.Any(c => char.IsUpper(c))
                && password.Any(c => char.IsLower(c))
                && password.Length >= 6;
        }
    }
}
