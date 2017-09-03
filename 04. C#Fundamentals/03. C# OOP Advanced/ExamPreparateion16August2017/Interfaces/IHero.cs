
using System.Collections.Generic;

public interface IHero
{
    string Name { get; set; }
    ICollection<IItem> Items { get; }
    long Strength { get; set; }
    long Agility { get; set; }
    long Intelligence { get; set; }
    long HitPoints { get; set; }
    long Damage { get; set; }

    void AddItem(IItem item);
    void AddRecipe(IRecipe recipe);
}
