using System;

namespace _02.Vechicle_Extension
{
    public class Bus : Vechicle
    {
        public Bus(double fuelQuantity, double fuelConsumption, double tank)
            : base (fuelQuantity, fuelConsumption, tank)
        {
        }

        public override void Drive(double km)
        {
            if (this.FuelQuantity - (this.FuelConsumption * km) <= 0)
            {
                throw new ArgumentException($"{this.GetType().Name} needs refueling");
            }

            this.FuelQuantity -= ((this.FuelConsumption + 1.4) * km);

            Console.WriteLine($"{this.GetType().Name} travelled {km} km");
        }

        public void DriveEmpty(double km)
        {
            if (this.FuelQuantity - (this.FuelConsumption * km) <= 0)
            {
                throw new ArgumentException($"{this.GetType().Name} needs refueling");
            }

            this.FuelQuantity -= (this.FuelConsumption * km);

            Console.WriteLine($"{this.GetType().Name} travelled {km} km");
        }
    }
}
 
