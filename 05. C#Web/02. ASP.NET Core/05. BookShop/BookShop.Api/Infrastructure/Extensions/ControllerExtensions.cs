using Microsoft.AspNetCore.Mvc;

namespace BookShop.Api.Infrastructure.Extensions
{
    public static class ControllerExtensions
    {
        public static IActionResult OkOrNotFound(this Controller controller, object model)
        {
            if(model is null)
            {
                return controller.NotFound();
            }

            return controller.Ok(model);
        }
    }
}
