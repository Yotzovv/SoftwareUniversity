namespace Photographers.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Newew : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PhotographerAlbums", "Role", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.PhotographerAlbums", "Role");
        }
    }
}
