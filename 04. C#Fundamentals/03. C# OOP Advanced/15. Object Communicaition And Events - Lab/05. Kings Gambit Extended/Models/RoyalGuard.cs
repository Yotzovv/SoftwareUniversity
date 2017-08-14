using System;

public class RoyalGuard : Soldier
{
    public RoyalGuard(string name) : base(name)
    {
        this.Health = 3;
    }

    public override void KingUnderAttack(object sender, EventArgs args)
    {
        Console.WriteLine($"Royal Guard {this.Name} is defending!");
    }
}
