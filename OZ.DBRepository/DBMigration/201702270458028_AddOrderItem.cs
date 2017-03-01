namespace OZ.DBRepository.DBMigration
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddOrderItem : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.OrderItems",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        ProductID = c.Guid(nullable: false),
                        Quantity = c.Int(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        OrderID = c.Guid(nullable: false),
                        Status = c.Byte(nullable: false),
                        CreateDatetime = c.DateTime(nullable: false),
                        UpdateDatetime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.OrderItems");
        }
    }
}
