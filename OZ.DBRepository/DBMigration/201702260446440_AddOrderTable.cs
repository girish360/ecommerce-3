namespace OZ.DBRepository.DBMigration
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddOrderTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        FirstName = c.String(),
                        GivenName = c.String(),
                        Address = c.String(),
                        Email = c.String(),
                        Status = c.Byte(nullable: false),
                        CreateDatetime = c.DateTime(nullable: false),
                        UpdateDatetime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
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
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Orders", t => t.Order_ID)
                .Index(t => t.Order_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OrderItems", "Order_ID", "dbo.Orders");
            DropIndex("dbo.OrderItems", new[] { "Order_ID" });
            DropTable("dbo.OrderItems");
            DropTable("dbo.Orders");
        }
    }
}
