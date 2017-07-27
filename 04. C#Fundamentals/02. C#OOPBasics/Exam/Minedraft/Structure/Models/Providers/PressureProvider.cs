public class PressureProvider : Provider
{
    public PressureProvider(string id, double energyOutput)
        : base(id, energyOutput)
    {
        EnergyOutput += energyOutput * 0.5F;
    }
}
