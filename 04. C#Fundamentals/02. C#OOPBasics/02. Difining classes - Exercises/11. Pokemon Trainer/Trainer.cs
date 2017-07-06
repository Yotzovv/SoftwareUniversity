using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11.Pokemon_Trainer
{
    public class Trainer
    {
        private string name;
        private int badges;
        private List<Pokemon> pokemons;

        public Trainer(string name)
        {
            this.name = name;
            this.badges = 0;
            this.pokemons = new List<Pokemon>();
        }

        public string Name { get { return this.name; } set { this.name = value; } }
        public int Badges { get { return this.badges; } set { this.badges = value; } }
        public List<Pokemon> Pokemons { get { return this.pokemons; } set { this.pokemons = value; } }
    }
}
