public abstract class Harvester
{
    private string id;
    private double oreOutput;
    private double energyRequirement;

    public Harvester(string id, double oreOutput, double energyRequirement)
    {
        this.Id = id;
        this.OreOutput = oreOutput;
        this.EnergyRequirement = energyRequirement;
    }

    public string Id
    {
        get { return this.id; }
        protected set
        {
            this.id = value;
        }
    }

    public double OreOutput
    {
        get { return this.oreOutput; }
        protected set
        {
            if (value > 0)
            {
                this.oreOutput = value;
            }

        }
    }

    public double EnergyRequirement
    {
        get { return this.energyRequirement; }
        protected set
        {
            if (value > 0 || value < 20000)
            {
                this.energyRequirement = value;
            }
        }
    }

    public override string ToString()
    {
        return $"{this.GetType().Name} Harvester - {id}" +
               $"\nOre Output: {oreOutput}" +
               $"\nEnergy Requirement: {energyRequirement}";
    }
}
