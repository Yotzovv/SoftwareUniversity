using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12.Google
{
    public class Car
    {
        private string model;
        private int speed;

        public Car(string model, int speed)
        {
            this.model = model;
            this.speed = speed;
        }

        public Car()
        {
        }

        public string Model { get { return this.model; } set { this.model = value; } }
        public int Speed { get { return this.speed; } set { this.speed = value; } }

        public override string ToString()
        {
            return $"{model} {speed}";
        }
    }
}
