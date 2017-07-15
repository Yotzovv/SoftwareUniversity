using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class NationsBuilder
{
    private Dictionary<string, Nation> nations;
    private List<string> warHistoryRecord;

    public NationsBuilder()
    {
        this.nations = new Dictionary<string, Nation>()
            {
                { "Air", new Nation() },
                { "Fire", new Nation() },
                { "Earth", new Nation() },
                { "Water", new Nation() }
            };

        this.warHistoryRecord = new List<string>();
    }

    public void AssignBender(List<string> benderArgs)
    {
        var benderType = benderArgs[0];

        Bender currentBender = GetBender(benderArgs);
        this.nations[benderType].AddBender(currentBender);
    }

    private Bender GetBender(List<string> benderArgs)
    {
        var type = benderArgs[0];
        var name = benderArgs[1];
        var power = int.Parse(benderArgs[2]);
        var auxParam = double.Parse(benderArgs[3]);

        switch (type)
        {
            case "Air":
                return new AirBender(name, power, auxParam);
            case "Water":
                return new WaterBender(name, power, auxParam);
            case "Fire":
                return new FireBender(name, power, float.Parse(auxParam.ToString()));
            case "Earth":
                return new EarthBender(name, power, float.Parse(auxParam.ToString()));
            default:
                throw new ArgumentException();
        }
    }

    public void AssignMonument(List<string> monumentArgs)
    {
        var type = monumentArgs[0];

        Monument currentMonument = GetMonument(monumentArgs);
        this.nations[type].AddMonument(currentMonument);
    }

    private Monument GetMonument(List<string> monumentArgs)
    {
        var type = monumentArgs[0];
        var name = monumentArgs[1];
        var affinity = int.Parse(monumentArgs[2]);

        switch (type)
        {
            case "Air":
                return new AirMonument(name, affinity);
            case "Water":
                return new WaterMonument(name, affinity);
            case "Fire":
                return new FireMonument(name, affinity);
            case "Earth":
                return new EarthMonument(name, affinity);
            default:
                throw new ArgumentException();
        }

    }

    public string GetStatus(string nationsType)
    {
        StringBuilder message = new StringBuilder();

        message.AppendLine($"{nationsType} Nation")
               .Append(this.nations[nationsType]);

        return message.ToString();
    }

    public void IssueWar(string nationsType)
    {
        double victorPower = this.nations.Max(p => p.Value.GetTotalPower());

        foreach (var nation in this.nations.Values)
        {
            if (nation.GetTotalPower() != victorPower)
            {
                nation.DeclareDefeat();
            }
        }

        this.warHistoryRecord.Add($"War {this.warHistoryRecord.Count + 1} issued by {nationsType}");
    }

    public string GetWarsRecord() => string.Join(Environment.NewLine, this.warHistoryRecord);
}