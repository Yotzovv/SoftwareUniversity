﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Rectangle : Shape
{
    private double height;
    private double width;

    public Rectangle(double height, double width)
    {
        this.Height = height;
        this.Width = width;
    }

    public double Height
    {
        get { return this.height; }
        private set
        {
            this.height = value;
        }
    }

    public double Width
    {
        get { return this.width; }
        private set
        {
            this.width = value;
        }
    }

    public override double CalculatePerimeter()
    {
        return 2 * height + 2 * width;
    }

    public override double CalculateArea()
    {
        return height * width;
    }

    public override string Draw()
    {
        return base.Draw() + this.GetType().Name;
    }
}