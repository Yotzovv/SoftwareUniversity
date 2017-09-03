public interface IManager
{
    string AddHero(AbstractHero hero);
    string AddItem(IItem item, string hero);
    string AddRecipe(IRecipe item, string hero);
    string Inspect(string hero);
    string Quit();
}