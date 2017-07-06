using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _14.Cat_Lady
{
    public class Cymric : Cat
    {
        private double furLength;

        public Cymric(string name, double furLength)
        {
            this.Name = name;
            this.furLength = furLength;
        }

        public double FurLength { get { return this.furLength; } set { this.furLength = value; } }

        public override string ToString()
        {
            return $"Cymric {Name} {FurLength:F2}";
        }
    }
}
