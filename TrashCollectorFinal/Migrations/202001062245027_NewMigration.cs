namespace TrashCollectorFinal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PickupDay = c.DateTime(nullable: false),
                        FirstName = c.String(),
                        LastName = c.String(),
                        ExtraPickupDate = c.Int(nullable: false),
                        StreetAddress = c.String(),
                        City = c.String(),
                        State = c.String(),
                        Zipcode = c.Int(nullable: false),
                        Balance = c.Double(nullable: false),
                        SuspendedStart = c.DateTime(nullable: false),
                        SuspendedEnd = c.DateTime(nullable: false),
                        PickupConfirmation = c.Boolean(nullable: false),
                        ApplicationId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationId)
                .Index(t => t.ApplicationId);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Zipcode = c.String(),
                        ApplicationId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationId)
                .Index(t => t.ApplicationId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Employees", "ApplicationId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Customers", "ApplicationId", "dbo.AspNetUsers");
            DropIndex("dbo.Employees", new[] { "ApplicationId" });
            DropIndex("dbo.Customers", new[] { "ApplicationId" });
            DropTable("dbo.Employees");
            DropTable("dbo.Customers");
        }
    }
}
