using System;
using System.Collections.Generic;

public class Ranker : Soldier
{
    private readonly List<string> weaponsAllowed = new List<string>
        {
            "Gun",
            "AutomaticMachine",
            "Helmet"
        };

    public Ranker(string name, int age, double exp, double endurance) 
        : base(name, age, exp, endurance, age + exp)
    {
    }

    protected override IReadOnlyList<string> WeaponsAllowed
    {
        get
        {
            return this.weaponsAllowed;
        }
    }
}
