using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12.Google
{
    public class Person
    {
        private string name;
        private Company company = new Company();
        private List<Pokemon> pokemons = new List<Pokemon>();
        private List<Parent> parents = new List<Parent>();
        private List<Child> children = new List<Child>();
        private Car car = new Car();

        public Person(string name, Company company, Pokemon pokemon, Parent parent, Child child, Car car)
        {
            this.name = name;
            this.company = company;
            this.pokemons.Add(pokemon);
            this.parents.Add(parent);
            this.children.Add(child);
            this.car = car;
        }

        public string Name { get { return this.name; } set { this.name = value; } }
        public Company Company { get { return this.company; } set { this.company = value; } }
        public List<Pokemon> Pokemons { get { return this.pokemons; } set { this.pokemons = value; } }
        public List<Parent> Parents { get { return this.parents; } set { this.parents = value; } }
        public List<Child> Children { get { return this.children; } set { this.children = value; } }
        public Car Car { get { return this.car; } set { this.car = value; } }

        public override string ToString()
        {
            string pokemons = string.Join("\n", this.pokemons.Where(p => p.Name != string.Empty && p.Type != string.Empty));
            string parents = string.Join("\n", this.parents.Where(p => p.Name != string.Empty && p.Birthday != string.Empty));
            string children = string.Join("\n", this.children.Where(c => c.Name != string.Empty && c.Birthday != string.Empty));

            return
                    $"{name}" +
                    $"\nCompany:\n{company}".TrimEnd() +
                    $"\nCar:\n{car}\n".TrimEnd() +
                    $"\nPokemon:\n{pokemons}".TrimEnd() +
                    $"\nParents:\n{parents}".TrimEnd() +
                    $"\nChildren:\n{children}".TrimEnd();
        }
    }
}
