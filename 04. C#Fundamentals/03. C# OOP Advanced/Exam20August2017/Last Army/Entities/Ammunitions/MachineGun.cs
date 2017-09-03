public class MachineGun : Ammunition
{
    private const string name = "MachineGun";
    private const double MachineGunWeight = 10.6;
    private const double wearLvl = MachineGunWeight * 100;

    public MachineGun() : base (name, MachineGunWeight, wearLvl)
    {
    }
}