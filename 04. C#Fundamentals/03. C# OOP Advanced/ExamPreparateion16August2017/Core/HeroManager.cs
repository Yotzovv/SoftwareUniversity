using Hell.Entities.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class HeroManager : IManager
{
    public Dictionary<string, IHero> heroes;

    public HeroManager()
    {
        this.heroes = new Dictionary<string, IHero>();
    }

    public string Quit()
    {
        PrintAllHeroes();

        Environment.Exit(0);

        return string.Empty;
    }

    private void PrintAllHeroes()
    {
        int count = 1;

        var orderedHeroes = heroes.OrderByDescending(h => h.Value.Strength + h.Value.Agility + h.Value.Intelligence)
                                  .ThenByDescending(h => h.Value.HitPoints + h.Value.Damage);

        foreach (var hero in orderedHeroes.Select(v => v.Value))
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{count}. {hero.GetType().Name}: {hero.Name}");
            sb.AppendLine($"###HitPoints: {hero.HitPoints}");
            sb.AppendLine($"###Damage: {hero.Damage}");
            sb.AppendLine($"###Strength: {hero.Strength}");
            sb.AppendLine($"###Agility: {hero.Agility}");
            sb.AppendLine($"###Intelligence: {hero.Intelligence}");

            var items = hero.Items;

            sb.Append(items.Count == 0 ? "###Items: None" : "###Items: " + string.Join(", ", items));

            Console.WriteLine(sb);

            count++;
        }
    }

    public string AddHero(AbstractHero hero)
    {
        this.heroes.Add(hero.Name, hero);

        return string.Empty;
    }

    public string AddItem(IItem item, string hero)
    {
        heroes[hero].AddItem(item as CommonItem);

        return string.Empty;
    }

    public string AddRecipe(IRecipe recipe, string hero)
    {
        heroes[hero].AddRecipe(recipe as RecipeItem);

        return string.Empty;
    }

    public string Inspect(string hero)
    {
        this.heroes[hero].ToString();

        return string.Empty;
    }

    private string CreateGame()
    {
        StringBuilder result = new StringBuilder();

        foreach (var hero in heroes)
        {
            result.AppendLine(hero.Key);
        }

        return result.ToString();
    }

    //Само Батман знае как работи това
    //public void GenerateResult()
    //{
    //    const string PropName = "_connectionString";
    //
    //    var type = typeof(HeroCommand);
    //
    //    FieldInfo fieldInfo = null;
    //    PropertyInfo propertyInfo = null;
    //    while (fieldInfo == null && propertyInfo == null && type != null)
    //    {
    //        fieldInfo = type.GetField(PropName, BindingFlags.Public | BindingFlags.NonPublic | //BindingFlags.Instance);
    //        if (fieldInfo == null)
    //        {
    //            propertyInfo = type.GetProperty(PropName,
    //                BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
    //        }
    //
    //        type = type.BaseType;
    //    }
    //}
}