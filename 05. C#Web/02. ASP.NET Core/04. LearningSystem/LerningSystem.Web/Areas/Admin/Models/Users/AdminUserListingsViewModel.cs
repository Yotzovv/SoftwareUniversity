using LearningSystem.Services.Admin.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace LerningSystem.Web.Areas.Admin.Models.Users
{
    public class AdminUserListingsViewModel
    {
        public IEnumerable<AdminUserListingServiceModel> Users { get; set; }

        public IEnumerable<SelectListItem> Roles { get; set; }
    }
}
