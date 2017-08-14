using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystem.Models
{
    public class SavingAccount
    {
        public SavingAccount()
        {
            this.InterestRate = 2;
        }

        [Key]
        public int AccountNumber { get; set; }

        public decimal Balance { get; set; }

        public decimal InterestRate { get; set; }
         
    }
}
