namespace VSBussinessExtenstion.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initdatabase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ConnectionString",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Type = c.Int(nullable: false),
                        Connection = c.String(unicode: false),
                        WindowsAuthentication = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.DataBaseAddress",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Address = c.String(unicode: false),
                        User = c.String(unicode: false),
                        Password = c.String(unicode: false),
                        DBType = c.Int(nullable: false),
                        ConnectionStrings = c.String(unicode: false),
                        DefaultDatabase = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.DataTypeConfig",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SQLServerType = c.String(unicode: false),
                        MySqlType = c.String(unicode: false),
                        OracleType = c.String(unicode: false),
                        SQLiteType = c.String(unicode: false),
                        CSharpType = c.String(unicode: false),
                        SQLDBType = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Intellisence",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StartChar = c.String(unicode: false),
                        DisplayText = c.String(unicode: false),
                        InsertionText = c.String(unicode: false),
                        Description = c.String(unicode: false),
                        DefinedSql = c.String(unicode: false),
                        ConnectionString = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Snippet",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(unicode: false),
                        ParentId = c.Int(nullable: false),
                        DataSourceType = c.Int(nullable: false),
                        Context = c.String(unicode: false),
                        OutputPath = c.String(unicode: false),
                        GeneratorFileName = c.String(unicode: false),
                        IsFloder = c.Boolean(nullable: false),
                        IsEnabled = c.Boolean(nullable: false),
                        IsMergin = c.Boolean(nullable: false),
                        IsAutoFind = c.Boolean(nullable: false),
                        IsSelectGenerator = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SQLConfig",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Type = c.Int(nullable: false),
                        GetDataBaseSQL = c.String(unicode: false),
                        GetTableSQL = c.String(unicode: false),
                        GetColumnSQL = c.String(unicode: false),
                        GetProducuteSQL = c.String(unicode: false),
                        GetViewSQL = c.String(unicode: false),
                        GetIndexSQL = c.String(unicode: false),
                        GetSYNONYMSQL = c.String(unicode: false),
                        GetWhereSQL = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Variable",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        VariableName = c.String(unicode: false),
                        ReplaceProperty = c.String(unicode: false),
                        ReplaceString = c.String(unicode: false),
                        FirstChar = c.Int(nullable: false),
                        IsSystemGenerator = c.Boolean(nullable: false),
                        VariableType = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Variable");
            DropTable("dbo.SQLConfig");
            DropTable("dbo.Snippet");
            DropTable("dbo.Intellisence");
            DropTable("dbo.DataTypeConfig");
            DropTable("dbo.DataBaseAddress");
            DropTable("dbo.ConnectionString");
        }
    }
}
