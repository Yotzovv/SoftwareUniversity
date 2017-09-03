using System;
using System.Collections.Generic;

public class WareHouse : IWareHouse
{
    private Dictionary<string, List<IAmmunition>> ammunitions;

    public WareHouse()
    {
        this.ammunitions = new Dictionary<string, List<IAmmunition>>();
    }

    public Dictionary<string, List<IAmmunition>> Ammunitions { get { return this.ammunitions; } }

    public void EquipArmy(IArmy army)
    {
        
    }
}
