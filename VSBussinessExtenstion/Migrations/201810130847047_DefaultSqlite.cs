namespace VSBussinessExtenstion.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DefaultSqlite : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.DataBaseAddresses", "Table_Id", "dbo.DataBaseAddresses");
            DropForeignKey("dbo.DataBaseAddresses", "DataBase_Id", "dbo.DataBaseAddresses");
            DropForeignKey("dbo.DataBaseAddresses", "DataBaseAddress_Id", "dbo.DataBaseAddresses");
            DropIndex("dbo.DataBaseAddresses", new[] { "Table_Id" });
            DropIndex("dbo.DataBaseAddresses", new[] { "DataBase_Id" });
            DropIndex("dbo.DataBaseAddresses", new[] { "DataBaseAddress_Id" });
            DropColumn("dbo.DataBaseAddresses", "DataBaseName");
            DropColumn("dbo.DataBaseAddresses", "DataBaseDescription");
            DropColumn("dbo.DataBaseAddresses", "TableName");
            DropColumn("dbo.DataBaseAddresses", "TableDescription");
            DropColumn("dbo.DataBaseAddresses", "TableType");
            DropColumn("dbo.DataBaseAddresses", "ColumnName");
            DropColumn("dbo.DataBaseAddresses", "ColumnDescription");
            DropColumn("dbo.DataBaseAddresses", "ColumnType");
            DropColumn("dbo.DataBaseAddresses", "IsIdentity");
            DropColumn("dbo.DataBaseAddresses", "IsParmarykey");
            DropColumn("dbo.DataBaseAddresses", "MaxLength");
            DropColumn("dbo.DataBaseAddresses", "IsRequire");
            DropColumn("dbo.DataBaseAddresses", "Scale");
            DropColumn("dbo.DataBaseAddresses", "DefaultValue");
            DropColumn("dbo.DataBaseAddresses", "Discriminator");
            DropColumn("dbo.DataBaseAddresses", "Table_Id");
            DropColumn("dbo.DataBaseAddresses", "DataBase_Id");
            DropColumn("dbo.DataBaseAddresses", "DataBaseAddress_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.DataBaseAddresses", "DataBaseAddress_Id", c => c.Int());
            AddColumn("dbo.DataBaseAddresses", "DataBase_Id", c => c.Int());
            AddColumn("dbo.DataBaseAddresses", "Table_Id", c => c.Int());
            AddColumn("dbo.DataBaseAddresses", "Discriminator", c => c.String(nullable: false, maxLength: 128));
            AddColumn("dbo.DataBaseAddresses", "DefaultValue", c => c.String());
            AddColumn("dbo.DataBaseAddresses", "Scale", c => c.Byte());
            AddColumn("dbo.DataBaseAddresses", "IsRequire", c => c.Boolean());
            AddColumn("dbo.DataBaseAddresses", "MaxLength", c => c.Int());
            AddColumn("dbo.DataBaseAddresses", "IsParmarykey", c => c.Boolean());
            AddColumn("dbo.DataBaseAddresses", "IsIdentity", c => c.Boolean());
            AddColumn("dbo.DataBaseAddresses", "ColumnType", c => c.String());
            AddColumn("dbo.DataBaseAddresses", "ColumnDescription", c => c.String());
            AddColumn("dbo.DataBaseAddresses", "ColumnName", c => c.String());
            AddColumn("dbo.DataBaseAddresses", "TableType", c => c.String());
            AddColumn("dbo.DataBaseAddresses", "TableDescription", c => c.String());
            AddColumn("dbo.DataBaseAddresses", "TableName", c => c.String());
            AddColumn("dbo.DataBaseAddresses", "DataBaseDescription", c => c.String());
            AddColumn("dbo.DataBaseAddresses", "DataBaseName", c => c.String());
            CreateIndex("dbo.DataBaseAddresses", "DataBaseAddress_Id");
            CreateIndex("dbo.DataBaseAddresses", "DataBase_Id");
            CreateIndex("dbo.DataBaseAddresses", "Table_Id");
            AddForeignKey("dbo.DataBaseAddresses", "DataBaseAddress_Id", "dbo.DataBaseAddresses", "Id");
            AddForeignKey("dbo.DataBaseAddresses", "DataBase_Id", "dbo.DataBaseAddresses", "Id");
            AddForeignKey("dbo.DataBaseAddresses", "Table_Id", "dbo.DataBaseAddresses", "Id");
        }
    }
}
