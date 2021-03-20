namespace InterestExplorerApp.Dal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateNameOfColumns : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Books", "BookName", c => c.String(nullable: false, maxLength: 150));
            AddColumn("dbo.Books", "BookDescription", c => c.String(nullable: false));
            AddColumn("dbo.Categories", "CategoryName", c => c.String(nullable: false, maxLength: 150));
            AddColumn("dbo.MainCategories", "MainCategoryName", c => c.String());
            AddColumn("dbo.Movies", "MovieName", c => c.String(nullable: false, maxLength: 100));
            AddColumn("dbo.Movies", "MovieDescription", c => c.String(nullable: false));
            AddColumn("dbo.Series", "SerisName", c => c.String(nullable: false, maxLength: 100));
            AddColumn("dbo.Series", "SeriesDescription", c => c.String(nullable: false));
            AddColumn("dbo.VideoGames", "VideoGameName", c => c.String(nullable: false, maxLength: 100));
            AddColumn("dbo.VideoGames", "VideoGameDescription", c => c.String(nullable: false));
            DropColumn("dbo.Books", "Name");
            DropColumn("dbo.Books", "Description");
            DropColumn("dbo.Categories", "Name");
            DropColumn("dbo.MainCategories", "Name");
            DropColumn("dbo.Movies", "Name");
            DropColumn("dbo.Movies", "Description");
            DropColumn("dbo.Series", "Name");
            DropColumn("dbo.Series", "Description");
            DropColumn("dbo.VideoGames", "Name");
            DropColumn("dbo.VideoGames", "Desciption");
        }
        
        public override void Down()
        {
            AddColumn("dbo.VideoGames", "Desciption", c => c.String(nullable: false));
            AddColumn("dbo.VideoGames", "Name", c => c.String(nullable: false, maxLength: 100));
            AddColumn("dbo.Series", "Description", c => c.String(nullable: false));
            AddColumn("dbo.Series", "Name", c => c.String(nullable: false, maxLength: 100));
            AddColumn("dbo.Movies", "Description", c => c.String(nullable: false));
            AddColumn("dbo.Movies", "Name", c => c.String(nullable: false, maxLength: 100));
            AddColumn("dbo.MainCategories", "Name", c => c.String());
            AddColumn("dbo.Categories", "Name", c => c.String(nullable: false, maxLength: 150));
            AddColumn("dbo.Books", "Description", c => c.String(nullable: false));
            AddColumn("dbo.Books", "Name", c => c.String(nullable: false, maxLength: 150));
            DropColumn("dbo.VideoGames", "VideoGameDescription");
            DropColumn("dbo.VideoGames", "VideoGameName");
            DropColumn("dbo.Series", "SeriesDescription");
            DropColumn("dbo.Series", "SerisName");
            DropColumn("dbo.Movies", "MovieDescription");
            DropColumn("dbo.Movies", "MovieName");
            DropColumn("dbo.MainCategories", "MainCategoryName");
            DropColumn("dbo.Categories", "CategoryName");
            DropColumn("dbo.Books", "BookDescription");
            DropColumn("dbo.Books", "BookName");
        }
    }
}
