using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeesApp.Models.Dtos
{
    public class ManagerDto
    {
        public string FirstName { get; set; }
        
        public string LastName { get; set; }

        public ICollection<EmployeeDto> Employees { get; set; }

        public int EmployeesCount { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"{this.FirstName} {this.LastName} | Employees: {this.EmployeesCount}");
            
            foreach(EmployeeDto employee in this.Employees)
            {
                sb.AppendLine(employee.ToString());
            }

            return sb.ToString();
        }
    }
}
