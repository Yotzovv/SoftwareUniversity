
public class ProviderFactory
{
    public static Provider GetProvider(string type, string id, double energyOutput)
    {
        Provider provider = null;

        switch (type)
        {
            case "Solar":
                return new SolarProvider(id, energyOutput);
            case "Pressure":
                return new PressureProvider(id, energyOutput);
            default:
                break;
        }

        return provider;
    }
}
