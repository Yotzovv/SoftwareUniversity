using System.Text;

public class Tesla : ICar, IElectricCar
{
    private string model;
    private string color;
    private int battery;

    public Tesla(string model, string color, int battery)
    {
        this.Model = model;
        this.Color = color;
        this.Battery = battery;
    }

    public int Battery
    {
        get
        {
            return this.battery;
        }
        private set
        {
            this.battery = value;
        }
    }

    public string Model
    {
        get
        {
            return this.model;
        }
        private set
        {
            this.model = value;
        }
    }

    public string Color
    {
        get
        {
            return this.color;
        }
        private set
        {
            this.color = value;
        }
    }

    public string Start()
    {
        return "Engine start";
    }

    public string Stop()
    {
        return "Breaaak!";
    }

    public override string ToString()
    {
        var sb = new StringBuilder();
        sb.AppendLine($"{this.Color} {this.GetType().Name} {this.Model} with {this.Battery} Batteries");
        sb.AppendLine(this.Start());
        sb.Append(this.Stop());
        return sb.ToString();
    }
}
