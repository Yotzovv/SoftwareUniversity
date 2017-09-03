using System.Collections.Generic;

public abstract class AbstractCommand : ICommand
{
    public AbstractCommand(List<string> args, IManager manager)
    {
        this.Args = args;
        this.Manager = manager;
    }

    public List<string> Args { get; private set; }
    public IManager Manager { get; private set; }

    public abstract string Execute();
}