using System.Collections.Generic;

interface ITeam
{
    string missionType { get; }
    IList<ISoldier> Soldiers { get; }
}

