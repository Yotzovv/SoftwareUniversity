using System;
using System.Globalization;

namespace _06.Birthday_Celebrations
{
    public class Human : ICitizen
    {
        private string name;
        private int age;
        private string id;
        private string birthday;

        public Human(string[] tokens)
        {
            this.Name = tokens[1];
            this.Age = int.Parse(tokens[2]);
            this.Id = tokens[3];
            this.Birthdate = tokens[4];
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

        public override string ToString()
        {
            string[] bd = birthday.Split('/');

            return $"{bd[0]}/{bd[1]}/{bd[2]}";
        }
    }
}
