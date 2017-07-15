using System;

class Program
{
    static void Main(string[] args)
    {
        string input;
        CarManager carManager = new CarManager();

        while ((input = Console.ReadLine()) != "Cops Are Here")
        {
            var tokens = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            try
            {
                switch (tokens[0].ToLower())
                {
                    case "register":
                        int id = int.Parse(tokens[1]);
                        string type = tokens[2];
                        string brand = tokens[3];
                        string model = tokens[4];
                        int yearOfProduction = int.Parse(tokens[5]);
                        int horsePower = int.Parse(tokens[6]);
                        int acceleration = int.Parse(tokens[7]);
                        int suspension = int.Parse(tokens[8]);
                        int durability = int.Parse(tokens[9]);

                        carManager.Register(id, type, brand, model, yearOfProduction, horsePower,
                                            acceleration, suspension, durability);
                        break;
                    case "open":
                        id = int.Parse(tokens[1]);
                        type = tokens[2];
                        int length = int.Parse(tokens[3]);
                        string route = tokens[4];
                        int prizePool = int.Parse(tokens[5]);
                        int? param = tokens.Length > 5 ? int.Parse(tokens[6]) : 0;
                        carManager.Open(id, type, length, route, prizePool, param);
                        break;
                    case "participate":
                        int carId = int.Parse(tokens[1]);
                        int raceId = int.Parse(tokens[2]);
                        carManager.Participate(carId, raceId);
                        break;
                    case "check":
                        id = int.Parse(tokens[1]);
                        Console.WriteLine(carManager.Check(id));
                        break;
                    case "start":
                        raceId = int.Parse(tokens[1]);
                        Console.Write(carManager.Start(raceId));
                        break;
                    case "park":
                        carId = int.Parse(tokens[1]);
                        carManager.Park(carId);
                        break;
                    case "unpark":
                        carId = int.Parse(tokens[1]);
                        carManager.Unpark(carId);
                        break;
                    case "tune":
                        int tuneIndex = int.Parse(tokens[1]);
                        string addOn = tokens[2];
                        carManager.Tune(tuneIndex, addOn);
                        break;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
