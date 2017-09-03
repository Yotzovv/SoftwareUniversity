public class Barbarian : AbstractHero
{
    private const int str = 90;
    private const int agility = 25;
    private const int intelligence = 10;
    private const int hitPts = 350;
    private const int dmg = 150;

    public Barbarian(string name)
    : base(name, str, agility, intelligence, hitPts, dmg)
    {
    }
}