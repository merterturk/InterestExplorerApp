namespace InterestExplorerApp.Dal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SecondInit : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.VideoGames", "Category_Id", "dbo.Categories");
            DropIndex("dbo.VideoGames", new[] { "Category_Id" });
            RenameColumn(table: "dbo.VideoGames", name: "Category_Id", newName: "CategoryId");
            AlterColumn("dbo.VideoGames", "CategoryId", c => c.Int(nullable: false));
            CreateIndex("dbo.VideoGames", "CategoryId");
            AddForeignKey("dbo.VideoGames", "CategoryId", "dbo.Categories", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.VideoGames", "CategoryId", "dbo.Categories");
            DropIndex("dbo.VideoGames", new[] { "CategoryId" });
            AlterColumn("dbo.VideoGames", "CategoryId", c => c.Int());
            RenameColumn(table: "dbo.VideoGames", name: "CategoryId", newName: "Category_Id");
            CreateIndex("dbo.VideoGames", "Category_Id");
            AddForeignKey("dbo.VideoGames", "Category_Id", "dbo.Categories", "Id");
        }
    }
}
