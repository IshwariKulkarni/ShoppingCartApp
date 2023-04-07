namespace ShoppingCartApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class typechange : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.TransactionDetails", "OrderId", "dbo.OrderDetails");
            DropForeignKey("dbo.OrderDetails", "ProductId", "dbo.Products");
            DropIndex("dbo.OrderDetails", new[] { "ProductId" });
            DropIndex("dbo.TransactionDetails", new[] { "OrderId" });
            DropPrimaryKey("dbo.OrderDetails");
            DropPrimaryKey("dbo.Products");
            AlterColumn("dbo.OrderDetails", "OrderId", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.OrderDetails", "ProductId", c => c.Int(nullable: false));
            AlterColumn("dbo.Products", "ProductId", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.TransactionDetails", "OrderId", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.OrderDetails", "OrderId");
            AddPrimaryKey("dbo.Products", "ProductId");
            CreateIndex("dbo.OrderDetails", "ProductId");
            CreateIndex("dbo.TransactionDetails", "OrderId");
            AddForeignKey("dbo.TransactionDetails", "OrderId", "dbo.OrderDetails", "OrderId", cascadeDelete: true);
            AddForeignKey("dbo.OrderDetails", "ProductId", "dbo.Products", "ProductId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OrderDetails", "ProductId", "dbo.Products");
            DropForeignKey("dbo.TransactionDetails", "OrderId", "dbo.OrderDetails");
            DropIndex("dbo.TransactionDetails", new[] { "OrderId" });
            DropIndex("dbo.OrderDetails", new[] { "ProductId" });
            DropPrimaryKey("dbo.Products");
            DropPrimaryKey("dbo.OrderDetails");
            AlterColumn("dbo.TransactionDetails", "OrderId", c => c.String(maxLength: 128));
            AlterColumn("dbo.Products", "ProductId", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.OrderDetails", "ProductId", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.OrderDetails", "OrderId", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.Products", "ProductId");
            AddPrimaryKey("dbo.OrderDetails", "OrderId");
            CreateIndex("dbo.TransactionDetails", "OrderId");
            CreateIndex("dbo.OrderDetails", "ProductId");
            AddForeignKey("dbo.OrderDetails", "ProductId", "dbo.Products", "ProductId", cascadeDelete: true);
            AddForeignKey("dbo.TransactionDetails", "OrderId", "dbo.OrderDetails", "OrderId");
        }
    }
}
