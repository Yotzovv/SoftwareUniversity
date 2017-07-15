﻿public class FireMonument : Monument
{
    private int fireAffinity;

    public FireMonument(string name, int fireAffinity)
        : base(name)
    {
        this.FireAffinity = fireAffinity;
    }

    public int FireAffinity
    {
        get { return this.fireAffinity; }
        private set
        {
            this.fireAffinity = value;
        }
    }

    public override int GetAffinity() => this.fireAffinity;

    public override string ToString() => $"{base.ToString()}, Fire Affinity: {this.fireAffinity}";
}
