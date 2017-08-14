namespace BookShopSystem.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class asdas : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Authors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Books",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 50),
                        Description = c.String(maxLength: 1000),
                        EditionType = c.Int(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Copies = c.Int(nullable: false),
                        ReleaseDate = c.DateTime(),
                        AgeRestriction = c.Int(nullable: false),
                        Author_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Authors", t => t.Author_Id)
                .Index(t => t.Author_Id);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CategoryBooks",
                c => new
                    {
                        Category_Id = c.Int(nullable: false),
                        Book_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Category_Id, t.Book_Id })
                .ForeignKey("dbo.Categories", t => t.Category_Id, cascadeDelete: true)
                .ForeignKey("dbo.Books", t => t.Book_Id, cascadeDelete: true)
                .Index(t => t.Category_Id)
                .Index(t => t.Book_Id);
            
            CreateTable(
                "dbo.BooksRelatedBooks",
                c => new
                    {
                        BookId = c.Int(nullable: false),
                        RelatedBookId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.BookId, t.RelatedBookId })
                .ForeignKey("dbo.Books", t => t.BookId)
                .ForeignKey("dbo.Books", t => t.RelatedBookId)
                .Index(t => t.BookId)
                .Index(t => t.RelatedBookId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BooksRelatedBooks", "RelatedBookId", "dbo.Books");
            DropForeignKey("dbo.BooksRelatedBooks", "BookId", "dbo.Books");
            DropForeignKey("dbo.CategoryBooks", "Book_Id", "dbo.Books");
            DropForeignKey("dbo.CategoryBooks", "Category_Id", "dbo.Categories");
            DropForeignKey("dbo.Books", "Author_Id", "dbo.Authors");
            DropIndex("dbo.BooksRelatedBooks", new[] { "RelatedBookId" });
            DropIndex("dbo.BooksRelatedBooks", new[] { "BookId" });
            DropIndex("dbo.CategoryBooks", new[] { "Book_Id" });
            DropIndex("dbo.CategoryBooks", new[] { "Category_Id" });
            DropIndex("dbo.Books", new[] { "Author_Id" });
            DropTable("dbo.BooksRelatedBooks");
            DropTable("dbo.CategoryBooks");
            DropTable("dbo.Categories");
            DropTable("dbo.Books");
            DropTable("dbo.Authors");
        }
    }
}
