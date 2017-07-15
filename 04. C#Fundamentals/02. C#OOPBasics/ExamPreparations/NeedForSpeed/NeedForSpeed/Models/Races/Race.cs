using NeedForSpeed.Models.Races;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public abstract class Race
{
    private int length;
    private string route;
    private int prizePool;
    private List<Car> participants = new List<Car>();

    public Race(int length, string route, int prizePool)
    {
        this.Length = length;
        this.Route = route;
        this.PrizePool = prizePool;
    }


    public int Length
    {
        get { return this.length; }
        protected set
        {
            this.length = value;
        }
    }

    public string Route
    {
        get { return this.route; }
        protected set
        {
            this.route = value;
        }
    }

    public int PrizePool
    {
        get { return this.prizePool; }
        protected set
        {
            this.prizePool = value;
        }
    }

    public List<Car> Participants
    {
        get { return this.participants; }
        protected set
        {
            this.participants = value;
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

        switch (this.GetType().Name)
        {
            case "CasualRace":
                winners = winners.OrderByDescending(w => (w.HorsePower / w.Acceleration) + (w.Suspension + w.Durability)).ToList();
                foreach (var winner in winners)
                {
                    performancePoints.Add((winner.HorsePower / winner.Acceleration) + (winner.Suspension + winner.Durability));
                }
                break;
            case "DragRace":
                winners = winners.OrderByDescending(w => (w.HorsePower / w.Acceleration)).ToList();
                foreach (var winner in winners)
                {
                    performancePoints.Add((winner.HorsePower / winner.Acceleration));
                }
                break;
            case "DriftRace":
                winners = winners.OrderByDescending(w => w.Suspension + w.Durability).ToList();
                foreach (var winner in winners)
                {
                    performancePoints.Add(winner.Suspension + winner.Durability);
                }
                break;
            case "CircuitRace":
                
                break;
            default:
                break;
        }

        dynamic first;
        dynamic second;
        dynamic third;

        try
        {
            first = winners.First();
            second = winners[1];
            third = winners.Last();
        }
        catch
        {

        }


        List<int> rewards = new List<int>();
        rewards.Add((int)(this.PrizePool * 0.5));
        rewards.Add((int)(this.PrizePool * 0.3));
        rewards.Add((int)(this.PrizePool * 0.2));

        StringBuilder sb = new StringBuilder();

        Console.WriteLine(this.Route + " - " + this.Length);
        for (int i = 0; i < winners.Take(3).ToList().Count; i++)
        {
            sb.AppendLine($"{i + 1}. {winners[i].Brand} {winners[i].Model} {performancePoints[i]}PP - ${rewards[i]}");
        }

        return $"{sb}";
    }
}
