using LearningSystem.Services.Models;
using System.Collections.Generic;

namespace LearningSystem.Web.Models.Home
{
    public class HomeIndexViewModel : SearchFormModel
    {
        public IEnumerable<CourseListingServiceModel> Courses { get; set; }
    }
}
