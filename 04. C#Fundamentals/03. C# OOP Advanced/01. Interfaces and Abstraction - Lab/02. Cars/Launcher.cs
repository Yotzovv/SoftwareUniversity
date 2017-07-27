using System;

class Launcher
{
    static void Main(string[] args)
    {
        ICar seat = new Seat("Leon", "Grey");
        IElectricCar tesla = new Tesla("Model 3", "Red", 2);


        Console.WriteLine(seat);
        Console.WriteLine(tesla);
    }
}
