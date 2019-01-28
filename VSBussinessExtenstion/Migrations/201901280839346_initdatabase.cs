namespace VSBussinessExtenstion.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initdatabase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Intellisences",
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
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Intellisences");
        }
    }
}
