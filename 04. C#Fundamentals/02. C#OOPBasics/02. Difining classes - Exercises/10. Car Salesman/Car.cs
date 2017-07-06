using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10.Car_Salesman
{
    public class Car
    {
        private string model;
        private Engine engine;
        private double? weight;
        private string color;

        public Car(string model, Engine engine, double? weight, string color)
        {
            this.model = model;
            this.engine = engine;
            this.weight = weight;
            this.color = color ?? "n/a";
        }

        public string Model { get { return this.model; } set { this.model = value; } }
        public Engine Engine { get { return this.engine; } set { this.engine = value; } }
        public double? Weight { get { return this.weight; } set { this.weight = value; } }
        public string Color { get { return this.color; } set { this.color = value; } }

        public override string ToString()
        {
            string w = weight == null ? "n/a" : weight.ToString();
            string e = engine.Efficiency == null ? "n/a" : engine.Efficiency.ToString();
            string d = engine.Displacement == null ? "n/a" : engine.Displacement.ToString();

            return $"{model}:\n  {engine.Model}:\n    Power: {engine.Power}\n    Displacement: {d}\n    Efficiency: {e}\n  Weight: {w}\n  Color: {color}";
        }
    }
}
