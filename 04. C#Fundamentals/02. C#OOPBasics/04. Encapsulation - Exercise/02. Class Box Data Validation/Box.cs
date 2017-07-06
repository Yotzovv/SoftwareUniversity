using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Class_Box_Data_Validation
{
    public class Box
    {
        private double length;
        private double width;
        private double height;

        public Box(double l, double w, double h)
        {
            this.Length = l;
            this.Width = w;
            this.Height = h;
        }

        public double Length
        {
            get { return this.length; }
            set
            {
                if(value <= 0)
                {
                    throw new ArgumentException("Length cannot be zero or negative.");
                }

                this.length = value;
            }
        }

        public double Width
        {
            get { return this.width; }
            set
            {
                if(value <= 0)
                {
                    throw new ArgumentException("Width cannot be zero or negative.");
                }

                this.width = value;
            }
        }

        public double Height
        {
            get { return this.height; }
            set
            {
                if(value <= 0)
                {
                    throw new ArgumentException("Height cannot be zero or negative.");
                }

                this.height = value;
            }
        }

        public override string ToString()
        {
            double surfaceArea = (2 * length * width) + (2 * length * height) + (2 * width * height);
            double leteralArea = (2 * length * height) + (2 * width * height);
            double volume = length * width * height;

            return $"Surface Area - {surfaceArea:F2}\n" +
                   $"Leteral Surface Area - {leteralArea:f2}\n" +
                   $"Volume - {volume:f2}";
        }

    }
}
