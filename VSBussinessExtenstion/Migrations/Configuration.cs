namespace VSBussinessExtenstion.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<VSBussinessExtenstion.DefaultSqlite>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(VSBussinessExtenstion.DefaultSqlite context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            context.ConnectionStrings.RemoveRange(context.ConnectionStrings.ToList());
            context.ConnectionStrings.Add(new ConnectionString() { Type = Core.UsuallyCommon.DataBaseType.SQLServer,WindowsAuthentication = false, Connection = "SERVER={0};UID={1};PWD={2};DATABASE={3}" });

            context.SQLConfigs.RemoveRange(context.SQLConfigs.ToList());
            context.SQLConfigs.Add(new SQLConfig() {
                Type = Core.UsuallyCommon.DataBaseType.SQLServer,
                GetDataBaseSQL = "SELECT name AS DataBaseName FROM sys.sysdatabases ORDER BY name",
                GetTableSQL = "USE @DataBaseName SELECT name AS TableName FROM sys.tables ORDER BY name",
                GetColumnSQL = ""
            });

            context.DataBaseAddresses.RemoveRange(context.DataBaseAddresses.ToList());
            context.DataBaseAddresses.Add(new Core.UsuallyCommon.DataBase.DataBaseAddress() {  Address=".", Password="95938",User="sa",DefaultDatabase= "", DBType = Core.UsuallyCommon.DataBaseType.SQLServer});

            context.Snippets.RemoveRange(context.Snippets.ToList());

            var databasedemo = new Snippet() { DataSourceType = DataSourceType.DatabaseType, IsFloder = true, Name = "DataBase Demo Folder" };
            context.Snippets.Add(databasedemo);
            context.SaveChanges();
            context.Snippets.Add(new Snippet() { DataSourceType = DataSourceType.DatabaseType, IsFloder = false, Name = "DataBase Demo", GeneratorFileName="@TableName.cs", IsEnabled=true, ParentId = databasedemo.Id,Context = @"public class @TableName{
                <%! public @CsharpType @ColumnName 
                !%> 
            }"});

            var csharpdemo = new Snippet() { DataSourceType = DataSourceType.CSharpType, IsFloder = true, Name = "Csharp Demo Folder" };
            context.Snippets.Add(csharpdemo); 
            context.SaveChanges();
            context.Snippets.Add(new Snippet() { DataSourceType = DataSourceType.CSharpType, IsFloder = false, Name = "Csharp Demo", GeneratorFileName = "@ClassName.cs", IsEnabled = true, ParentId = csharpdemo.Id, Context = @" this is className:@ClassName 
            this is Propertys <%! @PropertyName !%>"});


            var xmldemo = new Snippet() { DataSourceType = DataSourceType.XMLType, IsFloder = true, Name = "XML Demo Folder" };
            context.Snippets.Add(xmldemo);
            context.SaveChanges();
            context.Snippets.Add(new Snippet() { DataSourceType = DataSourceType.XMLType, IsFloder = false, Name = "XML Demo", GeneratorFileName = "@DocumentName.cs", IsEnabled = true, ParentId = xmldemo.Id, Context = @" this is className:@ClassName 
            this is Propertys <%! @PropertyName !%>" });

            context.Snippets.Add(new Snippet() { DataSourceType = DataSourceType.StringType, IsFloder = true, Name = "String Demo" });

        }
    }
}
