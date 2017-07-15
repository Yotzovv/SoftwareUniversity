using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Nation
{
    private List<Bender> benders;
    private List<Monument> monuments;

    public Nation()
    {
        this.benders = new List<Bender>();
        this.monuments = new List<Monument>();
    }

    public List<Bender> Benders
    {
        get { return this.benders; }
        set
        {
            this.benders = value;
        }
    }

    public List<Monument> Monuments
    {
        get { return this.monuments; }
        set
        {
            this.monuments = value;
        }
    }

    public void AddBender(Bender bender) => benders.Add(bender);

    public void AddMonument(Monument monument) => monuments.Add(monument);

    public double GetTotalPower()
    {
        int monumentsIncreasePercentage = this.monuments.Sum(m => m.GetAffinity());
        double totalBendersPower = this.benders.Sum(b => b.GetPower());
        double totalPowerIncrease = totalBendersPower / 100 * monumentsIncreasePercentage;

        return totalBendersPower + totalPowerIncrease;
    }

    public override string ToString()
    {
        StringBuilder result = new StringBuilder();
        result.Append("Benders:");

        if (this.benders.Any())
        {
            result.AppendLine()
                  .AppendLine(string.Join(Environment.NewLine,
                              this.benders.Select(b => $"###{b}")));
        }
        else
        {
            result.AppendLine(" None");

            result.Append("Monuments: ");

            if (this.monuments.Any())
            {
                result.AppendLine()
                      .Append(string.Join(Environment.NewLine,
                              this.monuments.Select(m => $"###{m}")));
            }
            else
            {
                result.Append(" None");
            }
        }

        return result.ToString();
    }

    public void DeclareDefeat()
    {
        this.benders.Clear();
        this.monuments.Clear();
    }
}
