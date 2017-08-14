using Softuni.Data;
using Softuni.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Softuni
{
    class Program
    {
        static void Main(string[] args)
        {
            CallAStoredProcedure();
            //EmployeesMaximumSalaries();
        }

        private static void EmployeesMaximumSalaries()
        {
            SoftuniContext context = new SoftuniContext();

            foreach (var department in context.Departments)
            {
                List<decimal> MaxSalary = new List<decimal>();
                
                foreach (var salaries in department.Employees.Select(s => s.Salary))
                {
                    if(salaries < 30000 || salaries > 70000)
                    {
                        MaxSalary.Add(salaries);
                    }
                }
                if(MaxSalary.Count > 0)
                {
                    Console.WriteLine(department.Name);
                    Console.WriteLine($"{MaxSalary.Max():F2}");
                }
                Console.WriteLine();
            }
        }

        private static void CallAStoredProcedure()
        {
            SoftuniContext context = new SoftuniContext();
            string[] name = Console.ReadLine().Split();

            var projects = context.Database.SqlQuery<ProjectViewModel>($"EXEC EmployeeProjects {name[0]}, {name[1]}");

            foreach (var project in projects)
            {
                Console.WriteLine($"{project.Name} - {project.Description}, {project.StartDate}");
                Console.WriteLine();
            }
        }
    }
}
