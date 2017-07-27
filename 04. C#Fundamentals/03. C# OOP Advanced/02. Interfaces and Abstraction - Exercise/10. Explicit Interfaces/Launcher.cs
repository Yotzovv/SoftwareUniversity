using _10.Explicit_Interfaces.Interfaces;
using _10.Explicit_Interfaces.Models;
using System;

namespace _10.Explicit_Interfaces
{
    class Launcher
    {
        static void Main(string[] args)
        {
            string input;

            while((input = Console.ReadLine()) != "End")
            {
                var tokens = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                string name = tokens[0];
                string country = tokens[1];
                int age = int.Parse(tokens[2]);

                Citizen citizen = new Citizen(name, country, age);
                Console.WriteLine((citizen as IPerson).GetName());
                Console.WriteLine((citizen as IResident).GetName());
            }

        }
    }
}
