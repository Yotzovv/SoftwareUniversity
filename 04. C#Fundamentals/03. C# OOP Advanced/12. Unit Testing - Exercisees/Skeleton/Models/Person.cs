using System;
using Skeleton.Abstraction.Interfaces;

namespace Skeleton.Models
{
    public class Person : IPerson
    {
        private int id;
        private string username;

        public Person(int id, string username)
        {
            this.id = id;
            this.username = username;
        }

        public int Id { get { return this.id; } }

        public string Username { get { return this.username; } }

        public override string ToString()
        {
            return $"ID: {this.id}{Environment.NewLine}Username: {this.username}";
        }
    }
}
