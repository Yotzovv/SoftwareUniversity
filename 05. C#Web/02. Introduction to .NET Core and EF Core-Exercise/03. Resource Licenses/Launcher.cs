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
        FirstTask(context);
        SecondTask(context);
    }

    private static void SecondTask(SystemContext context)
    {
        var students = context.Students
                             .OrderByDescending(c => c.Courses.Count)
                             .OrderByDescending(c => c.Courses.Sum(r => r.Course.Resources.Count));

        foreach (var student in students)
        {
            Console.WriteLine($"Student name: {student.Name}");
            Console.WriteLine($"Courses count: {student.Courses.Count}");
            Console.WriteLine($"Resources count: {student.Courses.Sum(r => r.Course.Resources.Count)}");
        }
    }

    private static void FirstTask(SystemContext context)
    {
        var courses = context.Courses
                             .OrderByDescending(rc => rc.Resources.Count)
                             .OrderBy(cn => cn.Name);   

        foreach (var course in courses)
        {
            Console.WriteLine($"Course name: {course.Name}");

            foreach (var resource in course.Resources.OrderByDescending(lc => lc.Licenses.Count).ThenBy(n => n.Name))
            {
                Console.WriteLine($"Resource name: {resource.Name}");

                foreach (var license in resource.Licenses)
                {
                    Console.WriteLine($"License: {license.Name}");
                }
            }
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

            currentCourse.Resources.Add(new Resource($"Resource{i}", (ResourseType)types[random.Next(0, types.Length)], $"URL {i}", new License($"lincese {i}")));
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
