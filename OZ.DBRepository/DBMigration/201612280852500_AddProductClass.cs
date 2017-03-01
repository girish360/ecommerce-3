namespace OZ.DBRepository.DBMigration
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddProductClass : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        Title = c.String(),
                        Description = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Status = c.Byte(nullable: false),
                        CreateDatetime = c.DateTime(nullable: false),
                        UpdateDatetime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Products");
        }
    }
}
