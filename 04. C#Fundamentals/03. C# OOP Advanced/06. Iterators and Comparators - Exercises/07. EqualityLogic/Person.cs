using System;
using System.Collections.Generic;

namespace _07.EqualityLogic
{
    public class Person : IComparable<Person>
    {
        public Person(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }

        public string Name { get; private set; }

        public int Age { get; private set; }

        public int CompareTo(Person other)
        {
            var result = this.Name.CompareTo(other.Name) == 0 ? this.Age.CompareTo(other.Age) : this.Name.CompareTo(other.Name);

            return result;
        }

        public override bool Equals(object obj)
        {
            Person other = obj as Person;

            return this.Name == other.Name && this.Age == other.Age;
        }

        public override int GetHashCode()
        {
            return (this.Name + this.Age.ToString()).GetHashCode();
        }
    }
}
