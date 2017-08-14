using System;
using System.Collections.Generic;
using System.Linq;

namespace Skeleton.Models
{
    public class ExtendedDatabase
    {
        private List<Person> people;

        public ExtendedDatabase(params Person[] people)
        {
            this.people = new List<Person>();
            people.ToList().ForEach(p => this.Add(p));
        }

        public void Add(Person person)
        {
            if(people.Any(u => u.Username == person.Username))
            {
                throw new InvalidOperationException("Username is already in use.");
            }

            if(people.Any(u => u.Id == person.Id))
            {
                throw new InvalidOperationException("Id is already taken.");
            }

            people.Add(person);
        }

        public void Remove(string username)
        {
            if(!people.Any(p => p.Username == username))
            {
                throw new InvalidOperationException($"Username \"{username}\" does not current in the database!");
            }

            people.Remove(people.First(u => u.Username == username));
        }
        
        public void FindByUsername(string username)
        {
            if(username.All(char.IsWhiteSpace) || username == null)
            {
                throw new ArgumentNullException("Please enter valid username!");
            }

            if(!people.Any(u => u.Username == username))
            {
                throw new InvalidOperationException($"There is no user with username \"{username}\"");
            }

            Console.WriteLine(people.First(u => u.Username == username));
        }

        public void FindById(int id)
        {
            if(id < 0)
            {
                throw new ArgumentOutOfRangeException("Id needs to be positive!");
            }

            if(!people.Any(u => u.Id == id))
            {
                throw new InvalidOperationException($"No user with id \"{id}\"");
            }

            Console.WriteLine(people.First(i => i.Id == id));
        }

    }
}
