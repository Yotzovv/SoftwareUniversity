using AutoMapper;
using LerningSystem.Common.Mapper;
using LerningSystem.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LearningSystem.Services.Implementation
{
    public class UserProfileServiceModel : IMapFrom<User>, IHaveCustomMapping
    {
        public string Username { get; set; }

        public string Name { get; set; }

        public DateTime Birthdate { get; set; }

        public IEnumerable<UserProfileCourseServiceModel> Courses { get; set; }

        public void ConfigureMapping(Profile mapper)
            => mapper.CreateMap<User, UserProfileServiceModel>()
                     .ForMember(u => u.Courses,
                               cfg =>
                               cfg.MapFrom(s => s.Courses
                                                 .Select(c => c.Course)));
    }
}
