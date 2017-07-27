﻿using _08.Military_Elite.Enums;
using _08.Military_Elite.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08.Military_Elite.Models
{
    public class Engineer : SpecialisedSoldier, IEngineer
    {
        public Engineer(string id, string firstname, string lastName, double salary, Corps corps)
            : base (id, firstname, lastName, salary, corps)
        {
            this.Repairs = new List<IRepair>();
        }

        public ICollection<IRepair> Repairs { get; protected set; }

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.AppendLine(base.ToString());
            sb.AppendLine($"Corps: {this.Corps.ToString()}");
            sb.Append($"Repairs:");
            if (this.Repairs.Count > 0)
            {
                sb.AppendLine();
                var last = this.Repairs.Last();
                foreach (var rep in this.Repairs)
                {
                    if (rep == last)
                    {
                        sb.Append("  " + rep.ToString());
                    }
                    else
                    {
                        sb.AppendLine("  " + rep.ToString());
                    }
                }
            }

            return sb.ToString();
        }
    }
}
