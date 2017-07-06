using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Class_Box
{
    public class Box
    {
        private double length;
        private double width;
        private double height;

        public Box(double l, double w, double h)
        {
            this.length = l;
            this.width = w;
            this.height = h;
        }

        public double Length { get { return this.length; } set { this.length = value; } }
        public double Width { get { return this.width; } set { this.width = value; } }
        public double Height { get { return this.height; } set { this.height = value; } }

        public override string ToString()
        {
            double surfaceArea = (2 * length * width) + (2 * length * height) + (2 * width * height);
            double leteralArea = (2 * length * height) + (2 * width * height);
            double volume = length * width * height;

            return $"Surface Area - {surfaceArea:F2}\n" +
                   $"Lateral Surface Area - {leteralArea:f2}\n" +
                   $"Volume - {volume:f2}";
        }

    }
}
