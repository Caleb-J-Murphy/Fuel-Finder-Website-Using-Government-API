namespace FuelFinder.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ExampleUpdate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Company",
                c => new
                    {
                        CompanyID = c.Int(nullable: false, identity: true),
                        CompanyName = c.String(),
                    })
                .PrimaryKey(t => t.CompanyID);
            
            CreateTable(
                "dbo.Outlet",
                c => new
                    {
                        OutletID = c.Int(nullable: false, identity: true),
                        OutletName = c.String(),
                        Address = c.String(),
                        Latitude = c.Double(nullable: false),
                        Longitude = c.Double(nullable: false),
                        CompanyID = c.Int(nullable: false),
                        SuburbID = c.Int(nullable: false),
                        Company_CompanyID = c.Int(),
                        Suburb_CompanyID = c.Int(),
                        Company_CompanyID1 = c.Int(),
                    })
                .PrimaryKey(t => t.OutletID)
                .ForeignKey("dbo.Company", t => t.Company_CompanyID)
                .ForeignKey("dbo.Company", t => t.Suburb_CompanyID)
                .ForeignKey("dbo.Company", t => t.Company_CompanyID1)
                .ForeignKey("dbo.Suburb", t => t.SuburbID, cascadeDelete: true)
                .Index(t => t.SuburbID)
                .Index(t => t.Company_CompanyID)
                .Index(t => t.Suburb_CompanyID)
                .Index(t => t.Company_CompanyID1);
            
            CreateTable(
                "dbo.Record",
                c => new
                    {
                        RecordID = c.Int(nullable: false, identity: true),
                        Price = c.Int(nullable: false),
                        TransactionDateTime = c.DateTime(nullable: false),
                        OutletID = c.Int(nullable: false),
                        FuelID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.RecordID)
                .ForeignKey("dbo.Fuel", t => t.FuelID, cascadeDelete: true)
                .ForeignKey("dbo.Outlet", t => t.OutletID, cascadeDelete: true)
                .Index(t => t.OutletID)
                .Index(t => t.FuelID);
            
            CreateTable(
                "dbo.Fuel",
                c => new
                    {
                        FuelID = c.Int(nullable: false, identity: true),
                        FuelType = c.String(),
                    })
                .PrimaryKey(t => t.FuelID);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.State",
                c => new
                    {
                        StateID = c.Int(nullable: false, identity: true),
                        StateName = c.String(),
                    })
                .PrimaryKey(t => t.StateID);
            
            CreateTable(
                "dbo.Suburb",
                c => new
                    {
                        SuburbID = c.Int(nullable: false, identity: true),
                        SuburbName = c.String(),
                        PostCode = c.Int(nullable: false),
                        StateID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SuburbID)
                .ForeignKey("dbo.State", t => t.StateID, cascadeDelete: true)
                .Index(t => t.StateID);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Suburb", "StateID", "dbo.State");
            DropForeignKey("dbo.Outlet", "SuburbID", "dbo.Suburb");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Outlet", "Company_CompanyID1", "dbo.Company");
            DropForeignKey("dbo.Outlet", "Suburb_CompanyID", "dbo.Company");
            DropForeignKey("dbo.Record", "OutletID", "dbo.Outlet");
            DropForeignKey("dbo.Record", "FuelID", "dbo.Fuel");
            DropForeignKey("dbo.Outlet", "Company_CompanyID", "dbo.Company");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.Suburb", new[] { "StateID" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Record", new[] { "FuelID" });
            DropIndex("dbo.Record", new[] { "OutletID" });
            DropIndex("dbo.Outlet", new[] { "Company_CompanyID1" });
            DropIndex("dbo.Outlet", new[] { "Suburb_CompanyID" });
            DropIndex("dbo.Outlet", new[] { "Company_CompanyID" });
            DropIndex("dbo.Outlet", new[] { "SuburbID" });
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Suburb");
            DropTable("dbo.State");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Fuel");
            DropTable("dbo.Record");
            DropTable("dbo.Outlet");
            DropTable("dbo.Company");
        }
    }
}
