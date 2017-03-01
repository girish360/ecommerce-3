namespace OZ.DBRepository.DBMigration
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class parentProperty : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Categories", "ParentID", c => c.Guid());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Categories", "ParentID", c => c.Guid(nullable: false));
        }
    }
}
