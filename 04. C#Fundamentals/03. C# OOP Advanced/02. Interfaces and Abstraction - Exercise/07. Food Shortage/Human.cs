using System;
using System.Globalization;

namespace _07.Food_Shortage
{
    public class Human : ICitizen, IBuyer
    {
        private string name;
        private int age;
        private string id;
        private string birthday;
        private int food;

        public Human(string[] tokens)
        {
            this.Name = tokens[0];
            this.Age = int.Parse(tokens[1]);
            this.Id = tokens[2];
            this.Birthdate = tokens[3];
            this.food = 0;
        }

        public string Name
        {
            get { return this.name; }
            private set
            {
                this.name = value;
            }
        }

        public int Age
        {
            get { return this.age; }
            private set
            {
                this.age = value;
            }
        }

        public string Id
        {
            get { return this.id; }
            private set
            {
                this.id = value;
            }
        }

        public string Birthdate
        {
            get { return this.birthday; }
            private set
            {
                this.birthday = value;
            }
        }

        public int Food
        {
            get { return this.food; }

            set { this.food = value; }
        }

        public override string ToString()
        {
            string[] bd = birthday.Split('/');

            return $"{bd[0]}/{bd[1]}/{bd[2]}";
        }

        public void BuyFood()
        {
            this.Food += 10;
        }
    }
}
