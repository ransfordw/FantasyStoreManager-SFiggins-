namespace FantasyStoreManager.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedVirtual : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Product", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Product", "Description", c => c.String(nullable: false));
            AlterColumn("dbo.Store", "Name", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Store", "Name", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Product", "Description", c => c.String());
            AlterColumn("dbo.Product", "Name", c => c.String());
        }
    }
}
