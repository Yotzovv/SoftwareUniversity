using System;
using System.Reflection;

public class MissionFactory : IMissionFactory
{
    public IMission CreateMission(string difficultyLevel, double neededPoints)
    {
        Type missionType = Type.GetType(difficultyLevel);
        IMission missionInstance = Activator.CreateInstance(missionType, BindingFlags.NonPublic | BindingFlags.Public, neededPoints) as IMission;

        return missionInstance;
    }
}

