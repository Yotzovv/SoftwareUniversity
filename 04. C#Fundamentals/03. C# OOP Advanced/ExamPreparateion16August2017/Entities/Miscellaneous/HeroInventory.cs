using Hell.Entities.Items;
using System.Collections.Generic;
using System.Linq;

public class HeroInventory : IInventory
{
    [Item]
    private Dictionary<string, IItem> commonItems;

    private Dictionary<string, IRecipe> recipeItems;

    public HeroInventory()
    {
        this.commonItems = new Dictionary<string, IItem>();
        this.recipeItems = new Dictionary<string, IRecipe>();
    }

    public long TotalStrengthBonus
    {
        get { return this.CommonItems.Values.Sum(i => (long) i.StrengthBonus); }
    }

    public long TotalAgilityBonus
    {
        get { return this.CommonItems.Values.Sum(i => (long) i.AgilityBonus); }
    }

    public long TotalIntelligenceBonus
    {
        get { return this.CommonItems.Values.Sum(i => (long) i.IntelligenceBonus); }
    }

    public long TotalHitPointsBonus
    {
        get { return this.CommonItems.Values.Sum(i => (long) i.HitPointsBonus); }
    }

    public long TotalDamageBonus
    {
        get { return this.CommonItems.Values.Sum(i => (long) i.DamageBonus); }
    }

    public Dictionary<string, IItem> CommonItems { get { return this.commonItems; } }

    public void AddCommonItem(IItem item)
    {
        this.CommonItems.Add(item.Name, item);
        this.CheckRecipes();
    }

    public void AddRecipeItem(IRecipe recipe)
    {
        this.recipeItems.Add((recipe as RecipeItem).Name, recipe);
        this.CheckRecipes();
    }

    private void CheckRecipes()
    {
        foreach (RecipeItem recipe in this.recipeItems.Values)
        {
            List<string> requiredItems = new List<string>(recipe.RequiredItems);

            foreach (var commonItem in this.CommonItems.Values)
            {
                if (requiredItems.Contains(commonItem.Name))
                {
                    requiredItems.Remove(commonItem.Name);
                }
            }

            if (requiredItems.Count == 0)
            {
                this.CombineRecipe(recipe);
            }
        }
    }

    private void CombineRecipe(RecipeItem recipe)
    {
        for (int i = 0; i < recipe.RequiredItems.Count(); i++)
        {
            string itemName = recipe.RequiredItems[i];
            this.CommonItems.Remove(itemName);
        }

        IItem newItem = new CommonItem(recipe.Name,
                                       recipe.StrengthBonus,
                                       recipe.AgilityBonus,
                                       recipe.IntelligenceBonus,
                                       recipe.HitPointsBonus,
                                       recipe.DamageBonus);

        this.CommonItems.Add(newItem.Name, newItem);
    }
}