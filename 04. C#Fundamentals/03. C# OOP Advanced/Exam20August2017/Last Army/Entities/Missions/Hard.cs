public class Hard : Mission
{
    private const string name = "Disposal of terrorists";
    private const double wearLvlDecrement = 70;
    private const double enduranceReq = 80;

    public Hard(double scoreToComplete)
        : base(name, scoreToComplete, wearLvlDecrement, enduranceReq)
    {
    }
}
