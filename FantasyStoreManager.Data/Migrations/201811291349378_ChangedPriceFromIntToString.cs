namespace FantasyStoreManager.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedPriceFromIntToString : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Product", "Price", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Product", "Price", c => c.Int(nullable: false));
        }
    }
}
