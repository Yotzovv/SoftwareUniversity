using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.Speed_Racing
{
    public class Car
    {
        string model;
        double fuelAmount;
        double fuelConsumption;
        int distanceTraveled;

        public string Model { get { return this.model; } set { this.model = value; } }
        public double FuelAmount { get { return fuelAmount; } set { fuelAmount = value; } }
        public double FuelConsumption { get { return fuelConsumption; } set { fuelConsumption = value; } }
        public int DistanceTraveled { get { return this.distanceTraveled; } set { this.DistanceTraveled = value; } }

        public Car(string model, double currfuelAmount, double fuelConsumptionForKm)
        {
            this.model = model;
            fuelAmount = currfuelAmount;
            fuelConsumption = fuelConsumptionForKm;
            this.distanceTraveled = 0;
        }

        public bool CanTravelDistance(int kmToTravel)
        {
            double fuelNeeded = kmToTravel * fuelConsumption;

            if (fuelNeeded > fuelAmount)
            {
                return false;
            }

            MoveCar(fuelNeeded, kmToTravel);

            return true;
        }

        private void MoveCar(double fuelNeeded, int kmToTravel)
        {
            distanceTraveled += kmToTravel;
            fuelAmount -= fuelNeeded;
        }
    }
}
