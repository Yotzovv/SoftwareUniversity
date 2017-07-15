using System.Collections.Generic;

public class Garage
{
    private List<Car> cars = new List<Car>();

    public List<Car> Cars { get { return this.cars; }
        set
        {
            this.cars = value;
        }
    }
}
