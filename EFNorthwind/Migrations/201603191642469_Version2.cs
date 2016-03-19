namespace EFNorthwind.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Version2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.EmployeeCards",
                c => new
                    {
                        EmployeeCardID = c.Int(nullable: false, identity: true),
                        CardNumber = c.String(),
                        ExpireDate = c.DateTime(nullable: false),
                        CardHolder = c.String(),
                        EmployeeID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.EmployeeCardID)
                .ForeignKey("dbo.Employees", t => t.EmployeeID, cascadeDelete: true)
                .Index(t => t.EmployeeID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.EmployeeCards", "EmployeeID", "dbo.Employees");
            DropIndex("dbo.EmployeeCards", new[] { "EmployeeID" });
            DropTable("dbo.EmployeeCards");
        }
    }
}
