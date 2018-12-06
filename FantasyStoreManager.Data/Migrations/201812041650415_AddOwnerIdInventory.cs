namespace FantasyStoreManager.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddOwnerIdInventory : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Inventory", "OwnerId", c => c.Guid(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Inventory", "OwnerId");
        }
    }
}
