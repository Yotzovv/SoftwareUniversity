using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.Shopping_Spree
{
    public class Person
    {
        private string name;
        private decimal money;
        private List<Product> bag = new List<Product>();

        public Person(string name, decimal money)
        {
            this.Name = name;
            this.Money = money;
        }

        public string Name
        {
            get { return this.name; }
            set
            {
                if (string.IsNullOrWhiteSpace(value) || string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Name cannot be empty");
                }

                this.name = value;
            }
        }

        public decimal Money
        {
            get { return this.money; }
            set
            {
                if(value < 0)
                {
                    throw new ArgumentException("Money cannot be negative");
                }

                this.money = value;
            }
        }

        public List<Product> Bag { get { return this.bag; } set { this.bag = value; } }


        public override string ToString()
        {
            string bag = Bag.Count > 0 ? string.Join(", ", Bag).ToString() : "Nothing bought";

            return $"{Name} - {bag}";
        }
    }
}
