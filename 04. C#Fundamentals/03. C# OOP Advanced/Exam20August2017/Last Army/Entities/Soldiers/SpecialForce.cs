using System.Collections.Generic;

public class SpecialForce : Soldier
{
    private readonly List<string> weaponsAllowed = new List<string>
        {
            "Gun",
            "AutomaticMachine",
            "MachineGun",
            "RPG",
            "Helmet",
            "Knife",
            "NightVision"
        };

    public SpecialForce(string name, int age, double experience, double endurance)
        : base(name, age, experience, endurance, age + experience)
    {
    }

    protected override IReadOnlyList<string> WeaponsAllowed { get { return this.weaponsAllowed; } }
}