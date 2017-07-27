using System;
using System.Collections.Generic;
using System.Linq;

public class Engine
{
    private bool isRunning;
    private DraftManager draftManager;

    public Engine()
    {
        this.isRunning = true;
        draftManager = new DraftManager();
    }

    public void Run()
    {
        while (this.isRunning)
        {
            string inputCommand = ReadInput();
            List<string> commandParameters = ParseInput(inputCommand);
            DistributeCommand(commandParameters);
        }
    }

    private List<string> ParseInput(string inputCommand)
    {
        return inputCommand.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();
    }

    private string ReadInput()
    {
        return Console.ReadLine();
    }

    private void DistributeCommand(List<string> commandParameters)
    {
        string command = commandParameters[0];
        commandParameters.Remove(command);

        switch (command)
        {
            case "RegisterHarvester":
                string harvester = this.draftManager.RegisterHarvester(commandParameters);
                this.OutputWriter(harvester);
                break;
            case "RegisterProvider":
                string provider = this.draftManager.RegisterProvider(commandParameters);
                this.OutputWriter(provider);
                break;
            case "Day":
                string day = this.draftManager.Day();
                this.OutputWriter(day);
                break;
            case "Mode":
                string mode = this.draftManager.Mode(commandParameters);
                this.OutputWriter(mode);
                break;
            case "Check":
                string check = this.draftManager.Check(commandParameters);
                this.OutputWriter(check);
                break;
            case "Shutdown":
                string shutDown = this.draftManager.ShutDown();
                this.OutputWriter(shutDown);
                this.isRunning = false;
                break;
        }
    }

    private void OutputWriter(string output) => Console.WriteLine(output);
}
