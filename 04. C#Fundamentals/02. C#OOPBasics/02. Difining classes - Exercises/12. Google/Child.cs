using System;

namespace _12.Google
{
    public class Child
    {
        private string name;
        private string birthday;

        public Child(string name, string birthday)
        {
            this.name = name;
            this.birthday = birthday;
        }

        public string Name { get { return this.name; } set { this.name = value; } }
        public string Birthday { get { return this.birthday; } set { this.birthday = value; } }

        public override string ToString()
        {
            return $"{name} {birthday}";
        }
    }
}