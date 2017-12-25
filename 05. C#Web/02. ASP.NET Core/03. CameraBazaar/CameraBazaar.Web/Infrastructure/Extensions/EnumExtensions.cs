using CameraBazaar.Data.Enums;

namespace CameraBazaar.Web.Infrastructure.Extensions
{
    public static class EnumExtensions
    {
        public static string DisplayName(this LightMeter lightMetering)
        {
            if(lightMetering == LightMeter.CenterWeighted)
            {
                return "Center-Weighted";
            }

            return lightMetering.ToString();
        }
    }
}
