using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _14.Cat_Lady
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Cat> cats = new List<Cat>();
            string input;

            while((input = Console.ReadLine()) != "End")
            {
                var tokens = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                string breed = tokens[0];
                string name = tokens[1];
                string param = tokens[2];

                switch(breed)
                {
                    case "Siamese":
                        cats.Add(new Siamese(name, int.Parse(param)));
                        break;
                    case "Cymric":
                        cats.Add(new Cymric(name, double.Parse(param)));
                        break;
                    case "StreetExtraordinaire":
                        cats.Add(new StreetExtraordinaire(name, int.Parse(param)));
                        break;
                }
            }

            input = Console.ReadLine().Trim();
            var seeCat = cats.FirstOrDefault(c => c.Name == input);

            Console.WriteLine(seeCat);
        }
    }
}
