using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.Pizza_Calories
{
    public class Pizza
    {
        private string name;
        private List<Topping> toppings;
        private Dough dough;

        public Pizza(string name, Dough dough)
        {
            this.name = name;
            this.dough = dough;
            this.toppings = new List<Topping>();
        }

        public int ToppingsCount { get { return toppings.Count; } }

        public double Calories { get { return this.PizzaCalories(); } }

        private List<Topping> Toppings
        {
            get { return toppings; }
            set { toppings = value; }
        }

        public string Name
        {
            get { return this.name; }
            private set
            {
                if(string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Pizza name should be between 1 and 15 symbols.");
                }

                name = value;
            }
        }

        public Dough Dough
        {
            get { return this.dough; }
            set { dough = value; }
        }

        private double PizzaCalories()
        {
            double calories = this.Dough.GetCalories() + this.toppings.Sum(x => x.Calories());

            return calories;
        }

        public void AddTopping(Topping topping)
        {
            this.Toppings.Add(topping);
        }

        public override string ToString()
        {
            return $"{this.Name} - {this.PizzaCalories():f2} Calories.";
        }
    }
}
