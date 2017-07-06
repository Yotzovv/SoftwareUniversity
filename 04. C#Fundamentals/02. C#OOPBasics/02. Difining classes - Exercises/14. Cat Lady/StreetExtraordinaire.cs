using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _14.Cat_Lady
{
    public class StreetExtraordinaire : Cat
    {
        private int meowingDecibels;

        public StreetExtraordinaire(string name, int decibels)
        {
            this.Name = name;
            this.meowingDecibels = decibels;
        }

        public int MeowingDecibels { get { return this.meowingDecibels; } set { this.meowingDecibels = value; } }

        public override string ToString()
        {
            return $"StreetExtraordinaire {Name} {MeowingDecibels}";
        }
    }
}
