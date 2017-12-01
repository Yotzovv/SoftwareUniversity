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
    public class UserService : IUserService
    {
        private readonly LearningSystemDbContext db;
        private readonly IPdfGenerator pdfGenerator;

        public UserService(LearningSystemDbContext db, IPdfGenerator pdfGenerator)
        {
            this.db = db;
            this.pdfGenerator = pdfGenerator;
        }

        public async Task<IEnumerable<UserListingServiceModel>> FindAsync(string searchText)
            => await this.db
                         .Users
                         .OrderBy(u => u.UserName)
                         .Where(u => u.Name.ToLower().Contains(searchText.ToLower() ?? string.Empty))
                         .ProjectTo<UserListingServiceModel>()
                         .ToListAsync();

        public async Task<byte[]> GetPdfCertificate(int courseId, string studentId)
        {
            var studentInCourse = await this.db
                                            .FindAsync<StudentCourse>(courseId, studentId);

            if(studentInCourse == null)
            {
                return null;
            }

            var cartificateInfo = await this.db
                                 .Courses
                                 .Where(c => c.Id == courseId)
                                 .Select(c => new
                                 {
                                     CourseName = c.Name,
                                     CourseStartDate = c.StartDate,
                                     CourseEndDate = c.EndDate,
                                     StudentName = c.Students
                                                    .Where(s => s.StudentId == studentId)
                                                    .Select(s => s.Student.Name)
                                                    .FirstOrDefault(),
                                    StudentGrade = c.Students
                                                    .Where(s => s.StudentId == studentId)
                                                    .Select(s => s.Grade)
                                                    .FirstOrDefault(),
                                    Trainer = c.Trainer.Name
                                 })
                                 .FirstOrDefaultAsync();

            return this.pdfGenerator
                       .GeneratePdfFromHtml(
                        string.Format(ServiceConstants.PdfCertificateFormat,
                        cartificateInfo.CourseName,
                        cartificateInfo.CourseStartDate.ToShortDateString(),
                        cartificateInfo.CourseEndDate.ToShortDateString(),
                        cartificateInfo.StudentName,
                        cartificateInfo.StudentGrade,
                        cartificateInfo.Trainer,
                        DateTime.UtcNow.ToShortDateString()));
        }

        public async Task<UserProfileServiceModel> ProfileAsync(string id)
            => await this.db
                         .Users
                         .Where(u => u.Id == id)
                         .ProjectTo<UserProfileServiceModel>(new { studentId = id })
                         .FirstOrDefaultAsync();
                        
    }
}
