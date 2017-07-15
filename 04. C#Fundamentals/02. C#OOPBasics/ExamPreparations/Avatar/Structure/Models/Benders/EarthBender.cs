using System;

public class EarthBender : Bender
{
    private float groundSaturation;

    public EarthBender(string name, int power, float groundSaturation)
        : base(name, power)
    {
        this.GroundSaturation = groundSaturation;
    }

    public float GroundSaturation
    {
        get { return this.groundSaturation; }
        private set
        {
            this.groundSaturation = value;
        }
    }

    public override double GetPower() => this.GroundSaturation * this.Power;

    public override string ToString() => $"{base.ToString()}, Ground Saturation: {groundSaturation:f2}";
}
