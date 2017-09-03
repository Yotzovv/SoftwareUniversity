using RecyclingStation.BusinessLogic.Attributes;


namespace RecyclingStation.BusinessLogic.Models
{
    [Burnable]
    public class BurnableGarbage : Garbage
    {
        public BurnableGarbage(string name, double weight, double volume) : base(name, weight, volume)
        {
        }
    }
}
