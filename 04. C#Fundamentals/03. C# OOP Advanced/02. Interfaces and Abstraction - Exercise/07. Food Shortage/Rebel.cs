using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.Food_Shortage
{
    public class Rebel : IBuyer
    {
        private string name;
        private int age;
        private string group;
        private int food;

        public Rebel(string[] tokens)
        {
            this.Name = tokens[0];
            this.Age = int.Parse(tokens[1]);
            this.Group = tokens[2];
            this.food = 0;
        }

        public string Name { get { return this.name; }
            private set
            {
                this.name = value;
            }
        }

        public int Age { get { return this.age; }
            private set
            {
                this.age = value;
            }
        }

        public string Group { get { return this.group; }
            private set
            {
                this.group = value;
            }
        }

        public int Food
        {
            get { return this.food; }

            set { this.food = value; }
        }

        public void BuyFood()
        {
            this.Food += 5;
        }
    }
}
