using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirs.Models
{
    public class Person
    {
        public string name { get; set; }
        public int age { get; set; }

        public Person(string name, int age)
        {
            this.name = name;
            this.age = age;
        }

        public Person()
            : this("No name", 1) {}

        public Person(int age) : this("No name", age)
        {
        }

        public Person(string name) : this(name, 1)
        {
        }
    }
}
