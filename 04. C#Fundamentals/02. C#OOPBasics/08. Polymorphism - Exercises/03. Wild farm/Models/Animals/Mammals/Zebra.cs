using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Wild_farm.Models.Animals.Mammals
{
    public class Zebra : Mammal
    {
        public Zebra(string name, string type, double weight, string livingRegion)
            : base (name, type, weight, livingRegion)
        {
        }
    }
}
