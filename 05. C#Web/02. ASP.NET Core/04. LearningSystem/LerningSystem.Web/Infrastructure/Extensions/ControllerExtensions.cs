﻿using Microsoft.AspNetCore.Mvc;

namespace LearningSystem.Web.Infrastructure.Extensions
{
    public static class ControllerExtensions
    {
        public static IActionResult ViewOrNotFound(this Controller controller, object model)
        {
            if(model == null)
            {
                return controller.NotFound();
            }

            return controller.View(model);
        }
    }
}
