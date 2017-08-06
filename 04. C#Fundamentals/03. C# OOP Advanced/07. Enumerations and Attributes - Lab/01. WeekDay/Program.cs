using System;
using System.Linq;

namespace _01.WeekDay
{
    class Program
    {
        static void Main(string[] args)
        {
            WeeklyCalendar calendar = new WeeklyCalendar();
            calendar.AddEntry("Monday", "Internal meeting");
            calendar.AddEntry("Tuesday", "Create presentation");
            calendar.AddEntry("Tuesday", "Create lab and exercise");
            calendar.AddEntry("Thursday", "Enum Lecture");
            calendar.AddEntry("Monday", "Second internal meeting");

            var ordered = calendar.WeeklySchedule.OrderBy(n => n).ToList();
            foreach (var weeklyEntry in ordered)
            {
                Console.WriteLine(weeklyEntry);
            }
        }
    }
}
