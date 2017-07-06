using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08.Raw_Data
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Car> cars = new List<Car>();
            string input;

            for (int i = 0; i < n; i++)
            {
                input = Console.ReadLine();
                var tokens = input.Split();

                string model = tokens[0];
                Engine engine = new Engine(int.Parse(tokens[1]), int.Parse(tokens[2]));
                Cargo cargo = new Cargo(int.Parse(tokens[3]), tokens[4]);
                List<Tire> tires = new List<Tire>();

                string[] tiresString = tokens.Skip(5).ToArray();

                for (int b = 0; b < tiresString.Length; b+=2)
                { 
                    double pressure = double.Parse(tiresString[b]);
                    int age = int.Parse(tiresString[b + 1]);

                    Tire tire = new Tire(age, pressure);
                    tires.Add(tire);
                }

                cars.Add(new Car(model, engine, cargo, tires));               
            }

            input = Console.ReadLine();

            switch (input)
            {
                case "fragile":
                    var output = cars.Where(c => c.Cargo.Type == "fragile" && c.Tires.Any(p => p.Pressure < 1))
                        .ToList();
                    output.ForEach(m => Console.WriteLine(m.Model));
                    break;
                case "flamable":
                    cars.Where(c => c.Cargo.Type == "flamable" && c.Engine.Power > 250)
                        .ToList()
                        .ForEach(m => Console.WriteLine(m.Model));
                    break;
                default:
                    break;
            }
        }
    }
}
