using System;
using System.Collections.Generic;
using System.Linq;

public class DraftManager
{
    private double totalStoredEnergy;
    private double totalMinedOre;
    private string mode = "Full";
    private List<Harvester> harvesters;
    private List<Provider> providers;

    public DraftManager()
    {
        totalStoredEnergy = 0;
        totalMinedOre = 0;
        this.harvesters = new List<Harvester>();
        this.providers = new List<Provider>();
    }

    public string RegisterHarvester(List<string> args)
    {
        string type = args[0];
        string id = args[1];
        double oreOutput = double.Parse(args[2]);
        double energyRequirement = double.Parse(args[3]);
        Harvester harvester = null;
        int sonicFactor = 0;
        string result = string.Empty;

        try
        {
            IOManager.IsRegisterHarvesterValid(type, id, oreOutput, energyRequirement, sonicFactor);

            if (type == "Sonic")
            {
                sonicFactor = int.Parse(args[4]);
            }

            harvester = HarvesterFactory.GetHarvester(type, id, oreOutput, energyRequirement, sonicFactor);
            result = $"Successfully registered {type} Harvester - {id}";

            harvesters.Add(harvester);
        }
        catch (Exception e)
        {
            result = e.Message;
        }

        return result;
    }
    public string RegisterProvider(List<string> arguments)
    {
        string type = arguments[0];
        string id = arguments[1];
        double energyOutput = double.Parse(arguments[2]);
        Provider provider = null;
        string result = string.Empty;

        try
        {
            IOManager.IsRegisterProviderValid(type, id, energyOutput);

            provider = ProviderFactory.GetProvider(type, id, energyOutput);

            result = $"Successfully registered {type} Provider - {id}";
            providers.Add(provider);
        }
        catch (Exception e)
        {
            result = e.Message;
        }

        return result;
    }

    public string Day()
    {
        this.totalStoredEnergy += providers.Sum(e => e.EnergyOutput);
        double MinedOre = 0;
        double energy = providers.Sum(e => e.EnergyOutput);

        if (mode != "Energy")
        {

            if (mode == "Half")
            {
                double harvestersReqEnergy = harvesters.Sum(e => e.EnergyRequirement) * 0.6;

                if (totalStoredEnergy >= harvestersReqEnergy)
                {
                    MinedOre = harvesters.Sum(o => o.OreOutput * 0.5);
                    this.totalMinedOre += harvesters.Sum(o => o.OreOutput * 0.5);
                    this.totalStoredEnergy -= harvestersReqEnergy;
                }
            }
            else
            {
                double harvestersReqEnergy = harvesters.Sum(e => e.EnergyRequirement);

                if (totalStoredEnergy >= harvestersReqEnergy)
                {
                    MinedOre = harvesters.Sum(o => o.OreOutput);
                    this.totalMinedOre += harvesters.Sum(o => o.OreOutput);
                    this.totalStoredEnergy -= harvestersReqEnergy;
                }
            }
        }

        return $"A day has passed." +
               $"\nEnergy Provided: {providers.Sum(e => e.EnergyOutput)}" +
               $"\nPlumbus Ore Mined: {MinedOre}";
    }

    public string Mode(List<string> arguments)
    {
        this.mode = arguments[0];

        return $"Successfully changed working mode to {mode} Mode";
    }

    public string Check(List<string> arguments)
    {
        string id = arguments[0];
        object obj = null;

        if (providers.Any(i => i.Id == id))
        {
            obj = providers.FirstOrDefault(i => i.Id == id);
            return obj.ToString();
        }

        if (harvesters.Any(i => i.Id == id))
        {
            obj = harvesters.FirstOrDefault(i => i.Id == id);
            return obj.ToString();
        }


        return $"No element found with id - {id}";
    }

    public string ShutDown()
    {
        return $"System Shutdown" +
               $"\nTotal Energy Stored: {this.totalStoredEnergy}" +
               $"\nTotal Mined Plumbus Ore: {this.totalMinedOre}";
    }
}