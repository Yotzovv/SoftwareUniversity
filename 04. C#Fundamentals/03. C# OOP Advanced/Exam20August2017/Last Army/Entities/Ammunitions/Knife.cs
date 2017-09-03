public class Knife : Ammunition
{
    private const string name = "Knife";
    private const double KnifeWeight = 0.4;
    private const double wearLvl = KnifeWeight * 100;

    public Knife() : base(name, KnifeWeight, wearLvl)
    {
    }
}
