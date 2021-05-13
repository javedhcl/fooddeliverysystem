namespace fooddeliverysystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Login_tbl",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                        Password = c.String(),
                        UserID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.user_tbl", t => t.UserID, cascadeDelete: true)
                .Index(t => t.UserID);
            
            CreateTable(
                "dbo.user_tbl",
                c => new
                    {
                        UserID = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                        Password = c.String(),
                        Name = c.String(),
                        Address = c.String(),
                        Mobile = c.String(),
                        Email = c.String(),
                        isAdmin = c.Boolean(nullable: false),
                        RoleId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UserID)
                .ForeignKey("dbo.role_tbl", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.role_tbl",
                c => new
                    {
                        RoleID = c.Int(nullable: false, identity: true),
                        RoleName = c.String(),
                    })
                .PrimaryKey(t => t.RoleID);
            
            CreateTable(
                "dbo.UserRoles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserID = c.Int(),
                        RoleID = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.role_tbl", t => t.RoleID)
                .ForeignKey("dbo.user_tbl", t => t.UserID)
                .Index(t => t.UserID)
                .Index(t => t.RoleID);
            
            CreateTable(
                "dbo.order_tbl",
                c => new
                    {
                        OrderId = c.Int(nullable: false, identity: true),
                        TotalBill = c.Int(nullable: false),
                        UserID = c.Int(nullable: false),
                        product_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.OrderId)
                .ForeignKey("dbo.product_tbl", t => t.product_id, cascadeDelete: true)
                .ForeignKey("dbo.user_tbl", t => t.UserID, cascadeDelete: true)
                .Index(t => t.UserID)
                .Index(t => t.product_id);
            
            CreateTable(
                "dbo.product_tbl",
                c => new
                    {
                        product_id = c.Int(nullable: false, identity: true),
                        product_name = c.String(),
                        price = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.product_id);
            
            CreateTable(
                "dbo.Registers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserName = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        Name = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        Mobile = c.String(nullable: false, maxLength: 10),
                        Address = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.order_tbl", "UserID", "dbo.user_tbl");
            DropForeignKey("dbo.order_tbl", "product_id", "dbo.product_tbl");
            DropForeignKey("dbo.UserRoles", "UserID", "dbo.user_tbl");
            DropForeignKey("dbo.UserRoles", "RoleID", "dbo.role_tbl");
            DropForeignKey("dbo.user_tbl", "RoleId", "dbo.role_tbl");
            DropForeignKey("dbo.Login_tbl", "UserID", "dbo.user_tbl");
            DropIndex("dbo.order_tbl", new[] { "product_id" });
            DropIndex("dbo.order_tbl", new[] { "UserID" });
            DropIndex("dbo.UserRoles", new[] { "RoleID" });
            DropIndex("dbo.UserRoles", new[] { "UserID" });
            DropIndex("dbo.user_tbl", new[] { "RoleId" });
            DropIndex("dbo.Login_tbl", new[] { "UserID" });
            DropTable("dbo.Registers");
            DropTable("dbo.product_tbl");
            DropTable("dbo.order_tbl");
            DropTable("dbo.UserRoles");
            DropTable("dbo.role_tbl");
            DropTable("dbo.user_tbl");
            DropTable("dbo.Login_tbl");
        }
    }
}
