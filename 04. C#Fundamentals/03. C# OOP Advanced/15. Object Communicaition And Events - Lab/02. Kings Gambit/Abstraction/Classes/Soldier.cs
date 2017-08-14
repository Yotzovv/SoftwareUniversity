using System;

namespace _02.Kings_Gambit.Abstraction.Classes
{
    public abstract class Soldier
    {
        public Soldier(string name)
        {
            this.Name = name;
        }

        public string Name { get; private set; }

        public abstract void KingUnderAttack(object sender, EventArgs args);
    }
}
