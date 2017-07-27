using System;

public class IOManager
{
    public static bool IsRegisterHarvesterValid(string type, string id, double oreOutput, double energyRequirement, int sonicFactor)
    {
        if (type != "Sonic" && type != "Hammer")
        {
            throw new ArgumentException("Harvester is not registered, because of it's Type");
        }

        if (type == "Sonic")
        {
            if (sonicFactor < 0 || sonicFactor > 10)
            {
                throw new ArgumentException("Harvester is not registered, because of it's SonicFactor");
            }
        }

        if (oreOutput < 0)
        {
            throw new ArgumentException("Harvester is not registered, because of it's OreOutput");
        }

        if (energyRequirement < 0 || energyRequirement > 10000)
        {
            throw new ArgumentException("Harvester is not registered, because of it's EnergyRequirement");
        }

        return true;
    }

    public static bool IsRegisterProviderValid(string type, string id, double energyOutput)
    {
        if (type != "Solar" && type != "Pressure")
        {
            throw new ArgumentException("Provider is not registered, because of it's Type");
        }

        if (energyOutput < 0 || energyOutput > 10000)
        {
            throw new ArgumentException("Provider is not registered, because of it's EnergyOutput");
        }

        return true;
    }
}