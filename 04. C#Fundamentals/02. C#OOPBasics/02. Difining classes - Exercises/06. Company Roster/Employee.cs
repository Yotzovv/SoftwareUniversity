using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.Company_Roster
{
    public class Employee
    {
        string name;
        decimal salary;
        string position;
        string department;
        string email;
        int? age;

        public Employee(string name, decimal salary, string position, string department, string email, int? age)
        {
            this.Name = name;
            this.Salary = salary;
            this.Position = position;
            this.Department = department;
            this.Email = email ?? "n/a";
            this.Age = age ?? -1;
        }

        public string Name { get { return this.name; } set { this.name = value; } }

        public decimal Salary { get { return this.salary; } set { this.salary = value; } }
        
        public string Position { get { return this.position; }  set { this.position = value; } }

        public string Department { get { return this.department; } set { this.department = value; } }

        public string Email { get { return this.email; } set { this.email = value; } }

        public int? Age { get { return this.age; } set { this.age = value; } }
    }
}
