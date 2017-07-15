using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public abstract class Car
{
    private string brand;
    private string model;
    private int productionYear;
    private int horsePower;
    private int acceleration;
    private int suspension;
    private int durability;

    public Car(string brand, string model, int productionYear, int horsePower,
        int acceleration, int suspension, int durability)
    {
        this.Brand = brand;
        this.Model = model;
        this.ProductionYear = productionYear;
        this.HorsePower = horsePower;
        this.Acceleration = acceleration;
        this.Suspension = suspension;
        this.Durability = durability;
    }


    public string Brand
    {
        get { return this.brand; }
        protected set
        {
            this.brand = value;
        }
    }

    public string Model
    {
        get { return this.model; }
        protected set
        {
            this.model = value;
        }
    }

    public int ProductionYear
    {
        get { return this.productionYear; }
        protected set
        {
            this.productionYear = value;
        }
    }

    public int HorsePower
    {
        get { return this.horsePower; }
        protected set
        {
            this.horsePower = value;
        }
    }

    public int Acceleration
    {
        get { return this.acceleration; }
        protected set
        {
            this.acceleration = value;
        }
    }

    public int Suspension
    {
        get { return this.suspension; }
        protected set
        {
            this.suspension = value;
        }
    }

    public int Durability
    {
        get { return this.durability; }
        set
        {
            this.durability = value;
        }
    }

    public virtual void Tune(int tuneIndex, string addOn)
    {
        this.HorsePower += tuneIndex;
        this.Suspension += tuneIndex / 2;
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine($"{this.Brand} {this.Model} {this.ProductionYear}");
        sb.AppendLine($"{this.HorsePower} HP, 100 m/h in {this.Acceleration} s");
        sb.AppendLine($"{this.Suspension} Suspension force, {Durability} Durability");

        return sb.ToString();
    }
}
