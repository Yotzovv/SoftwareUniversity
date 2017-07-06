using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Program
{
    static void Main(string[] args)
    {
        var acc = new BankAccount();
        acc.Deposit(300);

        var accounts = new List<BankAccount>();
        accounts.Add(acc);

        var dude = new Person("Pesho", 10, accounts);
        Console.WriteLine(dude.GetBalance());

    }
}
