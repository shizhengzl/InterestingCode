namespace VSBussinessExtenstion.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DefaultSqlite : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ConnectionStrings", "WindowsAuthentication", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ConnectionStrings", "WindowsAuthentication");
        }
    }
}
