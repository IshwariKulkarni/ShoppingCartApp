namespace ShoppingCartApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migration1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Carts",
                c => new
                    {
                        CartId = c.String(nullable: false, maxLength: 128),
                        ProductName = c.String(),
                        ProductQuantity = c.Int(nullable: false),
                        ProductPrice = c.Single(nullable: false),
                        ProductId = c.String(),
                    })
                .PrimaryKey(t => t.CartId);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        CategoryId = c.String(nullable: false, maxLength: 128),
                        CategoryName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.CategoryId);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false),
                        EmailId = c.String(nullable: false),
                        Address = c.String(nullable: false),
                        ContactNo = c.Int(nullable: false),
                        Password = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.UserId);
            
            CreateTable(
                "dbo.Merchants",
                c => new
                    {
                        MerchantId = c.String(nullable: false, maxLength: 128),
                        MerchantName = c.String(nullable: false),
                        MerchantContact = c.String(nullable: false),
                        MerchantEmail = c.String(nullable: false),
                        MerchantPassword = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.MerchantId);
            
            CreateTable(
                "dbo.OrderDetails",
                c => new
                    {
                        OrderId = c.String(nullable: false, maxLength: 128),
                        DateOfOrder = c.DateTime(nullable: false),
                        ProductId = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.OrderId)
                .ForeignKey("dbo.Customers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.ProductId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ProductId = c.String(nullable: false, maxLength: 128),
                        ProductName = c.String(nullable: false),
                        ProductCategory = c.String(nullable: false),
                        ProductPrice = c.Single(nullable: false),
                        ProductQuantity = c.Int(nullable: false),
                        ProductDescription = c.String(),
                        CategoryId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.ProductId)
                .ForeignKey("dbo.Categories", t => t.CategoryId)
                .Index(t => t.CategoryId);
            
            CreateTable(
                "dbo.TransactionDetails",
                c => new
                    {
                        TransactionId = c.Int(nullable: false, identity: true),
                        TransactionType = c.String(nullable: false),
                        TransactionDate = c.DateTime(nullable: false),
                        Amount = c.Single(nullable: false),
                        OrderId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.TransactionId)
                .ForeignKey("dbo.OrderDetails", t => t.OrderId)
                .Index(t => t.OrderId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TransactionDetails", "OrderId", "dbo.OrderDetails");
            DropForeignKey("dbo.OrderDetails", "ProductId", "dbo.Products");
            DropForeignKey("dbo.Products", "CategoryId", "dbo.Categories");
            DropForeignKey("dbo.OrderDetails", "UserId", "dbo.Customers");
            DropIndex("dbo.TransactionDetails", new[] { "OrderId" });
            DropIndex("dbo.Products", new[] { "CategoryId" });
            DropIndex("dbo.OrderDetails", new[] { "UserId" });
            DropIndex("dbo.OrderDetails", new[] { "ProductId" });
            DropTable("dbo.TransactionDetails");
            DropTable("dbo.Products");
            DropTable("dbo.OrderDetails");
            DropTable("dbo.Merchants");
            DropTable("dbo.Customers");
            DropTable("dbo.Categories");
            DropTable("dbo.Carts");
        }
    }
}
