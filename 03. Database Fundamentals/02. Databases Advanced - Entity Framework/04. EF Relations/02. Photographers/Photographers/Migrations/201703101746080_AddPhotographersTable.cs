namespace Photographers.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPhotographersTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Photographers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Username = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        RegisterDate = c.DateTime(nullable: false),
                        Birthdate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Photographers");
        }
    }
}
