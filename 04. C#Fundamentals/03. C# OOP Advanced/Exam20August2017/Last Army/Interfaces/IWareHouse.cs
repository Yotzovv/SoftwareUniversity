using System.Collections.Generic;

public interface IWareHouse
{
    Dictionary<string, List<IAmmunition>> Ammunitions { get; }

    void EquipArmy(IArmy army);
}
