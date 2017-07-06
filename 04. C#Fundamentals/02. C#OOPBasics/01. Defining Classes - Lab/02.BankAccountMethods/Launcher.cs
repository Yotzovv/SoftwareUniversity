using System;

class Launcher
{
    static void Main(string[] args)
    {
        BankAccount acc = new BankAccount();
        acc.Id = 1;
        acc.Deposit(15);
        acc.Withdraw(5);
        acc.Balance = 0;

        Console.WriteLine(acc.ToString());
    }
}
