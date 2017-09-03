public class RPG : Ammunition
{
    private const string name = "RPG";
    private const double RPGWeight = 17.1;
    private const double wearLvl = RPGWeight * 100;

    public RPG() : base(name, RPGWeight, wearLvl)
    {
    }
}