using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08.Raw_Data
{
    public class Engine
    {
        int speed;
        int power;

        public Engine(int speed, int power)
        {
            this.speed = speed;
            this.power = power;
        }

        public int Speed { get { return this.speed; } set { this.speed = value; } }
        public int Power { get { return this.power; } set { this.power = value; } }
    }
}
