namespace VSBussinessExtenstion.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addcolumns : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Control", "IsDefault", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Control", "IsDefault");
        }
    }
}
