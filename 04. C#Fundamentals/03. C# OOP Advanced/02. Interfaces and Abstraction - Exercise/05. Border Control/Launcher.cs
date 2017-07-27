using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.Border_Control
{
    class Launcher
    {
        static void Main(string[] args)
        {
            List<ICitizen> citizens = new List<ICitizen>();
            string input;

            while ((input = Console.ReadLine()) != "End")
            {
                var tokens = input.Split();

                if(tokens.Count() == 3)
                {
                    citizens.Add(new Human(tokens));
                }
                else if(tokens.Count() == 2)
                {
                    citizens.Add(new Robot(tokens));
                }
            }

            string fakeId = Console.ReadLine();

            citizens.Where(c => c.Id.EndsWith(fakeId))
                    .ToList()
                    .ForEach(c => Console.WriteLine(c.Id));
        }
    }
}
