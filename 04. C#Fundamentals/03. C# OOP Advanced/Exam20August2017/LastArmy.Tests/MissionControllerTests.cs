using NUnit.Framework;
using System;

[TestFixture]
public class MissionControllerTests
{
    private MissionController mc;
    private IArmy army;
    private IWareHouse wareHouse;

    [SetUp]
    public void MissionControllerInit()
    {
        army = new Army();
        wareHouse = new WareHouse();
        mc = new MissionController(army, wareHouse);
    }

    [Test]
    public void ReturnsAllMissions()
    {
        Assert.IsTrue(mc.Missions.Count == 0);
    }

    [Test]
    public void IsPerformingMission()
    {
        IMission mission = new Easy(10);
        army.AddSoldier(new Corporal("Delyan", 42, 30, 80));

        mc.PerformMission(mission);

        Assert.IsTrue(mc.SuccessMissionCounter != 0);
    }

    [Test]
    public void MissionQueueCountIsZeroOnInstantiation()
    {
        Assert.IsTrue(mc.Missions.Count == 0);
    }

    [Test]
    public void SuccessMissionCounterIsZeroOnInstantiation()
    {
        Assert.IsTrue(mc.SuccessMissionCounter == 0);
    }

    [Test]
    public void FailedMissionCounterIsZeroOnInstantiation()
    {
        Assert.IsTrue(mc.FailedMissionCounter == 0);
    }

    [Test]
    public void CanPerformMission()
    {
        IMission mission = new Easy(12);

        army.AddSoldier(new Ranker("Saruman", 33, 23, 21));
        mc.PerformMission(mission);

        Assert.IsTrue(mc.SuccessMissionCounter == 1);
    }
}
