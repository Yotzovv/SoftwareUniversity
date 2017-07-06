using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.Company_Roster
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Employee> employees = new List<Employee>();

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split();

                string name = input[0];
                decimal salary = decimal.Parse(input[1]);
                string position = input[2];
                string department = input[3];
                string email = string.Empty;
                int? age = -1;

                if (input.Length == 4)
                {
                    email = "n/a";
                    age = -1;
                }
                else if(input.Length == 5)
                {
                    if(input.Last().All(char.IsDigit))
                    {
                        age = int.Parse(input.Last());
                        email = "n/a";
                    }
                    else
                    {
                        age = -1;
                        email = input.Last();
                    }
                }
                else
                {
                    email = input[4];
                    age = int.Parse(input[5] ?? "-1");
                } 


                Employee employee = new Employee(name, salary, position, department, email, age);
                employees.Add(employee);
            }

            var highestAVGdep = employees.GroupBy(d => d.Department)
                                   .Select(g => new { Department = g.Key, Avg = g.Average(e => e.Salary) })
                                   .OrderByDescending(avg => avg.Avg).First().Department;

            var output = employees.Where(d => d.Department == highestAVGdep)
                                  .Select(o => new { o.Name, o.Salary, o.Email, o.Age })
                                  .OrderByDescending(s => s.Salary);


            Console.WriteLine($"Highest Average Salary: {highestAVGdep}");
            output.ToList()
                  .ForEach(c => Console.WriteLine($"{c.Name} {c.Salary:f2} {c.Email} {c.Age}"));
        }
    }
}
