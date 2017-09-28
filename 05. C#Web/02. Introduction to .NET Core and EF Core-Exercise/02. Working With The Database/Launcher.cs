using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

class Launcher
{
    static void Main(string[] args)
    {
        using (var context = new SystemContext())
        {
            // ClearDatabase(context);
            // FillDatabase(context);    // seeding needs fixing
            Tasks(context);
        }
    }

    private static void Tasks(SystemContext context)
    {
        //   FirstTask(context);
        //   SecondTask(context);
        //   ThirdTask(context);
        //   ForthTask(context);
        //   FifthTask(context);

    }

    private static void FifthTask(SystemContext context)
    {
        var students = context.Students.OrderByDescending(tp => tp.Courses.Sum(p => p.Course.Price))
                                       .ThenByDescending(nc => nc.Courses.Count)
                                       .ThenBy(s => s.Name);

        foreach (var student in students)
        {
            Console.WriteLine($"Student Name: {student.Name}");
            Console.WriteLine($"Courses: {student.Courses.Count}");
            Console.WriteLine($"Total price: {student.Courses.Sum(p => p.Course.Price)}");
            Console.WriteLine($"Avg price: {student.Courses.Average(p => p.Course.Price)}");
        }
    }

    private static void ForthTask(SystemContext context)
    {
        var date = DateTime.ParseExact(Console.ReadLine(), "yyyy-MM-dd", CultureInfo.InvariantCulture);

        var courses = context.Courses
                             .Where(c => (c.StartDate.Year <= date.Year
                                   && c.StartDate.Month <= date.Month
                                   && c.StartDate.Day <= date.Day)
                                   && (c.EndDate.Year >= date.Year
                                   && c.EndDate.Month >= date.Month
                                   && c.EndDate.Day >= date.Day))
                             .OrderByDescending(s => s.Participants.Count)
                             .ThenByDescending(d => d.EndDate - d.StartDate);

        foreach (var c in courses)
        {
            Console.WriteLine($"Course name: {c.Name}");
            Console.WriteLine($"Start date: {c.StartDate}");
            Console.WriteLine($"End date: {c.EndDate}");
            Console.WriteLine($"Duration: {c.EndDate - c.StartDate}");
        }
    }

    private static void ThirdTask(SystemContext context)
    {
        var courses = context.Courses
                             .Where(r => r.Resources.Count > 5)
                             .OrderByDescending(rc => rc.Resources.Count)
                             .ThenByDescending(sd => sd.StartDate);

        foreach (var course in courses)
        {
            Console.WriteLine($"Course name: {course.Name}");
            Console.WriteLine($"Resource count: {course.Resources.Count}");
        }
    }

    private static void SecondTask(SystemContext context)
    {
        foreach (var course in context.Courses.OrderBy(sd => sd.StartDate).ThenByDescending(ed => ed.EndDate))
        {
            Console.WriteLine($"Name: {course.Name}");
            Console.WriteLine($"Description: {course.Description}");

            foreach (var res in context.Resources.Where(c => c.Course == course))
            {
                Console.WriteLine($"Name: {res.Name}");
                Console.WriteLine($"Type: {res.Type}");
                Console.WriteLine($"URL: {res.URL}");
                Console.WriteLine($"Course Name: {res.Course.Name}");
                Console.WriteLine();
            }
            Console.WriteLine();
        }
    }

    private static void FirstTask(SystemContext context)
    {
        foreach (var student in context.Students)
        {
            Console.WriteLine($"Name: {student.Name}");
            Console.WriteLine("Homeworks:");

            foreach (var hw in context.Homeworks.Where(s => s.StudentId == student.Id))
            {
                Console.WriteLine($"Content: {hw.Content}");
                Console.WriteLine($"Content-Type: {hw.Type}");
            }
            Console.WriteLine();

        }
    }

    private static void FillDatabase(SystemContext context)
    {
        // Students
        Console.WriteLine($"Adding students..");
        for (int i = 1; i <= 25; i++)
        {
            context.Students.Add
                (
                    new Student($"Test{i}", $"Random Phone {i}", DateTime.Now.AddDays(i), DateTime.Now.AddYears(-20).AddDays(i))
                );
        }
        context.SaveChanges();

        // Courses
        Console.WriteLine($"Adding courses..");
        var addedCourses = new List<Course>();

        for (int i = 1; i <= 10; i++)
        {
            addedCourses.Add
                (
                    new Course($"Course {i}", $"{i}", DateTime.Now.AddDays(i), DateTime.Now.AddDays(i + 20), 100 * i)
                );
            context.Courses.Add
                (
                    new Course($"Course {i}", $"{i}", DateTime.Now.AddDays(i), DateTime.Now.AddDays(i + 20), 100 * i)
                );
        }

        // Students mapped to courses
        Console.WriteLine($"Mapping students to courses..");
        var random = new Random();
        var studentsIds = context.Students
                                 .Select(s => s.Id)
                                 .ToList();

        for (int i = 1; i <= 10; i++)
        {
            var studentsInCourse = random.Next(2, 25 / 2);
            var currentCourse = addedCourses[i - 1];

            for (int b = 0; b < studentsInCourse; b++)
            {
                var studentId = studentsIds[random.Next(0, studentsIds.Count)];

                if (currentCourse.Participants.Any(s => s.Student_Id == studentId))
                {
                    b--;
                    continue;
                }

                currentCourse.Participants.Add(new StudentCourse(studentId, currentCourse.Id));
            }

            var resourcesInCourse = random.Next(2, 20);
            var types = new[] { 0, 1, 2, 999 };

            currentCourse.Resources.Add(new Resource($"Resource{i}", (ResourseType)types[random.Next(0, types.Length)], $"URL {i}"));
            context.Courses.Add(currentCourse);
        }
        context.SaveChanges();

        // Homworks
        Console.WriteLine($"Adding homeworks..");
        for (int i = 0; i < 10; i++)
        {
            var currentCourse = addedCourses[i];

            var studentsInCourseIDs = currentCourse.Participants.Select(s => s.Student_Id).ToList();

            for (int b = 0; b < studentsInCourseIDs.Count; b++)
            {
                var totalHWs = random.Next(2, 5);

                for (int k = 0; k < totalHWs; k++)
                {
                    context.Homeworks.Add(new Homework
                        (
                            $"Content {b}",
                            ContentType.Zip,
                            DateTime.Now.AddDays(-i),
                            studentsInCourseIDs[b],
                            currentCourse.Id
                        ));
                }
            }
        }

        context.SaveChanges();
    }

    private static void ClearDatabase(SystemContext context)
    {
        Console.WriteLine($"Deleting database...");
        context.Database.EnsureDeleted();

        Console.WriteLine($"Creating database...");
        context.Database.EnsureCreated();

        // Console.WriteLine($"Migrating database...");
        // context.Database.Migrate();
    }
}
