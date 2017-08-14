namespace StudentSys.Migrations
{
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<StudentSys.SystemContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(StudentSys.SystemContext context)
        {
            // context.Students.AddOrUpdate
            // (
            //       new Student
            //       {
            //           Id = 1,
            //           Name = "Ivan",
            //           PhoneNumber = "9123910",
            //           Birthday = new DateTime(1994, 4, 5),
            //           RegistrationDate = new DateTime(2016, 4, 5)
            //       },

            //       new Student
            //       {
            //           Id = 2,
            //           Name = "Stoyan",
            //           PhoneNumber = "1235653",
            //           Birthday = new DateTime(1994, 4, 5),
            //           RegistrationDate = new DateTime(2016, 4, 5)
            //       },

            //       new Student
            //       {
            //           Id = 3,
            //           Name = "Isac",
            //           PhoneNumber = "6547438643",
            //           Birthday = new DateTime(1994, 4, 5),
            //           RegistrationDate = new DateTime(2016, 4, 5)
            //       }
            //   );

            //context.Courses.AddOrUpdate
            //    (
            //        new Course
            //        {
            //            Id = 1,
            //            Name = "C++ Programming",
            //            Discription = "Learn C++",
            //            StartDate = new DateTime(2017, 1, 3),
            //            EndDate = new DateTime(2017, 3, 3)
            //        },

            //        new Course
            //        {
            //            Id = 2,
            //            Name = "C# Programming",
            //            Discription = "Learn C#",
            //            StartDate = new DateTime(2017, 1, 3),
            //            EndDate = new DateTime(2017, 3, 3)
            //        },

            //        new Course
            //        {
            //            Id = 3,
            //            Name = "Arduino Programming",
            //            Discription = "Learn Arduino",
            //            StartDate = new DateTime(2017, 1, 3),
            //            EndDate = new DateTime(2017, 3, 3)
            //        }
            //    );

            //context.Resources.AddOrUpdate
            //(
            //    new Resource
            //    {
            //        Id = 1,
            //        Name = "C++ HW",
            //        RecourseType = Resource.TypeOfResource.Document,
            //        URL = "www.www.com",
            //        CourseId = 4
            //    },

            //    new Resource
            //    {
            //        Id = 2,
            //        Name = "C# HW",
            //        RecourseType = Resource.TypeOfResource.Document,
            //        URL = "www.C#.com",
            //        CourseId = 5
            //    },

            //    new Resource
            //    {
            //        Id = 3,
            //        Name = "Arduino HW",
            //        RecourseType = Resource.TypeOfResource.Document,
            //        URL = "www.arduino.com",
            //        CourseId = 6
            //    }
            //);

            //context.Homeworks.AddOrUpdate
            //(
            //    new Homework
            //    {
            //        Id = 1,
            //        Content = "Tottaly not a virus",
            //        ContentType = Homework.TypeOfContent.app,
            //        SubmissionDate = new DateTime(2017, 2, 3),
            //        CourseId = 4,
            //        StudentId = 1
            //    },

            //    new Homework
            //    {
            //        Id = 2,
            //        Content = "Okay Its a virus",
            //        ContentType = Homework.TypeOfContent.zip,
            //        SubmissionDate = new DateTime(2017, 2, 3),
            //        CourseId = 5,
            //        StudentId = 2
            //    },

            //    new Homework
            //    {
            //        Id = 3,
            //        Content = "jk",
            //        ContentType = Homework.TypeOfContent.pdf,
            //        SubmissionDate = new DateTime(2017, 2, 3),
            //        CourseId = 6,
            //        StudentId = 3
            //    }
            //);

            //context.StudentCourses.AddOrUpdate
            //(
            //    new StudentCourse
            //    {
            //        Student_Id = 1,
            //        Course_Id = 4
            //    },

            //    new StudentCourse
            //    {
            //        Student_Id = 2,
            //        Course_Id = 5
            //    },

            //    new StudentCourse
            //    {
            //        Student_Id = 3,
            //        Course_Id = 6
            //    }
            //);
        }
    }
}
