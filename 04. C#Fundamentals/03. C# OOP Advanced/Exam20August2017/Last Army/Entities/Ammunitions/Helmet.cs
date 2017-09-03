public class Helmet : Ammunition
{
    private const string name = "Helmet";
    private const double HelmetWeight = 2.3;
    private const double wearLvl = HelmetWeight * 100;

    public Helmet() : base(name, HelmetWeight, wearLvl)
    {
    }
}