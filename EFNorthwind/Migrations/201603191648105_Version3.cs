namespace EFNorthwind.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Version3 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Regions", name: "RegionID", newName: "RegionsID");
            RenameColumn(table: "dbo.Territories", name: "RegionID", newName: "RegionsID");
            RenameIndex(table: "dbo.Territories", name: "IX_RegionID", newName: "IX_RegionsID");
            AddColumn("dbo.Customers", "FoundationDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customers", "FoundationDate");
            RenameIndex(table: "dbo.Territories", name: "IX_RegionsID", newName: "IX_RegionID");
            RenameColumn(table: "dbo.Territories", name: "RegionsID", newName: "RegionID");
            RenameColumn(table: "dbo.Regions", name: "RegionsID", newName: "RegionID");
        }
    }
}
