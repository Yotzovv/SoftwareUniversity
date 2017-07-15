public class WaterMonument : Monument
{
    private int waterAffinity;

    public WaterMonument(string name, int waterAffinity)
        : base(name)
    {
        this.WaterAffinity = waterAffinity;
    }

    public int WaterAffinity
    {
        get { return this.waterAffinity; }
        private set
        {
            this.waterAffinity = value;
        }
    }

    public override int GetAffinity() => this.waterAffinity;

    public override string ToString() => $"{base.ToString()}, Water Affinity: {this.waterAffinity}";
}