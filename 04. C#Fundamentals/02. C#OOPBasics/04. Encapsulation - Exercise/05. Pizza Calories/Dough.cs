using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.Pizza_Calories
{
    public class Dough
    {
        private string flourType;
        private string bakingTechnique;
        private int weight;

        public Dough(string flourType, string bakingTechnique, int weight)
        {
            this.FlourType = flourType;
            this.BakingTechnique = bakingTechnique;
            this.Weight = weight;
        }


        public string FlourType
        {
            get { return this.flourType; }
            set
            {
                if(value != "white" && value != "wholegrain")
                {
                    throw new ArgumentException("Invalid type of dough.");
                }

                this.flourType = value;
            }
        }

        public string BakingTechnique
        {
            get { return this.bakingTechnique; }
            set
            {
                if(value != "crispy" && value != "chewy" && value != "homemade")
                {
                    throw new ArgumentException("Invalid type of dough.");
                }

                this.bakingTechnique = value;
            }
        }

        public int Weight
        {
            get { return this.weight; }
            set
            {
                if(value < 1 || 200 < value)
                {
                    throw new ArgumentException("Dough weight should be in the range [1..200]");
                }

                this.weight = value;
            }
        }

        public double GetCalories()
        {
            double caloriesPerGram = 2;
            double doughWieght = caloriesPerGram * this.weight;

            double modifier = 0;

            switch(this.flourType)
            {
                case "white":
                    modifier = 1.5;
                    break;
                case "wholegrain":
                    modifier = 1.0;
                    break;
            }
            doughWieght *= modifier;
            
            switch(this.bakingTechnique)
            {
                case "crispy":
                    modifier = 0.9;
                    break;
                case "chewy":
                    modifier = 1.1;
                    break;
                case "homemade":
                    modifier = 1.0;
                    break;
            }
            doughWieght *= modifier;

            return doughWieght;
        }

    }
}
