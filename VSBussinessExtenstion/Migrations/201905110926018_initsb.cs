namespace VSBussinessExtenstion.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initsb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ControlDataSource",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DataSourceUrl = c.String(unicode: false),
                        DataSourceName = c.String(unicode: false),
                        DataSourceInit = c.String(unicode: false),
                        DataSourceKey = c.String(unicode: false),
                        DataSourceVlaue = c.String(unicode: false),
                        DataSourceParentId = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Control", "ControlDataSources_Id", c => c.Int());
            CreateIndex("dbo.Control", "ControlDataSources_Id");
            AddForeignKey("dbo.Control", "ControlDataSources_Id", "dbo.ControlDataSource", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Control", "ControlDataSources_Id", "dbo.ControlDataSource");
            DropIndex("dbo.Control", new[] { "ControlDataSources_Id" });
            DropColumn("dbo.Control", "ControlDataSources_Id");
            DropTable("dbo.ControlDataSource");
        }
    }
}
