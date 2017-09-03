using System.Collections.Generic;
using System.Linq;

public abstract class Soldier : ISoldier
{
    private double endurance;

    protected Soldier(string name, int age, double exp, double endurance, double overallSkill)
    {
        this.Name = name;
        this.Age = age;
        this.Experience = exp;
        this.endurance = endurance;
        this.OverallSkill = overallSkill;
        this.Weapons = new Dictionary<string, IAmmunition>();
    }
    
    
    public string Name { get; private set; }

    public int Age { get; private set; }

    public double Experience { get; private set; }

    public double Endurance { get { return this.endurance; }
        private set
        {
            this.endurance = value;
        }
    }

    public double OverallSkill { get; private set; }

    public IDictionary<string, IAmmunition> Weapons { get; }

    protected abstract IReadOnlyList<string> WeaponsAllowed { get; }



    public void Regenerate()
    {
        if(this.GetType().Name == "Ranker" | this.GetType().Name == "Corporal")
        {
            this.endurance += 10 + this.Age;
        }
        else if(this.GetType().Name == "SpecialForce")
        {
            this.endurance += 10 + this.Age;
        }
    }

    public bool ReadyForMission(IMission mission)
    {
        if (this.Endurance < mission.EnduranceRequired)
        {
            return false;
        }

        bool hasAllEquipment = this.Weapons.Values.Count(weapon => weapon == null) == 0;

        if (!hasAllEquipment)
        {
            return false;
        }

        return this.Weapons.Values.Count(weapon => weapon.WearLevel <= 0) == 0;
    }

    private void AmmunitionRevision(double missionWearLevelDecrement)
    {
        IEnumerable<string> keys = this.Weapons.Keys.ToList();
        foreach (string weaponName in keys)
        {
            this.Weapons[weaponName].DecreaseWearLevel(missionWearLevelDecrement);

            if (this.Weapons[weaponName].WearLevel <= 0)
            {
                this.Weapons[weaponName] = null;
            }
        }
    }

    public void CompleteMission(IMission mission)
    {

    }

    //public override string ToString() => string.Format(OutputMessages.SoldierToString, this.Name, this.OverallSkill);
}