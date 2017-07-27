﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Ferrari
{
    public class Ferrari : ICar
    {
        private string model;
        private string driver;

        public Ferrari(string driver)
        {
            this.Model = "488-Spider";
            this.Driver = driver;
        }

        public string Model { get { return this.model; }
            private set
            {
                this.model = value;
            }
        }

        public string Driver { get { return this.driver; }
            private set
            {
                this.driver = value;
            }
        }

        public string Brake()
        {
            return "Brakes!";
        }

        public string Gas()
        {
            return "Zadu6avam sA!";
        }

        public override string ToString()
        {
            return $"{this.Model}/{this.Brake()}/{this.Gas()}/{this.Driver}";
        }
    }
}
