using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Launcher
{
    static void Main(string[] args)
    {
        BankAccount acc = new BankAccount();
        acc.ID = 1;
        acc.Balance = 15;

        Console.WriteLine($"Account {acc.ID}, balance {acc.Balance}");
    }
}