namespace OZ.DBRepository.DBMigration
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OrderIDChange : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.OrderItems", "Order_ID", "dbo.Orders");
            DropIndex("dbo.OrderItems", new[] { "Order_ID" });
            AlterColumn("dbo.Orders", "FamilyName", c => c.String(nullable: false));
            DropTable("dbo.OrderItems");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.OrderItems",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        ProductID = c.Guid(nullable: false),
                        Quantity = c.Int(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Status = c.Byte(nullable: false),
                        CreateDatetime = c.DateTime(nullable: false),
                        UpdateDatetime = c.DateTime(nullable: false),
                        Order_ID = c.Guid(),
                    })
                .PrimaryKey(t => t.ID);
            
            AlterColumn("dbo.Orders", "FamilyName", c => c.String());
            CreateIndex("dbo.OrderItems", "Order_ID");
            AddForeignKey("dbo.OrderItems", "Order_ID", "dbo.Orders", "ID");
        }
    }
}
