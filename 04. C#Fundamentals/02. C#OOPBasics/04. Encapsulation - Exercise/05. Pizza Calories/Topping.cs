using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.Pizza_Calories
{
    public class Topping
    {
        private string toppingType;
        private int weight;

        public Topping(string toppingType, int weight)
        {
            this.ToppingType = toppingType;
            this.Weight = weight;
        }

        private string ToppingType
        {
            get { return this.toppingType; }
            set
            {
                if ((value.ToLower() != "meat" && value.ToLower() != "veggies" && value.ToLower() != "cheese" && value.ToLower() != "sauce") || string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException($"Cannot place {value} on top of your pizza.");
                }

                this.toppingType = value;
            }
        }

        public int Weight
        {
            get { return this.weight; }
            set
            {
                if(value < 1 || value > 50)
                {
                    throw new ArgumentException($"{this.toppingType} weight should be in the range [1..50].");
                }

                this.weight = value;
            }
        }

        public double Calories()
        {
            double caloriesPerGram = 2;
            double doughWieght = caloriesPerGram * this.weight;

            double modifier = 0;

            switch (this.toppingType.ToLower())
            {
                case "meat":
                    modifier = 1.2;
                    break;
                case "veggies":
                    modifier = 0.8;
                    break;
                case "cheese":
                    modifier = 1.1;
                    break;
                case "sauce":
                    modifier = 0.9;
                    break;
            }
            doughWieght *= modifier;
            
            return doughWieght;
        }

    }
}
