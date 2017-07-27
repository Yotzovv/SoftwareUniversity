using System;
using System.Collections.Generic;
using System.Linq;

public class Engine
{
    private bool isRunning;
    CustomList<string> customList;

    public Engine()
    {
        this.isRunning = true;
        customList = new CustomList<string>();
    }

    public void Run()
    {
        while (this.isRunning)
        {
            string inputCommand = Console.ReadLine();
            List<string> commandParameters = ParseInput(inputCommand);
            DistributeCommand(commandParameters);
        }
    }

    private List<string> ParseInput(string inputCommand)
    {
        return inputCommand.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();
    }

    private void DistributeCommand(List<string> commandParameters)
    {
        string command = commandParameters[0];
        commandParameters.Remove(command);

        switch (command)
        {
            case "Add":
                customList.Add(commandParameters[0]);
                break;
            case "Remove":
                customList.Remove(int.Parse(commandParameters[0]));
                break;
            case "Contains":
                this.OutputWriter(customList.Contains(commandParameters[0]).ToString());
                break;
            case "Swap":
                customList.Swap(int.Parse(commandParameters[0]), int.Parse(commandParameters[1]));
                break;
            case "Greater":
                this.OutputWriter(customList.CountGreaterThan(commandParameters[0]).ToString());
                break;
            case "Max":
                Console.WriteLine(customList.Max());
                break;
            case "Min":
                Console.WriteLine(customList.Min());
                break;
            case "Print":
                customList.Print();
                break;
            case "Sort":
                customList.Sort();
                break;
            case "END":
                this.isRunning = false;
                break;
        }
    }

    private void OutputWriter(string output) => Console.WriteLine(output);
}
