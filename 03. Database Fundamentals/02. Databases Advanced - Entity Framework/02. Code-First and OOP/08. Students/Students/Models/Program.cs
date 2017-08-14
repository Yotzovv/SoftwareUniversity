using Students.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Students
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            Student student = new Student();
            student.names = new List<string>();

            while(!name.Contains("End"))
            {
                student.names.Add(name);
                name = Console.ReadLine();
            }

            student.InstancesCount(student.names);
        }
    }
}
