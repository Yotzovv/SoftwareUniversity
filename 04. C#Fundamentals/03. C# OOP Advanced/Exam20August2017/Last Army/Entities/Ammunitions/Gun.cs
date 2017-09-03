public class Gun : Ammunition
{
    private const string name = "Gun";
    private const double gunWeight = 1.4;
    private const double wearLvl = gunWeight * 100;

    public Gun() : base(name, gunWeight, wearLvl)
    {
    }
}