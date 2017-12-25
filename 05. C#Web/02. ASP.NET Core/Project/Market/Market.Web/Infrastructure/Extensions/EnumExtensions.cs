using Market.Data.Models.Enums;

namespace Market.Web.Infrastructure.Extensions
{
    public static class EnumExtensions
    {
        public static string DisplayName(this Categories category)
        {
            if(category == Categories.ConstructionMaterials)
            {
                return "Construction-Materials";
            }

            return category.ToString();
        }
    }
}
