using Market.Data.Models;
using System.Collections.Generic;

namespace Market.Web.Areas.Admin.Models
{
    public class AdminPanelModel
    {
        public IEnumerable<UserLogin> UserLogins { get; set; }

        public IEnumerable<UserActivity> UsersActivities { get; set; }
    }
}
