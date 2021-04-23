namespace InterestExplorerApp.Dal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MovieTableUpdated : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Movies", "IMDBScore", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Movies", "IMDBScore", c => c.String(nullable: false));
        }
    }
}
