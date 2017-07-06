using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.Speed_Racing
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

                string model = input.Split()[0];
                int fuelAmount = int.Parse(input.Split()[1]);
                double fuelConsumption = double.Parse(input.Split()[2]);

                cars.Add(new Car(model, fuelAmount, fuelConsumption));
            }

            while((input = Console.ReadLine()) != "End")
            {
                var model = input.Split()[1];
                int kmToTravel = int.Parse(input.Split()[2]);
                Car car = cars.FirstOrDefault(m => m.Model == model);

                if(!car.CanTravelDistance(kmToTravel))
                {
                    Console.WriteLine("Insufficient fuel for the drive");
                }             
            }

            cars.ForEach(c => Console.WriteLine($"{c.Model} {c.FuelAmount:f2} {c.DistanceTraveled}"));
        }
    }
}
