using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GringottsDB
{
    class Program
    {
        static void Main(string[] args)
        {
            WizzardDeposit dumbledore = new WizzardDeposit()
            {
                FirstName = "Albus",
                LastName = "Dumbledore",
                Age = 150,
                MagicWandCreator = "Antioch Peverell",
                MagicWandSize = 15,
                DepositStartDate = new DateTime(2016, 10, 20),
                DepositExpirationDate = new DateTime(2020, 10, 20),
                DepositAmount = 20000.24m,
                DepositCharge = 0.2m,
                IsDepositExpired = false,
            };

            WizzardDeposit Oktavyano = new WizzardDeposit()
            {
                FirstName = "Oktavyano",
                LastName = "of Silvermoon",
                Age = 6,
                MagicWandCreator = "Ivaylo Yotzov",
                MagicWandSize = 100,
                DepositStartDate = new DateTime(2009, 10, 18),
                DepositExpirationDate = new DateTime(2015, 8, 14),
                DepositAmount = 30000.506m,
                DepositCharge = 0.4m,
                IsDepositExpired = false,
                Id = 163,
            };

            WizzardDeposit Roflmaao = new WizzardDeposit()
            {
                FirstName = "Roflmaao",
                LastName = "of Thunderbluff",
                Age = 5,
                MagicWandCreator = "Ivaylo Yotzov",
                MagicWandSize = 150,
                DepositStartDate = new DateTime(2010, 04, 20),
                DepositExpirationDate = new DateTime(2015, 02, 10),
                DepositAmount = 40000.304m,
                DepositCharge = 0.3m,
                IsDepositExpired = false,
                Id = 164,
            };

            WizzardDeposit flux = new WizzardDeposit()
            {
                FirstName = "Flux",
                LastName = "Binar",
                Age = 3,
                MagicWandCreator = "Random",
                MagicWandSize = 3,
                DepositStartDate = new DateTime(2014, 10, 20),
                DepositExpirationDate = new DateTime(2018, 03, 04),
                DepositAmount = 200.03m,
                DepositCharge = 0.001m,
                IsDepositExpired = false,
                Id = 165,
            };          

            var context = new Gringotts();
            context.WizzardDeposits.Add(dumbledore);
            context.WizzardDeposits.Add(Oktavyano);
            context.WizzardDeposits.Add(Roflmaao);
            context.WizzardDeposits.Add(flux);
            context.SaveChanges();
            
        }
    }
}
