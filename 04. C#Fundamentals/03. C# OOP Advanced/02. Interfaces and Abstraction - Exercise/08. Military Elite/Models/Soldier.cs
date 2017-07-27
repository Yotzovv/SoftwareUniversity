using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08.Military_Elite.Models
{
    public class Soldier : ISoldier
    {
        public Soldier(string id, string firstname, string lastname)
        {
            this.Id = id;
            this.FirstName = firstname;
            this.Lastname = lastname;
        }

        public string FirstName { get; protected set; }

        public string Id { get; protected set; }

        public string Lastname { get; protected set; }

        public override string ToString()
        {
            return $"Name: {this.FirstName} {this.Lastname} Id: {this.Id}";
        }
    }
}
