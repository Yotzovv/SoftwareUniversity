using Hell.Entities.Items;
using System.Collections.Generic;

public class ItemCommand : AbstractCommand
{
    public ItemCommand(List<string> args, IManager manager) : base(args, manager)
    {
    }

    public override string Execute()
    {
        string name = base.Args[0];
        string heroName = base.Args[1];
        int strBonus = int.Parse(base.Args[2]);
        int agilityBonus = int.Parse(base.Args[3]);
        int intelligenceBonus = int.Parse(base.Args[4]);
        int hitPts = int.Parse(base.Args[5]);
        int dmgBonus = int.Parse(base.Args[6]);

        IItem item = new CommonItem(name, strBonus, agilityBonus, intelligenceBonus, hitPts, dmgBonus);

        base.Manager.AddItem(item, heroName);

        return string.Format(Constants.ItemCreateMessage, item.Name, heroName);
    }
}