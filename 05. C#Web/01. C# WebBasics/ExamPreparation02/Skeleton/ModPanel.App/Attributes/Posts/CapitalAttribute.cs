using SimpleMvc.Framework.Attributes.Validation;
using System.Linq;

namespace ModPanel.App.Attributes.Posts
{
    public class CapitalAttribute : PropertyValidationAttribute
    {
        public override bool IsValid(object value)
        {
            var title = value as string;

            if(title == null)
            {
                return true;
            }

            return char.IsUpper(title[0]);
        }
    }
}
