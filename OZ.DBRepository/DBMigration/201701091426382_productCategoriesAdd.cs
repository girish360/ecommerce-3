namespace OZ.DBRepository.DBMigration
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class productCategoriesAdd : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ProductCategories",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        ProductID = c.Guid(nullable: false),
                        CategroyID = c.Guid(nullable: false),
                        Status = c.Byte(nullable: false),
                        CreateDatetime = c.DateTime(nullable: false),
                        UpdateDatetime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ProductCategories");
        }
    }
}
