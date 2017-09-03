using Hell.Entities.Items;
using System.Collections.Generic;
using System.Linq;

public class RecipeCommand : AbstractCommand
{
    public RecipeCommand(List<string> args, IManager manager) : base(args, manager)
    {
    }

    public override string Execute()
    {
        string name = base.Args[0];
        string heroName = base.Args[1];
        int str = int.Parse(base.Args[2]);
        int agility = int.Parse(base.Args[3]);
        int intelligence = int.Parse(base.Args[4]);
        int hitPts = int.Parse(base.Args[5]);
        int dmg = int.Parse(base.Args[6]);
        string[] reqItems = base.Args.Count > 7 ? base.Args.Skip(7).ToArray() : null;

        IRecipe recipe = new RecipeItem(name, str, agility, intelligence, hitPts, dmg, reqItems);

        base.Manager.AddRecipe(recipe, heroName);

        return string.Format(Constants.RecipeCreatedMessage, name, heroName);
    }
}
