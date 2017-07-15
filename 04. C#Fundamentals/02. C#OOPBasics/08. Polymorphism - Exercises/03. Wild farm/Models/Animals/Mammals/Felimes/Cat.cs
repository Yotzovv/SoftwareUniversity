using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Wild_farm.Models.Animals
{
    public class Cat : Felime
    {
        private string breed;

        public Cat(string name, string type, string breed, double weight, string livingRegion)
            : base (name, type, weight, livingRegion)
        {
            this.Breed = breed;
        }

        public string Breed { get { return this.breed; }
            private set
            {
                this.breed = value;
            }
        }

        public override string ToString()
        {
            return $"{this.GetType().Name}[{this.Name}, {this.Breed}, {this.Weight}, {this.LivingRegion}, {this.FoodEaten}]";
        }
    }
}
