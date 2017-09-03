public abstract class Ammunition : IAmmunition
{
    private string name;
    private double wearLvl;
    private double weight;

    protected Ammunition(string name, double weight, double wearLvl)
    {
        this.name = name;
        this.weight = weight;
        this.wearLvl = wearLvl;
    }

    public string Name { get { return this.name; } }

    public double WearLevel { get { return this.wearLvl; } }

    public double Weight { get { return this.weight; } }

    public void DecreaseWearLevel(double wearAmount) => wearLvl -= wearAmount;
}
