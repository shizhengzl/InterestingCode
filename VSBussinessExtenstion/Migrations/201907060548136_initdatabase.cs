namespace VSBussinessExtenstion.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initdatabase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CodeAppend",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsAppend = c.Boolean(nullable: false),
                        IsMethod = c.Boolean(nullable: false),
                        IsProperty = c.Boolean(nullable: false),
                        IsAnyCode = c.Boolean(nullable: false),
                        AppendUrl = c.String(unicode: false),
                        AppendCode = c.String(unicode: false),
                        ParentSnippetId = c.Int(nullable: false),
                        ListSnippets = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Snippet", "IsMultipleTable", c => c.Boolean(nullable: false));
            AddColumn("dbo.Snippet", "IsAppendSnippet", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Snippet", "IsAppendSnippet");
            DropColumn("dbo.Snippet", "IsMultipleTable");
            DropTable("dbo.CodeAppend");
        }
    }
}
