namespace VSBussinessExtenstion.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initdatabases : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.ConnectionStrings", newName: "ConnectionString");
            RenameTable(name: "dbo.DataBaseAddresses", newName: "DataBaseAddress");
            RenameTable(name: "dbo.DataTypeConfigs", newName: "DataTypeConfig");
            RenameTable(name: "dbo.Intellisences", newName: "Intellisence");
            RenameTable(name: "dbo.Snippets", newName: "Snippet");
            RenameTable(name: "dbo.SQLConfigs", newName: "SQLConfig");
            RenameTable(name: "dbo.Variables", newName: "Variable");
            AddColumn("dbo.DataBaseAddress", "ConnectionStrings", c => c.String());
            DropColumn("dbo.DataTypeConfig", "Type");
        }
        
        public override void Down()
        {
            AddColumn("dbo.DataTypeConfig", "Type", c => c.Int(nullable: false));
            DropColumn("dbo.DataBaseAddress", "ConnectionStrings");
            RenameTable(name: "dbo.Variable", newName: "Variables");
            RenameTable(name: "dbo.SQLConfig", newName: "SQLConfigs");
            RenameTable(name: "dbo.Snippet", newName: "Snippets");
            RenameTable(name: "dbo.Intellisence", newName: "Intellisences");
            RenameTable(name: "dbo.DataTypeConfig", newName: "DataTypeConfigs");
            RenameTable(name: "dbo.DataBaseAddress", newName: "DataBaseAddresses");
            RenameTable(name: "dbo.ConnectionString", newName: "ConnectionStrings");
        }
    }
}
