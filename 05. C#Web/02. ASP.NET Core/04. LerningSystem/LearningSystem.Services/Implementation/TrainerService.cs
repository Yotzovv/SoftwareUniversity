﻿using System.Threading.Tasks;
using LearningSystem.Services.Models;
using LerningSystem.Data;
using System.Linq;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using LerningSystem.Data.Models.Enums;
using LerningSystem.Data.Models;

namespace LearningSystem.Services.Implementation
{
    public class TrainerService : ITrainerService
    {
        private readonly LearningSystemDbContext db;

        public TrainerService(LearningSystemDbContext db)
        {
            this.db = db;
        }

        public async Task<bool> AddGradeAsync(int courseId, string studentId, Grade grade)
        {
            var studentInCourse = await this.db
                                            .FindAsync<StudentCourse>(courseId, studentId);

            if (studentInCourse == null)
            {
                return false;
            }

            studentInCourse.Grade = grade;

            await this.db.SaveChangesAsync();

            return true;
        }

        public async Task<IEnumerable<CourseListingServiceModel>> CoursesAsync(string trainerId)
            => await this.db
                         .Courses
                         .Where(c => c.TrainerId == trainerId)
                         .ProjectTo<CourseListingServiceModel>()
                         .ToListAsync();

        public async Task<byte[]> GetExamSubmissionAsync(int courseId, string studentId)
            => (await this.db.FindAsync<StudentCourse>(courseId, studentId))?.ExamSubmission;

        public async Task<bool> IsTrainer(int courseId, string trainerId)
            => await this.db
                         .Courses
                         .AnyAsync(c => c.Id == courseId && c.TrainerId == trainerId);

        public async Task<IEnumerable<StudentInCourseServiceModel>> StudentsInCourseAsync(int courseId)
            => await this.db
                         .Courses
                         .Where(c => c.Id == courseId)
                         .Select(c => c.Students.Select(s => s.Student))
                         .ProjectTo<StudentInCourseServiceModel>(new { courseId })
                         .ToListAsync();

        public async Task<StudentInCourseNamesServiceModel> StudentInCourseNamesAsync(int courseId, string studentId)
        {
            var username = await this.db
                                     .Users
                                     .Where(u => u.Id == studentId)
                                     .Select(u => u.UserName)
                                     .FirstOrDefaultAsync();

            if(username == null)
            {
                return null;
            }

            var courseName = await this.db
                                       .Courses
                                       .Where(c => c.Id == courseId)
                                       .Select(c => c.Name)
                                       .FirstOrDefaultAsync();

            return new StudentInCourseNamesServiceModel
            {
                Username = username,
                CourseName = courseName
            };
        }
    }
}
