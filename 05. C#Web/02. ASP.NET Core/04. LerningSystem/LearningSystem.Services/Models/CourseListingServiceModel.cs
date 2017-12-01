using LerningSystem.Common.Mapper;
using LerningSystem.Data.Models;
using System;

namespace LearningSystem.Services.Models
{
    public class CourseListingServiceModel : IMapFrom<Course>
    {
        public int Id { get; set; }
        
        public string Name { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }
    }
}
