public class SonicHarvester : Harvester
{
    private int sonicFactor;

    public SonicHarvester(string id, double oreOutput, int sonicFactor, double energyRequiremen)
        : base(id, oreOutput, energyRequiremen)
    {
        this.EnergyRequirement /= sonicFactor;
    }

    public int SonicFactor
    {
        get { return this.sonicFactor; }
        private set
        {
            this.sonicFactor = value;
        }
    }
}
