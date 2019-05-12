namespace VSBussinessExtenstion.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class appcodes : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Control", "AppendCodeUrl", c => c.String(unicode: false));
            AddColumn("dbo.Control", "AppendCode", c => c.String(unicode: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Control", "AppendCode");
            DropColumn("dbo.Control", "AppendCodeUrl");
        }
    }
}
