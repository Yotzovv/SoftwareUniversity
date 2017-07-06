using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10.Car_Salesman
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Engine> engines = new List<Engine>();

            for (int i = 0; i < n; i++)
            {
                var tokens = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                string model = tokens[0];
                int power = int.Parse(tokens[1]);
                int? displacement = null;
                string efficiency = "n/a";

                if(tokens.Length == 3)
                {
                    if (tokens[2].All(char.IsDigit))
                    {
                        displacement = int.Parse(tokens[2]);
                    }
                    else
                    {
                        efficiency = tokens[2];
                    }
                }
                else if(tokens.Length == 4)
                {
                    displacement = int.Parse(tokens[2]);
                    efficiency = tokens[3];
                }
                Engine engine = new Engine(model, power, displacement, efficiency);
                engines.Add(engine);                   
            }

            int m = int.Parse(Console.ReadLine());
            List<Car> cars = new List<Car>();

            for (int i = 0; i < m; i++)
            {
                var tokens = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                string model = tokens[0];
                Engine engine = engines.FirstOrDefault(mo => mo.Model == tokens[1]);
                double? weight = null;
                string color = null;

                if(tokens.Length == 3)
                {
                    if(tokens[2].All(char.IsDigit))
                    {
                        weight = double.Parse(tokens[2]);
                    }
                    else
                    {
                        color = tokens[2];
                    }
                }
                else if(tokens.Length == 4)
                {
                    weight = double.Parse(tokens[2]);
                    color = tokens[3];
                }

                cars.Add(new Car(model, engine, weight, color));
            }

            foreach (var car in cars)
            {
                Console.WriteLine(car.ToString());
            }
        }
    }
}
