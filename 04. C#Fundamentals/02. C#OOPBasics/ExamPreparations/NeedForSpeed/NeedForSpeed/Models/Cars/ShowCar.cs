using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class ShowCar : Car
{
    private int stars = 0;

    public ShowCar(string brand, string model, int productionYear,
        int horsePower, int acceleration, int suspension, int durability)
        : base(brand, model, productionYear, horsePower, acceleration,
                suspension, durability)
    {
    }

    public int Stars
    {
        get { return this.stars; }
        set
        {
            stars = value;
        }
    }

    public override void Tune(int tuneIndex, string addOn)
    {
        base.Tune(tuneIndex, addOn);
        this.Stars += tuneIndex;
    }

    public override string ToString()
    {
        var result = base.ToString();
        result += $"{this.Stars} *";

        return result;
    }
}
