using PlanckConstant.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanckConstant
{
    class Program
    {
        static void Main(string[] args)
        {
            Calculation calculation = new Calculation();
            calculation.Reduced(calculation.pk, calculation.Pi);
        }
    }
}
