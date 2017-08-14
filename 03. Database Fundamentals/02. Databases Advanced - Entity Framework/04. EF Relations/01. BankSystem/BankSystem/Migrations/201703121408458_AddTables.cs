namespace BankSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CheckingAccounts",
                c => new
                    {
                        AccountNumber = c.Int(nullable: false, identity: true),
                        Balance = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Fee = c.Decimal(nullable: false, precision: 18, scale: 2),
                        User_Id = c.Int(),
                    })
                .PrimaryKey(t => t.AccountNumber)
                .ForeignKey("dbo.Users", t => t.User_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.SavingAccounts",
                c => new
                    {
                        AccountNumber = c.Int(nullable: false, identity: true),
                        Balance = c.Decimal(nullable: false, precision: 18, scale: 2),
                        InterestRate = c.Decimal(nullable: false, precision: 18, scale: 2),
                        User_Id = c.Int(),
                    })
                .PrimaryKey(t => t.AccountNumber)
                .ForeignKey("dbo.Users", t => t.User_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Username = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        Email = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SavingAccounts", "User_Id", "dbo.Users");
            DropForeignKey("dbo.CheckingAccounts", "User_Id", "dbo.Users");
            DropIndex("dbo.SavingAccounts", new[] { "User_Id" });
            DropIndex("dbo.CheckingAccounts", new[] { "User_Id" });
            DropTable("dbo.Users");
            DropTable("dbo.SavingAccounts");
            DropTable("dbo.CheckingAccounts");
        }
    }
}
