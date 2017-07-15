using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Wild_farm.Models.Animals
{
    public abstract class Mammal : Animal
    {
        private string livingRegion;

        public Mammal(string name, string type, double weight, string livingRegion)
            : base (name, type, weight)
        {
            this.LivingRegion = livingRegion;
        }

        public string LivingRegion { get { return this.livingRegion; }
            protected set
            {
                this.livingRegion = value;
            }
        }

        public override string ToString()
        {
            return $"{this.GetType().Name}[{this.Name}, {this.Weight}, {this.LivingRegion}, {this.FoodEaten}]";
        }
    }
}
