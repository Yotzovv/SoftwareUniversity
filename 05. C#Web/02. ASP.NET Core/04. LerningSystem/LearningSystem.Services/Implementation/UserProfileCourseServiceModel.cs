using AutoMapper;
using LerningSystem.Common.Mapper;
using LerningSystem.Data.Models;
using LerningSystem.Data.Models.Enums;
using System.Linq;

namespace LearningSystem.Services.Implementation
{
    public class UserProfileCourseServiceModel : IMapFrom<Course>, IHaveCustomMapping
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public Grade Grade { get; set; }

        public void ConfigureMapping(Profile mapper)
        {
            string studentId = null;

            mapper.CreateMap<Course, UserProfileCourseServiceModel>()
                  .ForMember(p => p.Grade,
                             cfg => cfg.MapFrom(c => c.Students
                                                      .Where(s => s.StudentId == studentId)
                                                      .Select( s => s.Grade)
                                                      .FirstOrDefault()));
        }
    }
}
