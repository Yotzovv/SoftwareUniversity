using System;

public class Footman : Soldier
{
    public Footman(string name) : base(name)
    {
        this.Health = 2;
    }

    public override void KingUnderAttack(object sender, EventArgs args)
    {
        Console.WriteLine($"Footman {this.Name} is panicking!");
    }
}
