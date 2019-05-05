namespace VSBussinessExtenstion.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initdatabases_01 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Control",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ControlName = c.String(),
                        ControlText = c.String(),
                        CsharpType = c.String(),
                        ControlMode = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            DropTable("dbo.ConnectionString");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.ConnectionString",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Type = c.Int(nullable: false),
                        Connection = c.String(),
                        WindowsAuthentication = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            DropTable("dbo.Control");
        }
    }
}
