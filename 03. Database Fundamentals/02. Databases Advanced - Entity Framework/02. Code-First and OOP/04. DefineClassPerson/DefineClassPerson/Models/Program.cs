using CodeFirs.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DefineClassPerson
{
    class Program
    {
        static void Main(string[] args)
        {
            Person person1 = new Person("Pesho", 20);
            Person person2 = new Person("Gosho", 18);
            Person person3 = new Person();
            {
                person3.name = "Stamat";
                person3.age = 43;
            }
        }
    }
}
