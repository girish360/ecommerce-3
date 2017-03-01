namespace OZ.DBRepository.DBMigration
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FamilyNameChange : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "FamilyName", c => c.String());
            DropColumn("dbo.Orders", "FirstName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Orders", "FirstName", c => c.String());
            DropColumn("dbo.Orders", "FamilyName");
        }
    }
}
