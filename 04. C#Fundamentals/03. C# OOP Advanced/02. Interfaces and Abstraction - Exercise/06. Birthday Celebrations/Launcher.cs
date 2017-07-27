using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.Birthday_Celebrations
{
    class Launcher
    {
        static void Main(string[] args)
        {
            List<Human> citizens = new List<Human>();
            List<Pet> pets = new List<Pet>();
            string input;

            while ((input = Console.ReadLine()) != "End")
            {
                var tokens = input.Split();
                
                switch(tokens[0])
                {
                    case "Citizen":
                        citizens.Add(new Human(tokens));
                        break;
                    case "Pet":
                        pets.Add(new Pet(tokens));
                        break;
                }
            }

            string year = Console.ReadLine();

            citizens.Where(c => c.Birthdate.EndsWith(year))
                    .ToList()
                    .ForEach(c => Console.WriteLine(c));

            pets.Where(p => p.Birthdate.EndsWith(year))
                .ToList()
                .ForEach(p => Console.WriteLine(p));
        }
    }
}
