namespace OZ.DBRepository.DBMigration
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class detailNameProperty : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Categories", "DetailName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Categories", "DetailName");
        }
    }
}
