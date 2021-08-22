namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Ads",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(),
                        Title = c.String(),
                        DetailAddress = c.String(),
                        LandArea = c.Int(nullable: false),
                        Price = c.Double(nullable: false),
                        Description = c.String(),
                        Note = c.String(),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        CategoryId = c.Int(nullable: false),
                        Need = c.String(),
                        UnitPrice = c.String(),
                        Status = c.Int(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedAt = c.DateTime(nullable: false),
                        PackageOfUserId = c.Int(nullable: false),
                        WardId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.CategoryId, cascadeDelete: true)
                .ForeignKey("dbo.PackageOfUsers", t => t.PackageOfUserId, cascadeDelete: true)
                .ForeignKey("dbo.User", t => t.UserId)
                .ForeignKey("dbo.Ward", t => t.WardId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.CategoryId)
                .Index(t => t.PackageOfUserId)
                .Index(t => t.WardId);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Active = c.Boolean(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PackageOfUsers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(),
                        PackageId = c.Int(nullable: false),
                        DayAds = c.Int(nullable: false),
                        NumberAds = c.Int(nullable: false),
                        TotalAds = c.Int(nullable: false),
                        TotalMoney = c.Double(nullable: false),
                        Active = c.Boolean(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Packages", t => t.PackageId, cascadeDelete: true)
                .ForeignKey("dbo.User", t => t.UserId)
                .Index(t => t.UserId)
                .Index(t => t.PackageId);
            
            CreateTable(
                "dbo.Packages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Priority = c.Int(nullable: false),
                        Name = c.String(nullable: false),
                        Price = c.Double(nullable: false),
                        Description = c.String(),
                        Active = c.Boolean(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Username = c.String(nullable: false),
                        Fullname = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        Phone = c.String(),
                        Email = c.String(nullable: false),
                        Avt = c.String(),
                        Gender = c.Boolean(nullable: false),
                        Birthday = c.DateTime(),
                        Address = c.String(),
                        Company = c.String(),
                        RoleId = c.Int(nullable: false),
                        Active = c.Boolean(nullable: false),
                        PaypalConfig = c.Int(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.UserRoles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.Transactions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(),
                        PackageOfUserId = c.Int(),
                        TotalMoney = c.Double(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.PackageOfUsers", t => t.PackageOfUserId)
                .ForeignKey("dbo.User", t => t.UserId)
                .Index(t => t.UserId)
                .Index(t => t.PackageOfUserId);
            
            CreateTable(
                "dbo.UserRoles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Active = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Ward",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        DistrictId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.District", t => t.DistrictId, cascadeDelete: true)
                .Index(t => t.DistrictId);
            
            CreateTable(
                "dbo.District",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        CityId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.City", t => t.CityId, cascadeDelete: true)
                .Index(t => t.CityId);
            
            CreateTable(
                "dbo.City",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        CountryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Country", t => t.CountryId, cascadeDelete: true)
                .Index(t => t.CountryId);
            
            CreateTable(
                "dbo.Country",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Contact",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        Phone = c.String(nullable: false),
                        Message = c.String(nullable: false),
                        AdsId = c.Int(),
                        Status = c.Boolean(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Ads", t => t.AdsId)
                .Index(t => t.AdsId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Contact", "AdsId", "dbo.Ads");
            DropForeignKey("dbo.Ward", "DistrictId", "dbo.District");
            DropForeignKey("dbo.District", "CityId", "dbo.City");
            DropForeignKey("dbo.City", "CountryId", "dbo.Country");
            DropForeignKey("dbo.Ads", "WardId", "dbo.Ward");
            DropForeignKey("dbo.User", "RoleId", "dbo.UserRoles");
            DropForeignKey("dbo.Transactions", "UserId", "dbo.User");
            DropForeignKey("dbo.Transactions", "PackageOfUserId", "dbo.PackageOfUsers");
            DropForeignKey("dbo.PackageOfUsers", "UserId", "dbo.User");
            DropForeignKey("dbo.Ads", "UserId", "dbo.User");
            DropForeignKey("dbo.PackageOfUsers", "PackageId", "dbo.Packages");
            DropForeignKey("dbo.Ads", "PackageOfUserId", "dbo.PackageOfUsers");
            DropForeignKey("dbo.Ads", "CategoryId", "dbo.Categories");
            DropIndex("dbo.Contact", new[] { "AdsId" });
            DropIndex("dbo.City", new[] { "CountryId" });
            DropIndex("dbo.District", new[] { "CityId" });
            DropIndex("dbo.Ward", new[] { "DistrictId" });
            DropIndex("dbo.Transactions", new[] { "PackageOfUserId" });
            DropIndex("dbo.Transactions", new[] { "UserId" });
            DropIndex("dbo.User", new[] { "RoleId" });
            DropIndex("dbo.PackageOfUsers", new[] { "PackageId" });
            DropIndex("dbo.PackageOfUsers", new[] { "UserId" });
            DropIndex("dbo.Ads", new[] { "WardId" });
            DropIndex("dbo.Ads", new[] { "PackageOfUserId" });
            DropIndex("dbo.Ads", new[] { "CategoryId" });
            DropIndex("dbo.Ads", new[] { "UserId" });
            DropTable("dbo.Contact");
            DropTable("dbo.Country");
            DropTable("dbo.City");
            DropTable("dbo.District");
            DropTable("dbo.Ward");
            DropTable("dbo.UserRoles");
            DropTable("dbo.Transactions");
            DropTable("dbo.User");
            DropTable("dbo.Packages");
            DropTable("dbo.PackageOfUsers");
            DropTable("dbo.Categories");
            DropTable("dbo.Ads");
        }
    }
}
