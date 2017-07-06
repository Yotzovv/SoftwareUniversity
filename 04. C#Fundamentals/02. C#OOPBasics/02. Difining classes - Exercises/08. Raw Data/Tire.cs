using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08.Raw_Data
{
    public class Tire
    {
        int age;
        double pressure;

        public Tire(int age, double pressure)
        {
            this.age = age;
            this.pressure = pressure;
        }

        public int Age { get { return this.age; } set { this.age = value; } }
        public double Pressure { get { return this.pressure; } set { this.pressure = value; } }
    }
}
