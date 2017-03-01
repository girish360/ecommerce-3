namespace OZ.DBRepository.DBMigration
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddOrderNavigation : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.OrderItems", "OrderID");
            AddForeignKey("dbo.OrderItems", "OrderID", "dbo.Orders", "ID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OrderItems", "OrderID", "dbo.Orders");
            DropIndex("dbo.OrderItems", new[] { "OrderID" });
        }
    }
}
