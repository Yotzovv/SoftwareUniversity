using System;
using System.Collections.Generic;
using System.Linq;

public class Army : IArmy
{
    private List<ISoldier> soldiers;

    public Army()
    {
        this.soldiers = new List<ISoldier>();
    }

    public IReadOnlyList<ISoldier> Soldiers
    {
        get
        {
            return this.soldiers;
        }
    }

    public void AddSoldier(ISoldier soldier) => this.soldiers.Add(soldier);

    public void RegenerateTeam(string soldierType)
    {
        soldiers.Where(t => t.GetType().Name == soldierType)
                .ToList()
                .ForEach(s => s.Regenerate());

    }
}