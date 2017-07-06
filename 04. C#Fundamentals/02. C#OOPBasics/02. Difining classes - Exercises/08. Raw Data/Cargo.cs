﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08.Raw_Data
{
    public class Cargo
    {
        int weight;
        string type;

        public Cargo(int weight, string type)
        {
            this.weight = weight;
            this.type = type;
        }

        public int Weight { get { return this.weight; } set { this.weight = value; } }
        public string Type { get { return this.type; } set { this.type = value; } }
    }
}
