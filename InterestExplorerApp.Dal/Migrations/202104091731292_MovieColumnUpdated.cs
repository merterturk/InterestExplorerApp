namespace InterestExplorerApp.Dal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MovieColumnUpdated : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Movies", "IMDBScore", c => c.Decimal(nullable: false, precision: 18, scale: 1));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Movies", "IMDBScore", c => c.Double(nullable: false));
        }
    }
}
