using SimpleMvc.Framework.Attributes.Validation;

namespace JudgeApp.Attriubte
{
    public class CapitalAttribute : PropertyValidationAttribute
    {
        public override bool IsValid(object value)
        {
            var title = value as string;

            if (title == null)
            {
                return true;
            }

            return char.IsUpper(title[0]);
        }
    }
}
