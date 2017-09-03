using System;
using System.Collections.Generic;
using System.Linq;

public class GameController
{
    private IArmy army;
    private IWareHouse wareHouse;
    private MissionController missionControllerField;
    private SoldierFactory soldierFactory;
    private AmmunitionFactory ammoFactory;

    public GameController()
    {
        this.soldierFactory = new SoldierFactory();

        this.Army = new Army();
        this.WareHouse = new WareHouse();

        this.MissionControllerField = new MissionController(Army, WareHouse);
    }

    public IArmy Army
    {
        get { return army; }
        set { army = value; }
    }

    public IWareHouse WareHouse
    {
        get { return wareHouse; }
        set { wareHouse = value; }
    }

    public MissionController MissionControllerField
    {
        get { return missionControllerField; }
        set { missionControllerField = value; }
    }


    public void GiveInputToGameController(string input)
    {
        var data = input.Split(new char[] { ' ', }, StringSplitOptions.RemoveEmptyEntries);
        var cmd = data[0];
        data = data.Skip(1).ToArray();

        if (data[0].Equals("Soldier"))
        {
            string type = string.Empty;

            if (data[1].Equals("Regenerate"))
            {
                type = data[2];

                army.RegenerateTeam(type);
            }

            string name = string.Empty;
            int age = 0;
            int experience = 0;
            double speed = 0d;
            double endurance = 0d;
            double motivation = 0;
            double maxWeight = 0d;

            if (data.Length == 3)
            {
                type = data[1];
                name = data[2];
            }
            else
            {
                type = data[0];
                name = data[1];
                age = int.Parse(data[2]);
                experience = int.Parse(data[3]);
                speed = double.Parse(data[4]);
                endurance = double.Parse(data[5]);
            }

            soldierFactory.CreateSoldier(type, name, age, experience, endurance);

        }
        else if (data[0].Equals("WareHouse"))
        {
            string name = data[1];
            int number = int.Parse(data[2]);

            for (int i = 0; i < number; i++)
            {
                Type ammoType = Type.GetType(name);
                IAmmunition ammoInstance = Activator.CreateInstance(ammoType) as IAmmunition;

                AddAmmunitions(ammoInstance);
            }
        }
        else if (data[0].Equals("Mission"))
        {
            string type = data[1];
            double score = double.Parse(data[2]);

            switch (type)
            {
                case "Easy":
                    this.MissionControllerField.PerformMission(new Easy(score));
                    break;
                case "Medium":
                    this.MissionControllerField.PerformMission(new Medium(score));
                    break;
                case "Hard":
                    this.MissionControllerField.PerformMission(new Hard(score));
                    break;
            }
        }
    }


    private void AddAmmunitions(IAmmunition ammunition)
    {
        if (!this.WareHouse.Ammunitions.ContainsKey(ammunition.Name))
        {
            this.WareHouse.Ammunitions[ammunition.Name] = new List<IAmmunition>();
        }

        this.WareHouse.Ammunitions[ammunition.Name].Add(ammunition);
    }

    private void AddSoldierToArmy(Soldier soldier, string type)
    {
        if (!this.Army.Soldiers.Any(s => s == soldier))
        {
            this.Army.AddSoldier(soldier);
        }
    }

    // public string RequestResult()
    // {
    //     return Output.GiveOutput(army, wareHouse, this.MissionControllerField.Missions.Count);
    // }
}