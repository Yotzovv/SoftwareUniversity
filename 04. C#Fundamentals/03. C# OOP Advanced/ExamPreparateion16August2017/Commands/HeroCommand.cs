using System;
using System.Collections.Generic;

public class HeroCommand : AbstractCommand
{
    public HeroCommand(List<string> args, IManager manager) : base(args, manager)
    {
    }

    public override string Execute()
    {
        string name = base.Args[0];
        string type = base.Args[1];

        try
        {
            Type heroClassType = Type.GetType(type);
            AbstractHero heroInstance = Activator.CreateInstance(heroClassType, name) as AbstractHero;
            base.Manager.AddHero(heroInstance);
        }
        catch (Exception e)
        {
            return e.Message;
        }

        return $"Created {type} - {name}";
    }
}