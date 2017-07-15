using System;

public class FireBender : Bender
{
    private float heatAggression;

    public FireBender(string name, int power, float heatAggression)
        : base(name, power)
    {
        this.HeatAggression = heatAggression;
    }

    public float HeatAggression
    {
        get { return this.heatAggression; }
        private set
        {
            this.heatAggression = value;
        }
    }

    public override double GetPower() => this.HeatAggression * this.Power;

    public override string ToString() => $"{base.ToString()}, Heat Aggression: {heatAggression:f2}";
}


