namespace VSBussinessExtenstion.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddColumns : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Control", "NeedDataSource", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Control", "NeedDataSource");
        }
    }
}
