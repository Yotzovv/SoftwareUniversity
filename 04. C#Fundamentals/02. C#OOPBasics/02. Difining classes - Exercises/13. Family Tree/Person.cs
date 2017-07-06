using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _13.Family_Tree
{
    public class Person
    {
        string firstName = string.Empty;
        string lastName = string.Empty;
        string birthday = string.Empty;
        HashSet<Person> parents = new HashSet<Person>();
        HashSet<Person> children = new HashSet<Person>();

        public Person(string[] input)
        {
            if (input.Count() == 1)
            {
                this.birthday = input[0];
            }
            else
            {
                this.firstName = input[0];
                this.lastName = input[1];
            }
        }

        public string FirstName { get { return this.firstName; } set { this.firstName = value; } }
        public string LastName { get { return this.lastName; } set { this.lastName = value; } }
        public string Birthday { get { return this.birthday; } set { this.birthday = value; } }
        public HashSet<Person> Parents { get { return this.parents; } set { this.parents = value; } }
        public HashSet<Person> Children { get { return this.children; } set { this.children = value; } }

        public override string ToString()
        {
            return
                   $"{firstName} {lastName} {birthday}" +
                   $"\nParents:\n{string.Join("\n", parents.Select(p => p.FirstName + " " + p.LastName + " " + p.Birthday))}" +
                   $"\nChildren:\n{string.Join("\n", children.Select(p => p.FirstName + " " + p.LastName + " " + p.Birthday))}";

        }
    }
}
