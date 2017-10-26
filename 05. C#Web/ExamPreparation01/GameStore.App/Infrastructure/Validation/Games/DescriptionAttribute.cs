using SimpleMvc.Framework.Attributes.Validation;

namespace GameStore.App.Infrastructure.Validation.Games
{
    public class DescriptionAttribute : PropertyValidationAttribute
    {
        public override bool IsValid(object value)
        {
            var description = value as string;

            if (description == null)
            {
                return true;
            }

            return description.Length >= 20;
        }
    }
}
