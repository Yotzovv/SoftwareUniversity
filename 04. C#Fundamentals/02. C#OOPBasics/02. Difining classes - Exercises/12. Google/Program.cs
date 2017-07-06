using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12.Google
{
    class Program
    {
        static void Main(string[] args)
        {
            string input;
            List<Person> people = new List<Person>();

            while ((input = Console.ReadLine()) != "End")
            {
                var tokens = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                string name = tokens[0];
                Company company = new Company(string.Empty, string.Empty, string.Empty);
                Pokemon pokemon = new Pokemon(string.Empty, string.Empty);
                Parent parent = new Parent(string.Empty, string.Empty);
                Child child = new Child(string.Empty, string.Empty);
                Car car = new Car(string.Empty, 0);

                switch (tokens[1])
                {
                    case "company":
                        string companyName = tokens[2];
                        string department = tokens[3];
                        string salary = tokens[4];
                        company = new Company(companyName, department, salary);
                        if (people.Any(p => p.Name == name))
                        {
                            Person person = people.FirstOrDefault(p => p.Name == name);
                            person.Company = company;
                        }
                        else
                        {
                            Person person = new Person(name, company, pokemon, parent, child, car);
                            people.Add(person);
                        }
                        break;
                    case "pokemon":
                        string pokemonName = tokens[2];
                        string type = tokens[3];
                        pokemon = new Pokemon(pokemonName, type);
                        if (people.Any(p => p.Name == name))
                        {
                            Person person = people.FirstOrDefault(p => p.Name == name);
                            person.Pokemons.Add(pokemon);
                        }
                        else
                        {
                            Person person = new Person(name, company, pokemon, parent, child, car);
                            people.Add(person);
                        }
                        break;
                    case "parents":
                        string parentName = tokens[2];
                        string birthday = tokens[3];
                        parent = new Parent(parentName, birthday);
                        if (people.Any(p => p.Name == name))
                        {
                            Person person = people.FirstOrDefault(p => p.Name == name);
                            person.Parents.Add(parent);
                        }
                        else
                        {
                            Person person = new Person(name, company, pokemon, parent, child, car);
                            people.Add(person);
                        }
                        break;
                    case "children":
                        string childName = tokens[2];
                        string childBirthDay = tokens[3];
                        child = new Child(childName, childBirthDay);
                        if (people.Any(p => p.Name == name))
                        {
                            Person person = people.FirstOrDefault(p => p.Name == name);
                            person.Children.Add(child);
                        }
                        else
                        {
                            Person person = new Person(name, company, pokemon, parent, child, car);
                            people.Add(person);
                        }
                        break;
                    case "car":
                        string model = tokens[2];
                        int speed = int.Parse(tokens[3]);
                        car = new Car(model, speed);
                        if (people.Any(p => p.Name == name))
                        {
                            Person person = people.FirstOrDefault(p => p.Name == name);
                            person.Car = car;
                        }
                        else
                        {
                            Person person = new Person(name, company, pokemon, parent, child, car);
                            people.Add(person);
                        }
                        break;
                }
            }
            
            input = Console.ReadLine();

            Person result = people.FirstOrDefault(p => p.Name == input);
            Console.WriteLine(result);
        }
    }
}