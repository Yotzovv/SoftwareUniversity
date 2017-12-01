﻿using System;
using System.Threading.Tasks;

namespace LearningSystem.Services.Admin
{
    public interface IAdminCourseService
    {
        Task CreateAsync(string name, string description, DateTime startDate, DateTime endDate, string trainerId);
    }
}
