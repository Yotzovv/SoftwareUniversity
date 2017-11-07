using System.Text.RegularExpressions;

namespace SimpleMvc.Framework.Attributes.Property
{
    public class RegexAttribute : PropertyAttribute
    {
        private readonly string pattern;

        public RegexAttribute(string pattern)
        {
            this.pattern = "^" + pattern + "$";
        }

        public override bool IsValid(object parameter)
        {
            return Regex.IsMatch(parameter.ToString(), this.pattern);
        }
    }
}
