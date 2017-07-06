using _06.Animals.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.Animals
{
    class Program
    {
        static void Main(string[] args)
        {
            string animal;
            List<Animal> animals = new List<Animal>();

            while((animal = Console.ReadLine()) != "Beast!")
            {
                var tokens = Console.ReadLine().ToLower().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                try
                {
                    string name = tokens[0];
                    int age = int.Parse(tokens[1]);
                    string gender = tokens[2];

                    switch (animal.ToLower())
                    {
                        case "dog":
                            animals.Add(new Dog(name, age, gender));
                            break;
                        case "cat":
                            animals.Add(new Cat(name, age, gender));
                            break;
                        case "frog":
                            animals.Add(new Frog(name, age, gender));
                            break;
                        case "kitten":
                            animals.Add(new Kitten(name, age, gender));
                            break;
                        case "tomcat":
                            animals.Add(new Tomcat(name, age, gender));
                            break;
                    }
                }
                catch
                {
                    Console.WriteLine("Invalid input!");
                }
            }

            animals.ForEach(a => Console.WriteLine(a));
        }
    }
}
