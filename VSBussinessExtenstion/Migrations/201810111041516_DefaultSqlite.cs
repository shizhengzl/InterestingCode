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
                        DataBaseName = c.String(),
                        DataBaseDescription = c.String(),
                        TableName = c.String(),
                        TableDescription = c.String(),
                        TableType = c.String(),
                        ColumnName = c.String(),
                        ColumnDescription = c.String(),
                        ColumnType = c.String(),
                        IsIdentity = c.Boolean(),
                        IsParmarykey = c.Boolean(),
                        MaxLength = c.Int(),
                        IsRequire = c.Boolean(),
                        Scale = c.Byte(),
                        DefaultValue = c.String(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                        Table_Id = c.Int(),
                        DataBase_Id = c.Int(),
                        DataBaseAddress_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.DataBaseAddresses", t => t.Table_Id)
                .ForeignKey("dbo.DataBaseAddresses", t => t.DataBase_Id)
                .ForeignKey("dbo.DataBaseAddresses", t => t.DataBaseAddress_Id)
                .Index(t => t.Table_Id)
                .Index(t => t.DataBase_Id)
                .Index(t => t.DataBaseAddress_Id);
            
            CreateTable(
                "dbo.DataTypeConfigs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Type = c.Int(nullable: false),
                        DBType = c.String(),
                        CSharpType = c.String(),
                        SQLDBType = c.String(),
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
            DropForeignKey("dbo.DataBaseAddresses", "DataBaseAddress_Id", "dbo.DataBaseAddresses");
            DropForeignKey("dbo.DataBaseAddresses", "DataBase_Id", "dbo.DataBaseAddresses");
            DropForeignKey("dbo.DataBaseAddresses", "Table_Id", "dbo.DataBaseAddresses");
            DropIndex("dbo.DataBaseAddresses", new[] { "DataBaseAddress_Id" });
            DropIndex("dbo.DataBaseAddresses", new[] { "DataBase_Id" });
            DropIndex("dbo.DataBaseAddresses", new[] { "Table_Id" });
            DropTable("dbo.Variables");
            DropTable("dbo.SQLConfigs");
            DropTable("dbo.DataTypeConfigs");
            DropTable("dbo.DataBaseAddresses");
            DropTable("dbo.ConnectionStrings");
        }
    }
}
