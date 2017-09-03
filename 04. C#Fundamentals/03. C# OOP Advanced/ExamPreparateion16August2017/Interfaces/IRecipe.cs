using Hell.Entities.Items;
using System.Collections.Generic;

public interface IRecipe
{
    IList<string> RequiredItems { get; }
}