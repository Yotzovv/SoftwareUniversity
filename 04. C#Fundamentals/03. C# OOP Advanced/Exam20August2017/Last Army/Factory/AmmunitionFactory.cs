using System;
using System.Reflection;

public class AmmunitionFactory : IAmmunitionFactory
{
    public AmmunitionFactory()
    {
    }

    public IAmmunition CreateAmmunition(string ammunitionName)
    {
        Type ammoType = Type.GetType(ammunitionName);
        IAmmunition ammoInstance = Activator.CreateInstance(ammoType) as IAmmunition;

        return ammoInstance;
    }
}