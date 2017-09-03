using System.Collections.Generic;

public class InspectCommand : AbstractCommand
{
    public InspectCommand(List<string> args, IManager manager) : base(args, manager)
    {
    }

    public override string Execute()
    {
        string heroName = base.Args[0];

        return base.Manager.Inspect(heroName);
    }
}