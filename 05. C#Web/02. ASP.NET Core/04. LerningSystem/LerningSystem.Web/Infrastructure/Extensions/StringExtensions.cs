using System.Text.RegularExpressions;

namespace LearningSystem.Web.Infrastructure.Extensions
{
    public static class StringExtensions
    {
        public static string ToFriendlyUrl(this string text)
            => Regex.Replace(text, @"[Â-Za-z0-0_\.~]+", "-").ToLower();
    }
}
