namespace BankSystem
{
    using Models;
    using Models.Accounts;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class SystemContext : DbContext
    {
        public SystemContext()
            : base("name=SystemContext")
        {
        }
        public virtual DbSet<CheckingAccount> CheckingAccounts { get; set; }
        public virtual DbSet<SavingAccount> SavingAccounts { get; set; }
        public virtual DbSet<User> Users { get; set; }
    }
}