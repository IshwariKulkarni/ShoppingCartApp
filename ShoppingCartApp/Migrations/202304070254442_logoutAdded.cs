namespace ShoppingCartApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class logoutAdded : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.OrderDetails", "UserId", "dbo.Customers");
            DropForeignKey("dbo.TransactionDetails", "OrderId", "dbo.OrderDetails");
            DropForeignKey("dbo.OrderDetails", "ProductId", "dbo.Products");
            DropIndex("dbo.OrderDetails", new[] { "UserId" });
            DropPrimaryKey("dbo.Customers");
            DropPrimaryKey("dbo.Merchants");
            DropPrimaryKey("dbo.OrderDetails");
            DropPrimaryKey("dbo.Products");
            AddColumn("dbo.Customers", "ConfirmPassword", c => c.String());
            AddColumn("dbo.Merchants", "ConfirmMerchPassword", c => c.String());
            AlterColumn("dbo.Customers", "UserId", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Merchants", "MerchantId", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.OrderDetails", "OrderId", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.OrderDetails", "UserId", c => c.Int(nullable: false));
            AlterColumn("dbo.Products", "ProductId", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.Customers", "UserId");
            AddPrimaryKey("dbo.Merchants", "MerchantId");
            AddPrimaryKey("dbo.OrderDetails", "OrderId");
            AddPrimaryKey("dbo.Products", "ProductId");
            CreateIndex("dbo.OrderDetails", "UserId");
            AddForeignKey("dbo.OrderDetails", "UserId", "dbo.Customers", "UserId", cascadeDelete: true);
            AddForeignKey("dbo.TransactionDetails", "OrderId", "dbo.OrderDetails", "OrderId");
            AddForeignKey("dbo.OrderDetails", "ProductId", "dbo.Products", "ProductId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OrderDetails", "ProductId", "dbo.Products");
            DropForeignKey("dbo.TransactionDetails", "OrderId", "dbo.OrderDetails");
            DropForeignKey("dbo.OrderDetails", "UserId", "dbo.Customers");
            DropIndex("dbo.OrderDetails", new[] { "UserId" });
            DropPrimaryKey("dbo.Products");
            DropPrimaryKey("dbo.OrderDetails");
            DropPrimaryKey("dbo.Merchants");
            DropPrimaryKey("dbo.Customers");
            AlterColumn("dbo.Products", "ProductId", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.OrderDetails", "UserId", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.OrderDetails", "OrderId", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Merchants", "MerchantId", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Customers", "UserId", c => c.String(nullable: false, maxLength: 128));
            DropColumn("dbo.Merchants", "ConfirmMerchPassword");
            DropColumn("dbo.Customers", "ConfirmPassword");
            AddPrimaryKey("dbo.Products", "ProductId");
            AddPrimaryKey("dbo.OrderDetails", "OrderId");
            AddPrimaryKey("dbo.Merchants", "MerchantId");
            AddPrimaryKey("dbo.Customers", "UserId");
            CreateIndex("dbo.OrderDetails", "UserId");
            AddForeignKey("dbo.OrderDetails", "ProductId", "dbo.Products", "ProductId", cascadeDelete: true);
            AddForeignKey("dbo.TransactionDetails", "OrderId", "dbo.OrderDetails", "OrderId");
            AddForeignKey("dbo.OrderDetails", "UserId", "dbo.Customers", "UserId", cascadeDelete: true);
        }
    }
}
