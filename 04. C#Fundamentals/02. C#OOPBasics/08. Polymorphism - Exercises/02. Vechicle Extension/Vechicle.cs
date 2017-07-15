using System;

namespace _02.Vechicle_Extension
{
    public abstract class Vechicle
    {
        private double fuelQuantity;
        private double fuelConsumption;
        private double tank;

        public Vechicle(double fuelQuantity, double fuelConsumption, double tank)
        {
            this.FuelQuantity = fuelQuantity;
            this.FuelConsumption = fuelConsumption;
            this.Tank = tank;
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
                    case "Bus":
                        this.fuelConsumption = value;
                        break;
                }
            }
        }

        public double Tank { get { return this.tank; }
            protected set
            {
                this.tank = value;
            }
        }

        public virtual void Drive(double km)
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
            if(liters <= 0)
            {
                throw new ArgumentException("Fuel must be a positive number");
            }

            if (this.GetType().Name == "Truck")
            {
                this.FuelQuantity += liters * 0.95;
            }
            else
            {
                if(this.tank < FuelQuantity + liters)
                {
                    throw new ArgumentException("Cannot fit fuel in tank");
                }

                this.FuelQuantity += liters;
            }
        }

        public override string ToString()
        {
            return $"{this.GetType().Name}: {this.FuelQuantity:f2}";
        }
    }
}
