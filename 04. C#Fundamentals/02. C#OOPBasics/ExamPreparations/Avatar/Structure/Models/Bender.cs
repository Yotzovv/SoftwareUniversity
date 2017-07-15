public abstract class Bender
{
    private string name;
    private int power;

    public Bender(string name, int power)
    {
        this.name = name;
        this.power = power;
    }

    public string Name { get { return this.name; }
        protected set
        {
            this.name = value;
        }
    }

    public int Power { get { return this.power; }
        protected set
        {
            this.power = value;
        }
    }

    public abstract double GetPower();

    public override string ToString()
    {
        string benderType = GetType().Name;
        int typeEnd = benderType.IndexOf("Bender");
        benderType = benderType.Insert(typeEnd, " ");

        return $"{benderType}: {this.name}, Power: {this.Power}";
    }
}
