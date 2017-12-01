using AutoMapper.QueryableExtensions;
using LearningSystem.Services.Models;
using LerningSystem.Data;
using LerningSystem.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LearningSystem.Services.Implementation
{
    public class CourseService : ICourseService
    {
        private readonly LearningSystemDbContext db;

        public CourseService(LearningSystemDbContext db)
        {
            this.db = db;
        }

        public async Task<IEnumerable<CourseListingServiceModel>> ActiveAsync()
            => await this.db
                         .Courses
                         .OrderByDescending(c => c.Id)
                         .Where(c => c.StartDate >= DateTime.UtcNow)
                         .ProjectTo<CourseListingServiceModel>()
                         .ToListAsync();

        public async Task<TModel> ByIdAsync<TModel>(int id) where TModel : class
            => await this.db
                         .Courses
                         .Where(c => c.Id == id)
                         .ProjectTo<TModel>()
                         .FirstOrDefaultAsync();

        public async Task<bool> SignUpStudent(int courseId, string studentId)
        {
            var courseInfo = await this.GetCourseInfo(courseId, studentId);

            if (courseInfo == null
            || courseInfo.StartDate < DateTime.UtcNow
            || courseInfo.UserIsEnrolled)
            {
                return false;
            }

            var studentInCourse = new StudentCourse()
            {
                CourseId = courseId,
                StudentId = studentId
            };

            this.db.Add(studentInCourse);

            await this.db.SaveChangesAsync();

            return true;
        }

        public async Task<bool> SignOutStudentAsync(int courseId, string studentId)
        {
            var courseInfo = await this.GetCourseInfo(courseId, studentId);

            if (courseInfo == null
            || courseInfo.StartDate < DateTime.UtcNow
            || !courseInfo.UserIsEnrolled)
            {
                return false;
            }
            
            var studentInCourse = await this.db.FindAsync<StudentCourse>(courseId, studentId);

            this.db.Remove(studentInCourse);

            await this.db.SaveChangesAsync();

            return true;
        }


        private async Task<CourseWithStudentInfo> GetCourseInfo(int courseId, string studentId)
            => await this.db
                         .Courses
                         .Where(c => c.Id == courseId)
                         .Select(c => new CourseWithStudentInfo
                         {
                             StartDate = c.StartDate,
                             UserIsEnrolled = c.Students.Any(s => s.StudentId == studentId),
                         })
                         .FirstOrDefaultAsync();

        public async Task<bool> StudentIsEnrolledInCourseAsync(int courseId, string studentId)
            => await this.db
                         .Courses
                         .AnyAsync(c => c.Id == courseId && c.Students.Any(s => s.StudentId == studentId));

        public async Task<IEnumerable<CourseListingServiceModel>> FindAsync(string searchText)
            => await this.db
                         .Courses
                         .OrderByDescending(c => c.Id)
                         .Where(c => c.Name.ToLower().Contains(searchText.ToLower() ?? string.Empty))
                         .ProjectTo<CourseListingServiceModel>()
                         .ToListAsync();

        public async Task<bool> SaveExamSubmission(int courseId, string studentId, byte[] examSubmission)
        {
            var studentInCourse = await this.db.FindAsync<StudentCourse>(courseId, studentId);

            if(studentInCourse == null)
            {
                return false;
            }

            studentInCourse.ExamSubmission = examSubmission;

            await this.db.SaveChangesAsync();

            return true;
        }
    }
}
