using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Vehicles
{
    public abstract class Vechicle
    {
        private double fuelQuantity;
        private double fuelConsumption;
         
        public Vechicle(double fuelQuantity, double fuelConsumption)
        {
            this.FuelQuantity = fuelQuantity;
            this.FuelConsumption = fuelConsumption;
        }

        public double FuelQuantity { get { return this.fuelQuantity; }
            protected set
            {
                this.fuelQuantity = value;
            }
        }

        public double FuelConsumption { get { return this.fuelConsumption; }
            protected set
            {
                switch(this.GetType().Name)
                {
                    case "Car":
                        this.fuelConsumption = value + 0.9;
                        break;
                    case "Truck":
                        this.fuelConsumption = value + 1.6;
                        break;
                }
            }
        }

        public void Drive(double km)
        {
            if (this.FuelQuantity - (this.FuelConsumption * km) <= 0)
            {
                throw new ArgumentException($"{this.GetType().Name} needs refueling");
            }

            this.FuelQuantity -= (this.FuelConsumption * km);

            Console.WriteLine($"{this.GetType().Name} travelled {km} km");
        }

        public void Refule(double liters)
        {
            if (this.GetType().Name == "Truck")
            {
                this.FuelQuantity += liters * 0.95;
            }
            else
            {
                this.FuelQuantity += liters;
            }
        }

        public override string ToString()
        {
            return $"{this.GetType().Name}: {this.FuelQuantity:f2}";
        }
    }
}
