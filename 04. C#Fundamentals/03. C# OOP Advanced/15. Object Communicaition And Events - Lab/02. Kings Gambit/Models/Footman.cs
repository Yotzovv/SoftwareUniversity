using _02.Kings_Gambit.Abstraction.Classes;
using System;

namespace _02.Kings_Gambit
{
    public class Footman : Soldier
    {
        public Footman(string name) : base(name)
        {
        }

        public override void KingUnderAttack(object sender, EventArgs args)
        {
            Console.WriteLine($"Footman {this.Name} is panicking!");
        }
    }
}
