namespace CarDealer.Web.Infrastructure.Extensions
{
    public static class StringExtensions
    {
        public static string ToPrice(this double priceText)
        {
            return "$" + priceText.ToString("f2");
        }

        public static string ToProcentage(this double number)
        {
            return $"{number.ToString("f2")} %";
        }
    }
}
