using RecyclingStation.WasteDisposal.Interfaces;
using System;

namespace RecyclingStation.WasteDisposal.Models
{
    public class Waste : IWaste
    {
        public Waste(string name, double volumePerKg, double weight)
        {
            this.Name = name;
            this.VolumePerKg = volumePerKg;
            this.Weight = weight;
        }

        public string Name { get; private set; }

        public double VolumePerKg { get; private set; }

        public double Weight { get; private set; }
    }
}
