namespace InterestExplorerApp.Dal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DatabaseCreated : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Admins",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Books",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BookName = c.String(nullable: false, maxLength: 150),
                        BookDescription = c.String(nullable: false),
                        AuthorName = c.String(nullable: false, maxLength: 250),
                        ReleaseYear = c.Short(nullable: false),
                        PageNumber = c.Short(nullable: false),
                        ImageURL = c.String(),
                        CategoryId = c.Int(nullable: false),
                        CreatedDate = c.DateTime(),
                        DeletedDate = c.DateTime(),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.CategoryId, cascadeDelete: true)
                .Index(t => t.CategoryId);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CategoryName = c.String(nullable: false, maxLength: 150),
                        MainCategoryId = c.Int(nullable: false),
                        CreatedDate = c.DateTime(),
                        DeletedDate = c.DateTime(),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.MainCategories", t => t.MainCategoryId, cascadeDelete: true)
                .Index(t => t.MainCategoryId);
            
            CreateTable(
                "dbo.MainCategories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MainCategoryName = c.String(),
                        CreatedDate = c.DateTime(),
                        DeletedDate = c.DateTime(),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Movies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MovieName = c.String(nullable: false, maxLength: 100),
                        MovieDescription = c.String(nullable: false),
                        Year = c.Short(nullable: false),
                        TotalTime = c.Short(nullable: false),
                        IMDBScore = c.Decimal(nullable: false, precision: 18, scale: 1),
                        ImageURL = c.String(nullable: false),
                        VideoURL = c.String(),
                        CategoryId = c.Int(nullable: false),
                        CreatedDate = c.DateTime(),
                        DeletedDate = c.DateTime(),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.CategoryId, cascadeDelete: true)
                .Index(t => t.CategoryId);
            
            CreateTable(
                "dbo.Series",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SeriesName = c.String(nullable: false, maxLength: 100),
                        SeriesDescription = c.String(nullable: false),
                        Year = c.Short(nullable: false),
                        TotalEpisode = c.Short(nullable: false),
                        TotalSeason = c.Short(nullable: false),
                        ImageURL = c.String(nullable: false),
                        VideoURL = c.String(),
                        IMDBScore = c.Decimal(nullable: false, precision: 18, scale: 1),
                        CategoryId = c.Int(nullable: false),
                        CreatedDate = c.DateTime(),
                        DeletedDate = c.DateTime(),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.CategoryId, cascadeDelete: true)
                .Index(t => t.CategoryId);
            
            CreateTable(
                "dbo.VideoGames",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        VideoGameName = c.String(nullable: false, maxLength: 100),
                        VideoGameDescription = c.String(nullable: false),
                        ReleaseDate = c.Short(nullable: false),
                        IMDBScore = c.Decimal(nullable: false, precision: 18, scale: 1),
                        ImageURL = c.String(nullable: false),
                        VideoURL = c.String(),
                        CategoryId = c.Int(nullable: false),
                        CreatedDate = c.DateTime(),
                        DeletedDate = c.DateTime(),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.CategoryId, cascadeDelete: true)
                .Index(t => t.CategoryId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.VideoGames", "CategoryId", "dbo.Categories");
            DropForeignKey("dbo.Series", "CategoryId", "dbo.Categories");
            DropForeignKey("dbo.Movies", "CategoryId", "dbo.Categories");
            DropForeignKey("dbo.Categories", "MainCategoryId", "dbo.MainCategories");
            DropForeignKey("dbo.Books", "CategoryId", "dbo.Categories");
            DropIndex("dbo.VideoGames", new[] { "CategoryId" });
            DropIndex("dbo.Series", new[] { "CategoryId" });
            DropIndex("dbo.Movies", new[] { "CategoryId" });
            DropIndex("dbo.Categories", new[] { "MainCategoryId" });
            DropIndex("dbo.Books", new[] { "CategoryId" });
            DropTable("dbo.VideoGames");
            DropTable("dbo.Series");
            DropTable("dbo.Movies");
            DropTable("dbo.MainCategories");
            DropTable("dbo.Categories");
            DropTable("dbo.Books");
            DropTable("dbo.Admins");
        }
    }
}
