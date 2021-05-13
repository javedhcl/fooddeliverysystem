namespace fooddeliverysystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ProductLists",
                c => new
                    {
                        ProductId = c.Int(nullable: false, identity: true),
                        ProductName = c.String(),
                        Price = c.Double(nullable: false),
                        CatId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ProductId)
                .ForeignKey("dbo.Category_tbl", t => t.CatId, cascadeDelete: true)
                .Index(t => t.CatId);
            
            CreateTable(
                "dbo.Category_tbl",
                c => new
                    {
                        CatId = c.Int(nullable: false, identity: true),
                        CatName = c.String(),
                    })
                .PrimaryKey(t => t.CatId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProductLists", "CatId", "dbo.Category_tbl");
            DropIndex("dbo.ProductLists", new[] { "CatId" });
            DropTable("dbo.Category_tbl");
            DropTable("dbo.ProductLists");
        }
    }
}
