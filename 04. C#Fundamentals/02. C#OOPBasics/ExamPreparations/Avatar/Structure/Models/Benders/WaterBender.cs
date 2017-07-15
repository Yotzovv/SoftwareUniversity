﻿using System;

public class WaterBender : Bender
{
    private double waterClarity;

    public WaterBender(string name, int power, double waterClarity)
        : base(name, power)
    {
        this.WaterClarity = waterClarity;
    }

    public double WaterClarity
    {
        get { return this.waterClarity; }
        private set
        {
            this.waterClarity = value;
        }
    }

    public override double GetPower() => this.WaterClarity * this.Power;

    public override string ToString() => $"{base.ToString()}, Water Clarity: {waterClarity:f2}";
}

