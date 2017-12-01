using LearningSystem.Services.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LearningSystem.Services
{
    public interface ICourseService
    {
        Task<IEnumerable<CourseListingServiceModel>> ActiveAsync();

        Task<IEnumerable<CourseListingServiceModel>> FindAsync(string searchText);

        Task<TModel> ByIdAsync<TModel>(int id) where TModel : class;

        Task<bool> SignUpStudent(int courseId, string userId);

        Task<bool> StudentIsEnrolledInCourseAsync(int courseId, string userId);

        Task<bool> SignOutStudentAsync(int id, string userId);

        Task<bool> SaveExamSubmission(int courseId, string studentId, byte[] examSubmission);
    }
}
