namespace InterestExplorerApp.Dal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedTableColumns : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Series", "IMDBScore", c => c.Decimal(nullable: false, precision: 18, scale: 1));
            AlterColumn("dbo.VideoGames", "IMDBScore", c => c.Decimal(nullable: false, precision: 18, scale: 1));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.VideoGames", "IMDBScore", c => c.Double(nullable: false));
            AlterColumn("dbo.Series", "IMDBScore", c => c.Double(nullable: false));
        }
    }
}
