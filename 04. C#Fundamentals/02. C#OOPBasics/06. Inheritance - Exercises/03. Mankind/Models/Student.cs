using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Mankind.Models
{
    public class Student : Human
    {
        private string facultyNumber;

        public Student(string firstName, string lastName, string facultyNumber)
            : base (firstName, lastName)
        {
            this.FacultyNumber = facultyNumber;
        }

        public string FacultyNumber { get { return this.facultyNumber; }
        private set
            {
                if(value.Length < 5 || value.Length > 10)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidFacultyNumber);
                }

                this.facultyNumber = value;
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("First Name: ").AppendLine(this.FirstName)
              .Append("Last Name: ").AppendLine(this.LastName)
              .Append("Faculty number: ").AppendLine(this.FacultyNumber)
              .AppendLine();

            return sb.ToString();
        }
    }
}
