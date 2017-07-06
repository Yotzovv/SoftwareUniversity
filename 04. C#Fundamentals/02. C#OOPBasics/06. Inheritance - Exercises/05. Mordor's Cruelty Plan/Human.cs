using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.Mordor_s_Cruelty_Plan
{
    public class Human
    {
        private string name;
        private Mood mood = new Mood();

        public Human(string name)
        {
            this.name = name;
        }

        public string Name { get { return this.name; }
        set
            {
                this.name = value;
            }
        }

        public Mood Mood { get { return this.mood; } }

        public void Eat(Food food)
        {
            this.mood.Points += food.Points;
        }
    }
}
