public class NightVision : Ammunition
{
    private const string name = "NightVision";
    private const double NightVisionWeight = 0.8;
    private const double wearLvl = NightVisionWeight * 100;

    public NightVision() : base(name, NightVisionWeight, wearLvl)
    {
    }
}