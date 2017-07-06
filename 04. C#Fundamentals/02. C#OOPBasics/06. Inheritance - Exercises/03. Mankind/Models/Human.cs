using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Mankind.Models
{
    public class Human
    {
        private string firsName;
        private string lastName;

        public Human(string firstName, string lastName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
        }

        public string FirstName { get { return this.firsName; }
        protected set
            {
                if(char.IsLower(value[0]))
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.ExpectedUpcase, "firstname"));
                }

                if(value.Length <= 3)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.ExpectedLength, "at least", "4", "firstname"));
                }

                this.firsName = value;
            }
        }

        public string LastName { get { return this.lastName; }
        protected set
            {
                if(char.IsLower(value[0]))
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.ExpectedUpcase, "lastName"));
                }

                if(value.Length  <= 2)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.ExpectedLength, "at least", "3", "lastName"));
                }

                this.lastName = value;
            }
         }
    }
}
