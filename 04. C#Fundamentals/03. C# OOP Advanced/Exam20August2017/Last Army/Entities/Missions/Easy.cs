public class Easy : Mission
{
    private const string name = "Suppression of civil rebellion";
    private const double enduranceReq = 20;
    private const double wearLvlDecrement = 30;

    public Easy(double scoreToComplete) 
         : base(name, scoreToComplete, wearLvlDecrement, enduranceReq)
    {
    }
}
