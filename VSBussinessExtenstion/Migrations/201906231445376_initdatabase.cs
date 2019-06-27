namespace VSBussinessExtenstion.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initdatabase : DbMigration
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
                        IsDefault = c.Boolean(nullable: false),
                        NeedDataSource = c.Boolean(nullable: false),
                        AppendCodeUrl = c.String(),
                        AppendCode = c.String(),
                        ControlDataSources_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ControlDataSource", t => t.ControlDataSources_Id)
                .Index(t => t.ControlDataSources_Id);
            
            CreateTable(
                "dbo.ControlDataSource",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DataSourceUrl = c.String(),
                        DataSourceName = c.String(),
                        DataSourceInit = c.String(),
                        DataSourceKey = c.String(),
                        DataSourceVlaue = c.String(),
                        DataSourceParentId = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.DataBaseAddress",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Address = c.String(),
                        User = c.String(),
                        Password = c.String(),
                        DBType = c.Int(nullable: false),
                        ConnectionStrings = c.String(),
                        DefaultDatabase = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.DataTypeConfig",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SQLServerType = c.String(),
                        MySqlType = c.String(),
                        OracleType = c.String(),
                        SQLiteType = c.String(),
                        CSharpType = c.String(),
                        SQLDBType = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Intellisence",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StartChar = c.String(),
                        DisplayText = c.String(),
                        InsertionText = c.String(),
                        Description = c.String(),
                        DefinedSql = c.String(),
                        ConnectionString = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Snippet",
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
                "dbo.SQLConfig",
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
                "dbo.Variable",
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
            DropForeignKey("dbo.Control", "ControlDataSources_Id", "dbo.ControlDataSource");
            DropIndex("dbo.Control", new[] { "ControlDataSources_Id" });
            DropTable("dbo.Variable");
            DropTable("dbo.SQLConfig");
            DropTable("dbo.Snippet");
            DropTable("dbo.Intellisence");
            DropTable("dbo.DataTypeConfig");
            DropTable("dbo.DataBaseAddress");
            DropTable("dbo.ControlDataSource");
            DropTable("dbo.Control");
        }
    }
}
