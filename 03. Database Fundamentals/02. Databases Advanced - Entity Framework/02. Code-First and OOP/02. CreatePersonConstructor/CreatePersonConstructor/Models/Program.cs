using CodeFirs.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreatePersonConstructor
{
    class Program
    {
        static void Main(string[] args)
        {
            Person person4 = new Person("Pesho", 20);
            Person person3 = new Person("Gosho");
            Person person2 = new Person(43);
            Person person1 = new Person();

            Console.WriteLine($"{person4.name} {person4.age}");
            Console.WriteLine($"{person3.name} {person3.age}");
            Console.WriteLine($"{person2.name} {person2.age}");
            Console.WriteLine($"{person1.name} {person1.age}");
        }
    }
}
