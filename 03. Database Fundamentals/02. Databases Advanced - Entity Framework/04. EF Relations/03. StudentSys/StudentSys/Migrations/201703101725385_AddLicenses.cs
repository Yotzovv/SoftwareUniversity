namespace StudentSys.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddLicenses : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Licenses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Resource_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Resources", t => t.Resource_Id)
                .Index(t => t.Resource_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Licenses", "Resource_Id", "dbo.Resources");
            DropIndex("dbo.Licenses", new[] { "Resource_Id" });
            DropTable("dbo.Licenses");
        }
    }
}
