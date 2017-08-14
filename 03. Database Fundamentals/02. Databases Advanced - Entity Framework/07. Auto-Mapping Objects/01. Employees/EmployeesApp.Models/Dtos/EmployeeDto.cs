using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeesApp.Models.Dtos
{
    public class EmployeeDto
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public decimal Salary { get; set; }

        public string ManagerLastName { get; set; }

        public override string ToString()
         {
            return $"   - {this.FirstName} {this.LastName}  Manager: {this.ManagerLastName ?? "[no manager]"} {this.Salary:F2}";
        }
    }
}
