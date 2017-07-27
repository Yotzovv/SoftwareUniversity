using System;

public abstract class Provider
{
    private string id;
    private double energyOutput;

    public Provider(string id, double energyOutput)
    {
        this.Id = id;
        this.EnergyOutput = energyOutput;
    }

    public string Id
    {
        get { return this.id; }
        protected set
        {
            this.id = value;
        }
    }

    public double EnergyOutput
    {
        get { return this.energyOutput; }
        protected set
        {
            if (value > 0 || value < 10000)
            {
                this.energyOutput = value;
            }

        }
    }

    public override string ToString()
    {
        return $"{this.GetType().Name} Provider - {id}" +
               $"\nEnergy Output: {this.energyOutput}";
    }

}
