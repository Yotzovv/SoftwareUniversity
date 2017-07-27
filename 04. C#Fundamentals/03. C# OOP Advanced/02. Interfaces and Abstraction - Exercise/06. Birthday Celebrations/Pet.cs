using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.Birthday_Celebrations
{
    public class Pet
    {
        private string name;
        private string birthday;

        public Pet(string[] tokens)
        {
            this.Name = tokens[1];
            this.Birthdate = tokens[2];
        }

        public string Name { get { return this.name; }
            private set
            {
                this.name = value;
            }
        }

        public string Birthdate { get { return this.birthday; }
            private set
            {
                this.birthday = value;
            }
        }

        public override string ToString()
        {
            string[] bd = birthday.Split('/');

            return $"{bd[0]}/{bd[1]}/{bd[2]}";
        }
    }
}
