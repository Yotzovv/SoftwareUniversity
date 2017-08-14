using BankSystem.Models;
using BankSystem.Models.Accounts.Operations;
using BankSystem.Models.Accounts.Operations.SavingAccountOperations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            SystemContext context = new SystemContext();
            string[] cmd = Console.ReadLine().Split().ToArray();

            while(true)
            {
                if(cmd[0].Equals("Register"))
                {
                    UserCMDs uscmd = new UserCMDs();
                    uscmd.Register(cmd[1], cmd[2], cmd[3]);
                }
                else if(cmd[0].Equals("quit"))
                {
                    break;
                }

                cmd = Console.ReadLine().Split().ToArray();
            }
        }
    }
}
