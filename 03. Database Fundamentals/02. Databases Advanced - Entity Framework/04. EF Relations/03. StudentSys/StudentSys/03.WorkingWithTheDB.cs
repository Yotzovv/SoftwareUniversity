using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentSys
{
    class WorkingWithTheDB
    {
        static void Main(string[] args)
        {
            SystemContext context = new SystemContext();
            Console.WriteLine("1.Students homeworks\r\n2.Courses\r\n3.Courses with more than 5 resources\r\n4.Active courses\r\n5.Students courses");
            Console.WriteLine();
            Console.Write("Enter option: ");
            string cmd = Console.ReadLine();

            while(!cmd.Contains("quit"))
            {
                if(cmd.Equals("1"))
                {
                    foreach (var student in context.Students)
                    {
                        Console.WriteLine(student.Name);

                        foreach (var homework in context.Homeworks.Where(s => s.StudentId == student.Id))
                        {
                            Console.WriteLine("-------------------------------");
                            Console.WriteLine($"{homework.Content}.{homework.ContentType}");
                            Console.WriteLine();
                        }
                    }
                }
                else if(cmd.Equals("2"))
                {
                    foreach (var course in context.Courses.OrderBy(a => a.StartDate).ThenByDescending(b => b.EndDate))
                    {
                        Console.WriteLine($"Course: {course.Name}");
                        Console.WriteLine($"Course Discription: {course.Discription}");

                        foreach (var resource in course.Resources)
                        {
                            Console.WriteLine($"Resource Name: {resource.Name}");
                            Console.WriteLine($"Resource type: {resource.RecourseType.ToString()}");
                            Console.WriteLine($"Resource URL: {resource.URL}");
                            Console.WriteLine();
                        }
                    }
                }
                else if(cmd.Equals("3"))
                {
                    if(!(context.Courses.Any(a => a.Resources.Count() > 5)))
                    {
                        Console.WriteLine("Seed the database.");
                    }
                    else
                    {
                        foreach (var course in context.Courses.Where(a => a.Resources.Count() > 5).OrderByDescending(c => c.Resources.Count()).ThenByDescending(s => s.StartDate))
                        {
                            Console.WriteLine("Course Name: " + course.Name);
                            Console.WriteLine($"Resource count: {course.Resources.Count()}");
                            Console.WriteLine();
                        }
                    }                   
                }
                else if(cmd.Equals("4"))
                {
                    Console.Write("Enter date in format \"dd-MM-yyy\": ");
                    DateTime activeCourse = DateTime.ParseExact(Console.ReadLine(), "dd-MM-yyyy", CultureInfo.InvariantCulture);
                    
                    if(!(context.Courses.Any(a => a.StartDate <= activeCourse && a.EndDate >= activeCourse)))
                    {
                        Console.WriteLine("No active courses.");
                    }
                    else
                    {
                        foreach (var course in context.Courses.Where(a => a.StartDate <= activeCourse && activeCourse <= a.EndDate))
                        {
                            int monthsDiff = course.EndDate.Month - course.StartDate.Month;
                            int daysDiff = (course.EndDate.DayOfYear - course.StartDate.DayOfYear);
                            int students = 0;
                            foreach (var hui in context.StudentCourses.Where(a => a.Course_Id == course.Id))
                            {
                                students++;
                            }

                            Console.WriteLine($"Course Name: {course.Name}");
                            Console.WriteLine($"Start date: {course.StartDate}\r\nEnd date: {course.EndDate}");
                            Console.WriteLine($"Course duration: {monthsDiff} months({daysDiff} days)");                           
                            Console.WriteLine($"Students: {students}");
                            Console.WriteLine();
                        }
                    }
                }
                else if(cmd.Equals("5"))
                {
                    foreach (var student in context.Students)
                    {
                        int kurs = 0;
                        List<decimal> prices = new List<decimal>();

                        foreach (var course in context.StudentCourses.Where(a => a.Student_Id == student.Id))
                        {
                            kurs++;
                            foreach (var price in context.Courses)
                            {
                                prices.Add(price.Price);
                            }
                        }

                        Console.WriteLine($"{student.Name}");
                        Console.WriteLine("Number of courses: " + kurs);
                        Console.WriteLine($"Total price: {prices.Sum()}");
                        Console.WriteLine($"Average price: {prices.Average()}");
                    }
                }

                Console.Write("Enter option: ");
                cmd = Console.ReadLine();
            }
        }
    }
}
