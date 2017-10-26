using SimpleMvc.Framework.Attributes.Validation;
using System;

namespace GameStore.App.Infrastructure.Validation.Users
{
    public class EmailAttribute : PropertyValidationAttribute
    {
        public override bool IsValid(object value)
        {
            var email = value as string;

            if(email == null)
            {
                return true;
            }

            return email.Contains(".") && email.Contains("@");
        }
    }
}
