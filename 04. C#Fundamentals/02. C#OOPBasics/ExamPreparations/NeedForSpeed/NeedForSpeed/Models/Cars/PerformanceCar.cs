using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class PerformanceCar : Car
{
    private List<string> addOns = new List<string>();

    public PerformanceCar(string brand, string model, int productionYear,
        int horsePower, int acceleration, int suspension, int durability)
        : base(brand, model, productionYear, horsePower, acceleration,
                suspension, durability)
    {
        base.HorsePower = (int)(horsePower * 1.5); //increase with 50%
        base.Suspension = (int)(suspension * 0.75); //decrease with 25%
    }

    public List<string> AddOns
    {
        get { return this.addOns; }
        set
        {
            this.addOns = value;
        }
    }

    public override void Tune(int tuneIndex, string addOn)
    {
        base.Tune(tuneIndex, addOn);
        this.AddOns.Add(addOn);
    }

    public override string ToString()
    {
        var result = base.ToString();
        result += $"Add-ons: ";

        if (this.AddOns.Count <= 0)
        {
            result += "None";
        }
        else
        {
            result += string.Join(", ", this.AddOns);
        }

        return result;
    }
}