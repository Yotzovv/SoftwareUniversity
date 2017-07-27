using _08.Military_Elite.Enums;
using _08.Military_Elite.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08.Military_Elite.Models
{
    public class Commando : SpecialisedSoldier, ICommando
    {
        public Commando(string id, string firstName, string lastName, double salary, Corps corps) : base(id, firstName, lastName, salary, corps)
        {
            this.Missions = new List<IMission>();
        }

        public ICollection<IMission> Missions { get; protected set; }

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.AppendLine(base.ToString());
            sb.AppendLine($"Corps: {this.Corps.ToString()}");
            sb.Append($"Missions:");
            if (this.Missions.Count > 0)
            {
                sb.AppendLine();
                var last = this.Missions.Last();
                foreach (var miss in this.Missions)
                {
                    if (miss == last)
                    {
                        sb.Append("  " + miss.ToString());
                    }
                    else
                    {
                        sb.AppendLine("  " + miss.ToString());
                    }
                }
            }

            return sb.ToString();
        }
    }
}
