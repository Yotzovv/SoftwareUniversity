using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace _02.Vechicle_Extension
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Vechicle> vechicles = GetInfo();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                try
                {
                    string cmd = input[0].ToLower();
                    string vechicle = input[1];
                    double parameter = double.Parse(input[2]);

                    object vv = Type.GetType($"_02.Vechicle_Extension.{vechicle}");

                    Vechicle currentVechicle = vechicles.FirstOrDefault(v => v.GetType().Name == vechicle);


                    switch (cmd)
                    {
                        case "drive":
                            currentVechicle.Drive(parameter);
                            break;
                        case "refuel":
                            currentVechicle.Refule(parameter);
                            break;
                        case "driveempty":
                            (currentVechicle as Bus).DriveEmpty(parameter);
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

            vechicles.ForEach(v => Console.WriteLine(v));
        }

        public static List<Vechicle> GetInfo()
        {
            string[] input = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            double fuelQuantity = double.Parse(input[1]);
            double fuelConsumption = double.Parse(input[2]);
            double tank = double.Parse(input[3]);
            Vechicle car = new Car(fuelQuantity, fuelConsumption, tank);

            input = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            fuelQuantity = double.Parse(input[1]);
            fuelConsumption = double.Parse(input[2]);
            tank = double.Parse(input[3]);
            Vechicle truck = new Truck(fuelQuantity, fuelConsumption, tank);

            input = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            fuelQuantity = double.Parse(input[1]);
            fuelConsumption = double.Parse(input[2]);
            tank = double.Parse(input[3]);
            Vechicle bus = new Bus(fuelQuantity, fuelConsumption, tank);

            List<Vechicle> vechicles = new List<Vechicle>();
            vechicles.Add(car);
            vechicles.Add(truck);
            vechicles.Add(bus);

            return vechicles;
        }
    }
}
