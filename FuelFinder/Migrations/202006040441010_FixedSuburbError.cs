namespace FuelFinder.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixedSuburbError : DbMigration
    {
        public override void Up()
        {
            //DropForeignKey("dbo.Outlet", "Company_CompanyID1", "dbo.Company");
            //DropForeignKey("dbo.Outlet", "Company_CompanyID", "dbo.Company");
            //DropForeignKey("dbo.Outlet", "Suburb_CompanyID", "dbo.Company");
            //DropIndex("dbo.Outlet", new[] { "SuburbID" });
            //DropIndex("dbo.Outlet", new[] { "Company_CompanyID" });
            //DropIndex("dbo.Outlet", new[] { "Suburb_CompanyID" });
            //DropIndex("dbo.Outlet", new[] { "Company_CompanyID1" });
            ////DropColumn("dbo.Outlet", "CompanyID");
            ////DropColumn("dbo.Outlet", "CompanyID");
            //DropColumn("dbo.Outlet", "SuburbID");
            //RenameColumn(table: "dbo.Outlet", name: "Company_CompanyID1", newName: "CompanyID");
            //RenameColumn(table: "dbo.Outlet", name: "Company_CompanyID", newName: "CompanyID");
            //RenameColumn(table: "dbo.Outlet", name: "Suburb_CompanyID", newName: "SuburbID");
            ////AlterColumn("dbo.Outlet", "CompanyID", c => c.Int(nullable: false));
            //AlterColumn("dbo.Outlet", "SuburbID", c => c.Int(nullable: false));
            ////AlterColumn("dbo.Outlet", "CompanyID", c => c.Int(nullable: false));
            //CreateIndex("dbo.Outlet", "CompanyID");
            //CreateIndex("dbo.Outlet", "SuburbID");
            //AddForeignKey("dbo.Outlet", "CompanyID", "dbo.Company", "CompanyID", cascadeDelete: true);
            //AddForeignKey("dbo.Outlet", "SuburbID", "dbo.Suburb", "SuburbID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            //DropForeignKey("dbo.Outlet", "SuburbID", "dbo.Suburb");
            //DropForeignKey("dbo.Outlet", "CompanyID", "dbo.Company");
            //DropIndex("dbo.Outlet", new[] { "SuburbID" });
            //DropIndex("dbo.Outlet", new[] { "CompanyID" });
            //AlterColumn("dbo.Outlet", "CompanyID", c => c.Int());
            //AlterColumn("dbo.Outlet", "SuburbID", c => c.Int());
            //AlterColumn("dbo.Outlet", "CompanyID", c => c.Int());
            //RenameColumn(table: "dbo.Outlet", name: "SuburbID", newName: "Suburb_CompanyID");
            //RenameColumn(table: "dbo.Outlet", name: "CompanyID", newName: "Company_CompanyID");
            //RenameColumn(table: "dbo.Outlet", name: "CompanyID", newName: "Company_CompanyID1");
            //AddColumn("dbo.Outlet", "SuburbID", c => c.Int(nullable: false));
            //AddColumn("dbo.Outlet", "CompanyID", c => c.Int(nullable: false));
            //AddColumn("dbo.Outlet", "CompanyID", c => c.Int(nullable: false));
            //CreateIndex("dbo.Outlet", "Company_CompanyID1");
            //CreateIndex("dbo.Outlet", "Suburb_CompanyID");
            //CreateIndex("dbo.Outlet", "Company_CompanyID");
            //CreateIndex("dbo.Outlet", "SuburbID");
            //AddForeignKey("dbo.Outlet", "Suburb_CompanyID", "dbo.Company", "CompanyID");
            //AddForeignKey("dbo.Outlet", "Company_CompanyID", "dbo.Company", "CompanyID");
            //AddForeignKey("dbo.Outlet", "Company_CompanyID1", "dbo.Company", "CompanyID");
        }
    }
}
