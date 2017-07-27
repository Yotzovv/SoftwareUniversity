public class HammerHarvester : Harvester
{
    public HammerHarvester(string id, double oreOutput, double energyRequiremen)
        : base(id, oreOutput, energyRequiremen)
    {
        this.OreOutput += oreOutput * 2;
        this.EnergyRequirement += energyRequiremen;
    }
}