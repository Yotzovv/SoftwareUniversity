using _03.Wild_farm.Models.Foods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Wild_farm.Models.Animals
{
    public abstract class Animal
    {
        private string type;
        private string name;
        private double weight;
        private int foodEaten;

        public Animal(string name, string type, double weight)
        {
            this.Type = type;
            this.Name = name;
            this.Weight = weight;
            this.FoodEaten = 0;
        }

        public string Name { get { return this.name; }
            protected set
            {
                this.name = value;
            }
        }

        public string Type { get { return this.type; }
            protected set
            {
                this.type = value;
            }
        }

        public double Weight { get { return this.weight; }
            protected set
            {
                this.weight = value;
            }
        }

        public int FoodEaten { get { return this.foodEaten; }
            protected set
            {
                this.foodEaten = value;
            }
        }

        public void MakeSound()
        {
            switch(this.GetType().Name)
            {
                case "Mouse":
                    Console.WriteLine("SQUEEEAAAK!");
                    break;
                case "Zebra":
                    Console.WriteLine("Zs");
                    break;
                case "Cat":
                    Console.WriteLine("Meowwww");
                    break;
                case "Tiger":
                    Console.WriteLine("ROAAR!!!");
                    break;
            }
        }
        
        public void Eat(Food food)
        {
            if(food is Meet && (this.GetType().Name == "Mouse" || this.GetType().Name == "Zebra"))
            {
                throw new ArgumentException($"{this.GetType().Name}s are not eating that type of food!");
            }

            if(food is Vegetable && this.GetType().Name == "Tiger")
            {
                throw new ArgumentException($"{this.GetType().Name}s are not eating that type of food!");
            }

            this.foodEaten += food.Quantity;
        }
    }
}
