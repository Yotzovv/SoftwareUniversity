namespace SalesDB2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddColumnDiscriptionInProducts : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "Discription", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Products", "Discription");
        }
    }
}
