using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanckConstant.Models
{
    class Calculation
    {
        public double pk = 6.62606896e-34;
        public double Pi = 3.1459;

        public void Reduced(double pk, double Pi)
        {
            double reduced = pk / (2 * Pi);
            Console.WriteLine(reduced);
        }
    }
}
