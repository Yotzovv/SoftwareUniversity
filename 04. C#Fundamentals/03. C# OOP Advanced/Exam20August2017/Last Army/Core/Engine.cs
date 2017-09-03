using System;

public class Engine
{
    private ConsoleReader reader;
    private ConsoleWriter writer;
    private GameController gameController;

    public Engine(ConsoleReader reader, ConsoleWriter writer)
    {
        this.reader = reader;
        this.writer = writer;
        gameController = new GameController();
    }

    public void Run()
    {
        string input;

        while (!(input = reader.ReadLine()).Equals("Enough! Pull back!"))
        {
            try
            { 
                gameController.GiveInputToGameController(input);
            }
            catch (ArgumentException e)
            {
                writer.WriteLine(e.Message);
            }
        }
    }
}
