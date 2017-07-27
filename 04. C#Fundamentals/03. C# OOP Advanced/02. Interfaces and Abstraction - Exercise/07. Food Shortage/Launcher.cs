using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.Food_Shortage
{
    class Launcher
    {
        static void Main(string[] args)
        {
            List<Human> citizens = new List<Human>();
            List<Rebel> rebels = new List<Rebel>();
            int n = int.Parse(Console.ReadLine());


            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split();

                if(input.Count() == 3)
                {
                    rebels.Add(new Rebel(input));
                }
                else if(input.Count() == 4)
                {
                    citizens.Add(new Human(input));
                }
            }

            string foodBuyer;
            int result = 0;

            while((foodBuyer = Console.ReadLine()) != "End")
            {
                if(citizens.Any(c => c.Name == foodBuyer))
                {
                    citizens.FirstOrDefault(c => c.Name == foodBuyer).BuyFood();
                    result += 10;
                }                
                else if(rebels.Any(r => r.Name == foodBuyer))
                {
                    rebels.FirstOrDefault(r => r.Name == foodBuyer).BuyFood();
                    result += 5;
                }
            }

            Console.WriteLine(result);
        }
    }
}
