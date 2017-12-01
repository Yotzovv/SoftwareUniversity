using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bashsoft
{
    public class ExceptionMessages
    {
        public const string DataAlreadyInitialisedException = "Data is already initialised";
        public const string DataNotInitializedExceptionMessage = "Data is not initialised";
        public const string StudentAlreadyEnrolledInGivenCourse = "Student is already enrolled in the given course";
        public const string NotEnrolledInCourse = "Student must be enrolled in a course before you set his mark.";
        public const string InvalidNumberOfScores = "The number of scores for the given course is greater than the possible.";
        public const string InvalidStudentsFilter = "Yo filter is invalid madaafak";

    }
}
