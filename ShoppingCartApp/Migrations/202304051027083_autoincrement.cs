namespace ShoppingCartApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class autoincrement : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.OrderDetails", "UserId", "dbo.Customers");
            DropPrimaryKey("dbo.Customers");
            AlterColumn("dbo.Customers", "UserId", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.Customers", "UserId");
            AddForeignKey("dbo.OrderDetails", "UserId", "dbo.Customers", "UserId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OrderDetails", "UserId", "dbo.Customers");
            DropPrimaryKey("dbo.Customers");
            AlterColumn("dbo.Customers", "UserId", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.Customers", "UserId");
            AddForeignKey("dbo.OrderDetails", "UserId", "dbo.Customers", "UserId", cascadeDelete: true);
        }
    }
}
