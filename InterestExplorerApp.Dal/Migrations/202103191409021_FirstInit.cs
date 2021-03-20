namespace InterestExplorerApp.Dal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FirstInit : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Books",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 150),
                        Description = c.String(nullable: false),
                        AuthorName = c.String(nullable: false, maxLength: 250),
                        ReleaseYear = c.Short(nullable: false),
                        PageNumber = c.Short(nullable: false),
                        ImageURL = c.String(),
                        CategoryId = c.Int(nullable: false),
                        IsPopular = c.Boolean(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        UpdatedDate = c.DateTime(),
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
                        Name = c.String(nullable: false, maxLength: 150),
                        MainCategoryId = c.Int(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        UpdatedDate = c.DateTime(),
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
                        Name = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        UpdatedDate = c.DateTime(),
                        DeletedDate = c.DateTime(),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Movies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                        Description = c.String(nullable: false),
                        Year = c.Short(nullable: false),
                        TotalTime = c.Short(nullable: false),
                        ImageURL = c.String(nullable: false),
                        IMDBScore = c.String(nullable: false),
                        CategoryId = c.Int(nullable: false),
                        IsPopular = c.Boolean(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        UpdatedDate = c.DateTime(),
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
                        Name = c.String(nullable: false, maxLength: 100),
                        Description = c.String(nullable: false),
                        Year = c.Short(nullable: false),
                        TotalEpisode = c.Short(nullable: false),
                        TotalSeason = c.Short(nullable: false),
                        ImageURL = c.String(nullable: false),
                        IMDBScore = c.String(nullable: false),
                        CategoryId = c.Int(nullable: false),
                        IsPopular = c.Boolean(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        UpdatedDate = c.DateTime(),
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
                        Name = c.String(nullable: false, maxLength: 100),
                        Desciption = c.String(nullable: false),
                        ReleaseDate = c.Short(nullable: false),
                        ImageURL = c.String(nullable: false),
                        IsPopular = c.Boolean(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        UpdatedDate = c.DateTime(),
                        DeletedDate = c.DateTime(),
                        IsActive = c.Boolean(nullable: false),
                        Category_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.Category_Id)
                .Index(t => t.Category_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.VideoGames", "Category_Id", "dbo.Categories");
            DropForeignKey("dbo.Series", "CategoryId", "dbo.Categories");
            DropForeignKey("dbo.Movies", "CategoryId", "dbo.Categories");
            DropForeignKey("dbo.Categories", "MainCategoryId", "dbo.MainCategories");
            DropForeignKey("dbo.Books", "CategoryId", "dbo.Categories");
            DropIndex("dbo.VideoGames", new[] { "Category_Id" });
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
        }
    }
}
