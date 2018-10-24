namespace VSBussinessExtenstion.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DefaultSqlite : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ConnectionStrings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Type = c.Int(nullable: false),
                        Connection = c.String(),
                        WindowsAuthentication = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.DataBaseAddresses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Address = c.String(),
                        User = c.String(),
                        Password = c.String(),
                        DBType = c.Int(nullable: false),
                        DefaultDatabase = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.DataTypeConfigs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Type = c.Int(nullable: false),
                        SQLServerType = c.String(),
                        MySqlType = c.String(),
                        OracleType = c.String(),
                        SQLiteType = c.String(),
                        CSharpType = c.String(),
                        SQLDBType = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Snippets",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        ParentId = c.Int(nullable: false),
                        DataSourceType = c.Int(nullable: false),
                        Context = c.String(),
                        OutputPath = c.String(),
                        GeneratorFileName = c.String(),
                        IsFloder = c.Boolean(nullable: false),
                        IsEnabled = c.Boolean(nullable: false),
                        IsMergin = c.Boolean(nullable: false),
                        IsAutoFind = c.Boolean(nullable: false),
                        IsSelectGenerator = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SQLConfigs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Type = c.Int(nullable: false),
                        GetDataBaseSQL = c.String(),
                        GetTableSQL = c.String(),
                        GetColumnSQL = c.String(),
                        GetProducuteSQL = c.String(),
                        GetViewSQL = c.String(),
                        GetIndexSQL = c.String(),
                        GetSYNONYMSQL = c.String(),
                        GetWhereSQL = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Variables",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        VariableName = c.String(),
                        ReplaceProperty = c.String(),
                        ReplaceString = c.String(),
                        FirstChar = c.Int(nullable: false),
                        IsSystemGenerator = c.Boolean(nullable: false),
                        VariableType = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Variables");
            DropTable("dbo.SQLConfigs");
            DropTable("dbo.Snippets");
            DropTable("dbo.DataTypeConfigs");
            DropTable("dbo.DataBaseAddresses");
            DropTable("dbo.ConnectionStrings");
        }
    }
}
