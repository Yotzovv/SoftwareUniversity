using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.Animals.Models
{
    public class Tomcat : Cat
    {
        private string gender;

        public Tomcat(string name, int age, string gender)
            : base (name, age, gender)
        {
            this.Gender = gender;
        }

        public new string Gender { get { return this.gender; }
        private set
            {
                if(value != "male")
                {
                    throw new ArgumentException("Invalid input!");
                }

                this.gender = value;
            }
        }

        public override string ProduceSound()
        {
            return "Give me one million b***h";
        }
    }
}
