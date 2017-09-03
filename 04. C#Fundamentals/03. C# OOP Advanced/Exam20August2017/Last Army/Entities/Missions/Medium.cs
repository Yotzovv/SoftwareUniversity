public class Medium : Mission
{
    private const string name = "Capturing dangerous criminals";
    private const double enduranceReq = 50;
    private const double wearLvlDecrement = 50;

    public Medium(double scoreToComplete) 
         : base(name, scoreToComplete, wearLvlDecrement, enduranceReq)
    {
    }
}
