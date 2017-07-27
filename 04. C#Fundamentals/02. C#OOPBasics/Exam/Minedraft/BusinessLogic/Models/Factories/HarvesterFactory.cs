
public class HarvesterFactory
{
    public static Harvester GetHarvester(string type, string id, double oreOutput, double energyRequirement, int sonicFactor)
    {
        Harvester harvester = null;

        switch (type)
        {
            case "Sonic":
                return new SonicHarvester(id, oreOutput, sonicFactor, energyRequirement);
            case "Hammer":
                return new HammerHarvester(id, oreOutput, energyRequirement);
            default:
                break;
        }

        return harvester;
    }
}
