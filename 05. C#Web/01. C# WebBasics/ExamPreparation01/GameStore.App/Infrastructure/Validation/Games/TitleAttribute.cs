using SimpleMvc.Framework.Attributes.Validation;

namespace GameStore.App.Infrastructure.Validation.Games
{
    public class TitleAttribute : PropertyValidationAttribute
    {
        public override bool IsValid(object value)
        {
            var title = value as string;

            if(title == null)
            {
                return true;
            }

            return title.Length >= 3
               && title.Length <= 100
               && char.IsUpper(title[0]);
        }
    }
}
