using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeedForSpeed.Models.Races
{
    public class CircuitRace : Race
    {
        private int? laps;

        public CircuitRace(int length, string route, int prizePool, int? laps)
        : base(length, route, prizePool)
        {
            this.Laps = laps;
        }

        public int? Laps { get { return this.laps; }
            set
            {
                this.laps = value;
            }
        }

        public override string ToString()
        {
            List<Car> winners = new List<Car>();
            List<int> performancePoints = new List<int>();

            foreach (var car in Participants)
            {
                winners.Add(car);
            }

            for (int i = 0; i < Laps; i++)
            {
                foreach (var winner in winners)
                {
                    winner.Durability -= (Length * Length);
                }
            }

            winners = winners.OrderByDescending(w => (w.HorsePower / w.Acceleration) + (w.Suspension + w.Durability)).ToList();

            foreach (var winner in winners)
            {
                performancePoints.Add((winner.HorsePower / winner.Acceleration) + (winner.Suspension + winner.Durability));
            }

            dynamic first;
            dynamic second;
            dynamic third;
            dynamic fourth;

            try
            {
                first = winners.First();
                second = winners[1];
                third = winners[2];
                fourth = winners.Last();
            }
            catch
            {

            }


            List<int> rewards = new List<int>();
            rewards.Add((int)(this.PrizePool * 0.4));
            rewards.Add((int)(this.PrizePool * 0.3));
            rewards.Add((int)(this.PrizePool * 0.2));
            rewards.Add((int)(this.PrizePool * 0.1));

            StringBuilder sb = new StringBuilder();

            Console.WriteLine(this.Route + " - " + this.Length * this.Laps);
            for (int i = 0; i < winners.Take(4).ToList().Count; i++)
            {
                sb.AppendLine($"{i + 1}. {winners[i].Brand} {winners[i].Model} {performancePoints[i]}PP - ${rewards[i]}");
            }

            return $"{sb}";
        }
    }
}
