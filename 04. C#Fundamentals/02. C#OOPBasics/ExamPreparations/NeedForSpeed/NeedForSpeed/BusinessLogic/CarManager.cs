using NeedForSpeed.Models.Races;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class CarManager
{
    private Dictionary<int, Car> Registered = new Dictionary<int, Car>();
    private Dictionary<int, Race> Races = new Dictionary<int, Race>();
    private Garage garage = new Garage();

    public void Register(int id, string type, string brand, string model, int yearOfProduction, int horsepower, int acceleration, int suspension, int durability)
    {
        Car car = null;

        switch (type)
        {
            case "Show":
                car = new ShowCar(brand, model, yearOfProduction, horsepower, acceleration, suspension, durability);
                break;
            case "Performance":
                car = new PerformanceCar(brand, model, yearOfProduction, horsepower, acceleration, suspension, durability);
                break;
        }

        if (!Registered.ContainsKey(id))
        {
            Registered.Add(id, car);
        }
    }

    public string Check(int id)
    {
        return Registered[id].ToString();
    }

    public void Open(int id, string type, int length, string route, int prizePool, int? param)
    {
        if (!Races.ContainsKey(id))
        {
            switch (type)
            {
                case "Casual":
                    Races.Add(id, new CasualRace(length, route, prizePool));
                    break;
                case "Drag":
                    Races.Add(id, new DragRace(length, route, prizePool));
                    break;
                case "Drift":
                    Races.Add(id, new DriftRace(length, route, prizePool));
                    break;
                case "TimeLimit":
                    Races.Add(id, new TimeLimitRace(length, route, prizePool, param));
                    break;
                case "Circuit":
                    Races.Add(id, new CircuitRace(length, route, prizePool, param));
                    break;
            }
        }
    }

    public void Participate(int carId, int raceId)
    {
        Car car = Registered[carId];
        Race race = Races[raceId];

        if (!garage.Cars.Contains(car))
        {
            if (!race.Participants.Contains(car))
            {
                race.Participants.Add(car);
            }
        }
    }

    public string Start(int raceId)
    {
        Race race = Races[raceId];

        if (race.Participants.Count <= 0)
        {
            throw new ArgumentException("Cannot start the race with zero participants.");
        }

        Races.Remove(Races.FirstOrDefault(r => r.Value == race).Key);

        return race.ToString();
    }

    public void Park(int carId)
    {
        Car car = Registered[carId];

        if (!Races.Any(r => r.Value.Participants.Contains(car)))
        {
            if (!garage.Cars.Contains(car))
            {
                garage.Cars.Add(car);
            }
        }
    }

    public void Unpark(int carId)
    {
        Car car = Registered[carId];

        if (garage.Cars.Contains(car))
        {
            garage.Cars.Remove(car);
        }
    }

    public void Tune(int tuneIndex, string addOn)
    {
        if (garage.Cars.Count > 0)
        {
            foreach (var car in garage.Cars)
            {
                car.Tune(tuneIndex, addOn);
            }
        }
    }
}
