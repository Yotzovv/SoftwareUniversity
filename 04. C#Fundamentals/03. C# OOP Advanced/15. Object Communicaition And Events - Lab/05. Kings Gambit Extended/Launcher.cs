using System;
using System.Collections.Generic;
using System.Linq;

class Launcher
{
    static void Main(string[] args)
    {
        King king = new King(Console.ReadLine());
        List<Soldier> army = new List<Soldier>();

        string[] royalGuards = Console.ReadLine().Split();

        foreach (var royalGuard in royalGuards)
        {
            RoyalGuard guard = new RoyalGuard(royalGuard);
            army.Add(guard);

            king.UnderAttack += guard.KingUnderAttack;
        }

        string[] footmen = Console.ReadLine().Split();

        foreach (var footman in footmen)
        {
            Footman footMan = new Footman(footman);
            army.Add(footMan);

            king.UnderAttack += footMan.KingUnderAttack;
        }


        string[] command = Console.ReadLine().Split();

        while (command[0] != "End")
        {
            switch (command[0])
            {
                case "Kill":
                    Soldier soldier = army.FirstOrDefault(s => s.Name == command[1]);
                    soldier.Health--;
                    if (soldier.Health == 0)
                    {
                        king.UnderAttack -= soldier.KingUnderAttack;
                        army.Remove(soldier);
                    }
                    break;
                case "Attack":
                    king.OnUnderAttack();
                    break;
                default:
                    break;
            }

            command = Console.ReadLine().Split();
        }
    }
}
