namespace TrashCollectorFinal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangingDatTypeOfPickupDay : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Customers", "PickupDay", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Customers", "PickupDay", c => c.DateTime(nullable: false));
        }
    }
}
