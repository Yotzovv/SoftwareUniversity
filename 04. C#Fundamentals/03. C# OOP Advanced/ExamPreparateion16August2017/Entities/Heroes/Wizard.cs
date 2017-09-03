public class Wizard : AbstractHero
{
    private const int str = 25;
    private const int agility = 25;
    private const int intelligence = 100;
    private const int hitPts = 100;
    private const int dmg = 250;

    public Wizard(string name)
    : base(name, str, agility, intelligence, hitPts, dmg)
    {
    }
}