using _08.Military_Elite.Enums;
using _08.Military_Elite.Interfaces;
using _08.Military_Elite.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace _08.Military_Elite
{
    public class Engine
    {
        List<ISoldier> soldiers;
        bool IsRunning;

        public Engine()
        {
            this.soldiers = new List<ISoldier>();
            this.IsRunning = true;
        }

        public void Run()
        {
            while (this.IsRunning)
            {
                DistributeCommands();              
                this.IsRunning = false;
            }

            soldiers.ForEach(s => Console.WriteLine(s));
        }

        private void DistributeCommands()
        {
            string input;

            while ((input = Console.ReadLine()) != "End")
            {
                var tokens = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();
                var type = tokens[0];
                tokens.RemoveAt(0);

                string id = tokens[0];
                string firstName = tokens[1];
                string lastName = tokens[2];

                switch (type)
                {
                    case "Spy":
                        soldiers.Add(new Spy(id, firstName, lastName, int.Parse(tokens[3])));
                        break;
                    case "Private":
                        soldiers.Add(new Private(id, firstName, lastName, double.Parse(tokens[3])));
                        break;
                    case "LeutenantGeneral":
                        LeutenantGeneral general = new LeutenantGeneral(id, firstName, lastName, double.Parse(tokens[3]));
                        tokens.Skip(4).ToList().ForEach(p => general.Privates.Add(soldiers.First(priv => priv.Id == p) as IPrivate));
                        soldiers.Add(general);
                        break;
                    case "Engineer":
                        Corps corps = tokens[4] == "Airforces" ? Corps.Airforces : Corps.Marines;
                        Engineer engineer = new Engineer(id, firstName, lastName, double.Parse(tokens[3]), corps);
                        tokens = tokens.Skip(5).ToList();
                        for (int i = 0; i < tokens.Count; i += 2)
                        {
                            string part = tokens[i];
                            int workedHours = int.Parse(tokens[i + 1]);
                            IRepair repair = new Repair(part, workedHours);
                            engineer.Repairs.Add(repair);
                        }
                        soldiers.Add(engineer);
                        break;
                    case "Commando":
                        corps = tokens[4] == "Airforces" ? Corps.Airforces : Corps.Marines;
                        Commando commando = new Commando(id, firstName, lastName, double.Parse(tokens[3]), corps);
                        tokens = tokens.Skip(5).ToList();

                        for (int i = 0; i < tokens.Count; i += 2)
                        {
                            string missionCodeName = tokens[i];
                            State missionState = State.inProgress;
                            if (Enum.TryParse(tokens[i + 1], out missionState))
                            {
                                IMission mission = new Mission(missionCodeName, missionState);
                                commando.Missions.Add(mission);
                            }
                        }
                        soldiers.Add(commando);
                        break;

                    default:
                        break;
                }
            }
        }
    }
}
