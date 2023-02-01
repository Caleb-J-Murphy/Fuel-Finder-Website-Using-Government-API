namespace FuelFinder.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedDataAnnotations : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Company", "CompanyName", c => c.String(nullable: false, maxLength: 140));
            AlterColumn("dbo.Outlet", "OutletName", c => c.String(nullable: false, maxLength: 140));
            AlterColumn("dbo.Fuel", "FuelType", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.State", "StateName", c => c.String(nullable: false, maxLength: 3));
            AlterColumn("dbo.Suburb", "SuburbName", c => c.String(nullable: false, maxLength: 140));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Suburb", "SuburbName", c => c.String());
            AlterColumn("dbo.State", "StateName", c => c.String());
            AlterColumn("dbo.Fuel", "FuelType", c => c.String());
            AlterColumn("dbo.Outlet", "OutletName", c => c.String());
            AlterColumn("dbo.Company", "CompanyName", c => c.String());
        }
    }
}
