using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Vehicles
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] carInput = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            string[] truckInput = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            double fuelQuantity = double.Parse(carInput[1]);
            double fuelConsumption = double.Parse(carInput[2]);

            Vechicle car = new Car(fuelQuantity, fuelConsumption);

            fuelQuantity = double.Parse(truckInput[1]);
            fuelConsumption = double.Parse(truckInput[2]);

            Vechicle truck = new Truck(fuelQuantity, fuelConsumption);

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                try
                {
                    string cmd = input[0].ToLower();
                    string vechicle = input[1].ToLower();
                    double parameter = double.Parse(input[2]);

                    Vechicle currentVechicle = vechicle == "car" ? car : truck;

                    switch (cmd)
                    {
                        case "drive":
                            currentVechicle.Drive(parameter);
                            break;
                        case "refuel":
                            currentVechicle.Refule(parameter);
                            break;
                        default:
                            break;
                    }
                }
                catch(Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            Console.WriteLine(car);
            Console.WriteLine(truck);
        }
    }
}
