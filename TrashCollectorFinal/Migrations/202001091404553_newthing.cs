namespace TrashCollectorFinal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newthing : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Employees", "Zipcode", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Employees", "Zipcode", c => c.String());
        }
    }
}
