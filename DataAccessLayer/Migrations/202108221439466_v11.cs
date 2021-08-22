namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v11 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Contacts", newName: "Contact");
            DropForeignKey("dbo.Ads", "PackageId", "dbo.Packages");
            DropForeignKey("dbo.Transactions", "AdsId", "dbo.Ads");
            DropForeignKey("dbo.Contacts", "AdsId", "dbo.Ads");
            DropForeignKey("dbo.PackageOfUsers", "UserId", "dbo.User");
            DropForeignKey("dbo.Transactions", "UserId", "dbo.User");
            DropIndex("dbo.Ads", new[] { "PackageId" });
            DropIndex("dbo.Contact", new[] { "AdsId" });
            DropIndex("dbo.PackageOfUsers", new[] { "UserId" });
            DropIndex("dbo.Transactions", new[] { "UserId" });
            DropIndex("dbo.Transactions", new[] { "AdsId" });
            RenameColumn(table: "dbo.Transactions", name: "PackageOfUserId_Id", newName: "PackageOfUserId");
            RenameIndex(table: "dbo.Transactions", name: "IX_PackageOfUserId_Id", newName: "IX_PackageOfUserId");
            AddColumn("dbo.Ads", "UserId", c => c.Int());
            AddColumn("dbo.Ads", "Status", c => c.Int(nullable: false));
            AddColumn("dbo.Ads", "PackageOfUserId", c => c.Int(nullable: false));
            AddColumn("dbo.Contact", "Phone", c => c.String(nullable: false));
            AddColumn("dbo.Contact", "Message", c => c.String(nullable: false));
            AddColumn("dbo.Contact", "Status", c => c.Boolean(nullable: false));
            AddColumn("dbo.PackageOfUsers", "TotalAds", c => c.Int(nullable: false));
            AlterColumn("dbo.Contact", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Contact", "Email", c => c.String(nullable: false));
            AlterColumn("dbo.Contact", "AdsId", c => c.Int());
            AlterColumn("dbo.PackageOfUsers", "UserId", c => c.Int());
            AlterColumn("dbo.Transactions", "UserId", c => c.Int());
            CreateIndex("dbo.Ads", "UserId");
            CreateIndex("dbo.Ads", "PackageOfUserId");
            CreateIndex("dbo.PackageOfUsers", "UserId");
            CreateIndex("dbo.Transactions", "UserId");
            CreateIndex("dbo.Contact", "AdsId");
            AddForeignKey("dbo.Ads", "PackageOfUserId", "dbo.PackageOfUsers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Ads", "UserId", "dbo.User", "Id");
            AddForeignKey("dbo.Contact", "AdsId", "dbo.Ads", "Id");
            AddForeignKey("dbo.PackageOfUsers", "UserId", "dbo.User", "Id");
            AddForeignKey("dbo.Transactions", "UserId", "dbo.User", "Id");
            DropColumn("dbo.Ads", "Name");
            DropColumn("dbo.Ads", "PackageId");
            DropColumn("dbo.Ads", "Active");
            DropColumn("dbo.Contact", "Content");
            DropColumn("dbo.Transactions", "AdsId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Transactions", "AdsId", c => c.Int(nullable: false));
            AddColumn("dbo.Contact", "Content", c => c.String());
            AddColumn("dbo.Ads", "Active", c => c.Boolean(nullable: false));
            AddColumn("dbo.Ads", "PackageId", c => c.Int(nullable: false));
            AddColumn("dbo.Ads", "Name", c => c.String());
            DropForeignKey("dbo.Transactions", "UserId", "dbo.User");
            DropForeignKey("dbo.PackageOfUsers", "UserId", "dbo.User");
            DropForeignKey("dbo.Contact", "AdsId", "dbo.Ads");
            DropForeignKey("dbo.Ads", "UserId", "dbo.User");
            DropForeignKey("dbo.Ads", "PackageOfUserId", "dbo.PackageOfUsers");
            DropIndex("dbo.Contact", new[] { "AdsId" });
            DropIndex("dbo.Transactions", new[] { "UserId" });
            DropIndex("dbo.PackageOfUsers", new[] { "UserId" });
            DropIndex("dbo.Ads", new[] { "PackageOfUserId" });
            DropIndex("dbo.Ads", new[] { "UserId" });
            AlterColumn("dbo.Transactions", "UserId", c => c.Int(nullable: false));
            AlterColumn("dbo.PackageOfUsers", "UserId", c => c.Int(nullable: false));
            AlterColumn("dbo.Contact", "AdsId", c => c.Int(nullable: false));
            AlterColumn("dbo.Contact", "Email", c => c.String());
            AlterColumn("dbo.Contact", "Name", c => c.String());
            DropColumn("dbo.PackageOfUsers", "TotalAds");
            DropColumn("dbo.Contact", "Status");
            DropColumn("dbo.Contact", "Message");
            DropColumn("dbo.Contact", "Phone");
            DropColumn("dbo.Ads", "PackageOfUserId");
            DropColumn("dbo.Ads", "Status");
            DropColumn("dbo.Ads", "UserId");
            RenameIndex(table: "dbo.Transactions", name: "IX_PackageOfUserId", newName: "IX_PackageOfUserId_Id");
            RenameColumn(table: "dbo.Transactions", name: "PackageOfUserId", newName: "PackageOfUserId_Id");
            CreateIndex("dbo.Transactions", "AdsId");
            CreateIndex("dbo.Transactions", "UserId");
            CreateIndex("dbo.PackageOfUsers", "UserId");
            CreateIndex("dbo.Contact", "AdsId");
            CreateIndex("dbo.Ads", "PackageId");
            AddForeignKey("dbo.Transactions", "UserId", "dbo.User", "Id", cascadeDelete: true);
            AddForeignKey("dbo.PackageOfUsers", "UserId", "dbo.User", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Contacts", "AdsId", "dbo.Ads", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Transactions", "AdsId", "dbo.Ads", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Ads", "PackageId", "dbo.Packages", "Id", cascadeDelete: true);
            RenameTable(name: "dbo.Contact", newName: "Contacts");
        }
    }
}
