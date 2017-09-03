
public class Assassin : AbstractHero
{
    private const int str = 25;
    private const int agility = 100;
    private const int intelligence = 15;
    private const int hitPts = 150;
    private const int dmg = 300;

    public Assassin(string name)
    : base(name, str, agility, intelligence, hitPts, dmg)
    {
    }
}
