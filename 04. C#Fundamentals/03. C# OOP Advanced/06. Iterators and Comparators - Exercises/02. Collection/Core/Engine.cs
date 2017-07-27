using System;
using System.Collections.Generic;
using System.Linq;

public class Engine
{
    ListyIterator<string> iterator;

    public Engine()
    {
        this.iterator = new ListyIterator<string>();
    }

    public void Run()
    {
        string command;

        while ((command = Console.ReadLine()) != "END")
        {
            DistributeCommands(command);
        }
    }

    private void DistributeCommands(string cmd)
    {
        if (cmd.Split()[0] == "Create")
        {
            this.iterator.Create(new List<string>(cmd.Split().ToList()));
        }

        try
        {
            switch (cmd)
            {
                case "Move":
                    this.OutputWriter(this.iterator.Move().ToString());
                    break;
                case "HasNext":
                    this.OutputWriter(this.iterator.HasNext().ToString());
                    break;
                case "Print":
                    this.iterator.Print();
                    break;
                case "PrintAll":
                    this.iterator.PrintAll();
                    break;
            }
        }
        catch(Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }

    private void OutputWriter(string arg) => Console.WriteLine(arg);
}