namespace InterestExplorerApp.Dal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateIMDBScore : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Series", "IMDBScore", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Series", "IMDBScore", c => c.Short(nullable: false));
        }
    }
}
