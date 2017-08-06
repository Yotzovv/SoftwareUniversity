using System;

namespace _05.ComparingObjs.Models
{
    public class Person : IComparable<Person>
    {
        public Person(string name, int age, string town)
        {
            this.Name = name;
            this.Age = age;
            this.Town = town;
        }

        public string Name { get; private set; }

        public int Age { get; private set; }

        public string Town { get; private set; }

        public int CompareTo(Person other)
        {
            if(this.Name == other.Name && this.Age == other.Age && this.Town == other.Town)
            {
                return 0;
            }

            return 1;
        }
    }
}
