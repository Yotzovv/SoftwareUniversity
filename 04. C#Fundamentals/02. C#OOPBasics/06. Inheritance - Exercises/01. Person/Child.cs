using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Person
{
    public class Child : Person
    {
        private string name;
        private int age;

        public Child(string name, int age) : base(name, age)
        {
            this.Age = age;
        }

        public new int Age { get { return this.age; }
        set
            {
                if(value > 15)
                {
                    throw new ArgumentException("Child\'s age must be less than 15!");
                }
                this.age = value;
            }
        }


    }
}
