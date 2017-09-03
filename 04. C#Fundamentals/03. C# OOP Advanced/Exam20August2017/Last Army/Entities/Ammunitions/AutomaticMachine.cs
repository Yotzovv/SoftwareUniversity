public class AutomaticMachine : Ammunition
{
    private const string name = "AutomaticMachine";
    private const double AutoMachineWeight = 6.3;
    private const double wearLvl = AutoMachineWeight * 100;

    public AutomaticMachine() : base(name, AutoMachineWeight, wearLvl)
    {
    }
}