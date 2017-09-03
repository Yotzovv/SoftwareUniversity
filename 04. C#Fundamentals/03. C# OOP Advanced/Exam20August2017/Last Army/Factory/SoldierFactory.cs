using System;
using System.Reflection;

public class SoldierFactory : ISoldierFactory
{
    public SoldierFactory()
    {
    }

    public ISoldier CreateSoldier(string soldierTypeName, string name, int age, double experience, double endurance)
    {
        Type soldierType = Type.GetType(soldierTypeName);        
        ISoldier soldierInstance = Activator.CreateInstance(soldierType, BindingFlags.NonPublic, name, age, experience, endurance) as ISoldier;

        return soldierInstance;
    }
}
