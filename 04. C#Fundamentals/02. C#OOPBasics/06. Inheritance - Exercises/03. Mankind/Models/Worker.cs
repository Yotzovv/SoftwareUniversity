using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Mankind.Models
{
    public class Worker : Human
    {
        private decimal weekSalary;
        private int workingHours;

        public Worker(string firstName, string lastName, decimal weekSalary, int workingHours)
            : base (firstName, lastName)
        {
            this.LastName = lastName;
            this.WeekSalary = weekSalary;
            this.WorkingHours = workingHours;
        }

        public new string LastName { get { return base.LastName; }
            set
            {
                if(value.Length <= 3)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.ExpectedLength, "more than", "3", "lastName"));
                }

                base.LastName = value;
            }
        }

        public decimal WeekSalary { get { return this.weekSalary; }
        private set
            {
                if(value < 10)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidValue, "weekSalary"));
                }

                this.weekSalary = value;
            }
        }

        public int WorkingHours
        {
            get { return this.workingHours; }
            private set
            {
                if(value < 1 || 12 < value)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidValue, "workHoursPerDay"));
                }

                this.workingHours = value;
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            decimal salaryForHour = (weekSalary / 5) / workingHours;

            sb.Append("First Name: ").AppendLine(this.FirstName)
              .Append("Last Name: ").AppendLine(this.LastName)
              .Append("Week Salary: ").AppendLine($"{WeekSalary:F2}")
              .Append("Hours per day: ").AppendLine($"{WorkingHours:F2}")
              .Append("Salary per hour: ").AppendLine($"{salaryForHour:F2}");

            return sb.ToString();            
        }
    }
}
