using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeedForSpeed.Models.Races
{
    public class TimeLimitRace : Race
    {
        private int? goldTime;

        public TimeLimitRace(int length, string route, int prizePool, int? goldTime)
        : base(length, route, prizePool)
        {
            this.GoldTime = goldTime;
        }

        public int? GoldTime { get { return this.goldTime; }
            set
            {
                goldTime = value;
            }
        }

        public override string ToString()
        {
            Car Participant = base.Participants.First();
            int tp = this.Length * ((Participant.HorsePower / 100) * Participant.Acceleration);
            string time = string.Empty;
            int prize = 0;

            if(tp <= GoldTime)
            {
                time = "Gold";
                prize = this.PrizePool;
            }
            else if(tp <= GoldTime + 15)
            {
                time = "Silver";
                prize = (int)(this.PrizePool * 0.5);
            }
            else if(tp > GoldTime + 15)
            {
                time = "Bronze";
                prize = (int)(this.PrizePool * 0.3);
            }


            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{this.Route} - {this.Length}");
            sb.AppendLine($"{this.Participants.First().Brand} {this.Participants.First().Model} - {tp} s.");
            sb.AppendLine($"{time} Time, ${prize}.");

            return sb.ToString();
        }
    }
}
