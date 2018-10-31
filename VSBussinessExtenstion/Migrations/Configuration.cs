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

            context.DataTypeConfigs.RemoveRange(context.DataTypeConfigs.ToList());
            context.DataTypeConfigs.Add(new DataTypeConfig()
            {
                Type = Core.UsuallyCommon.DataBaseType.SQLServer
                ,
                SQLDBType = "SqlDbType.Int",
                CSharpType = "Int64",
                SQLServerType = "bigint",
                MySqlType = "",
                OracleType = "",
                SQLiteType = ""
            });

            context.DataTypeConfigs.Add(new DataTypeConfig()
            {
                Type = Core.UsuallyCommon.DataBaseType.SQLServer
                ,
                SQLDBType = "SqlDbType.Binary",
                CSharpType = "Object",
                SQLServerType = "binary",
                MySqlType = "",
                OracleType = "",
                SQLiteType = ""
            });

            context.DataTypeConfigs.Add(new DataTypeConfig()
            {
                Type = Core.UsuallyCommon.DataBaseType.SQLServer
              ,
                SQLDBType = "SqlDbType.Bit",
                CSharpType = "Boolean",
                SQLServerType = "bit",
                MySqlType = "",
                OracleType = "",
                SQLiteType = ""
            });


            context.DataTypeConfigs.Add(new DataTypeConfig()
            {
                Type = Core.UsuallyCommon.DataBaseType.SQLServer
         ,
                SQLDBType = "SqlDbType.Char",
                CSharpType = "String",
                SQLServerType = "char",
                MySqlType = "",
                OracleType = "",
                SQLiteType = ""
            });

            context.DataTypeConfigs.Add(new DataTypeConfig()
            {
                Type = Core.UsuallyCommon.DataBaseType.SQLServer
         ,
                SQLDBType = "SqlDbType.DateTime",
                CSharpType = "DateTime",
                SQLServerType = "datetime",
                MySqlType = "",
                OracleType = "",
                SQLiteType = ""
            });


            context.DataTypeConfigs.Add(new DataTypeConfig()
            {
                Type = Core.UsuallyCommon.DataBaseType.SQLServer
     ,
                SQLDBType = "SqlDbType.Decimal",
                CSharpType = "Decimal",
                SQLServerType = "decimal",
                MySqlType = "",
                OracleType = "",
                SQLiteType = ""
            });

            context.DataTypeConfigs.Add(new DataTypeConfig()
            {
                Type = Core.UsuallyCommon.DataBaseType.SQLServer
,
                SQLDBType = "SqlDbType.Float",
                CSharpType = "Double",
                SQLServerType = "float",
                MySqlType = "",
                OracleType = "",
                SQLiteType = ""
            });

            context.DataTypeConfigs.Add(new DataTypeConfig()
            {
                Type = Core.UsuallyCommon.DataBaseType.SQLServer
,
                SQLDBType = "SqlDbType.UniqueIdentifier",
                CSharpType = "Guid",
                SQLServerType = "uniqueidentifier",
                MySqlType = "",
                OracleType = "",
                SQLiteType = ""
            });

            context.DataTypeConfigs.Add(new DataTypeConfig()
            {
                Type = Core.UsuallyCommon.DataBaseType.SQLServer
,
                SQLDBType = "SqlDbType.Int32",
                CSharpType = "Int32",
                SQLServerType = "int",
                MySqlType = "",
                OracleType = "",
                SQLiteType = ""
            });

            context.DataTypeConfigs.Add(new DataTypeConfig()
            {
                Type = Core.UsuallyCommon.DataBaseType.SQLServer
,
                SQLDBType = "SqlDbType.SmallInt",
                CSharpType = "Int16",
                SQLServerType = "smallint",
                MySqlType = "",
                OracleType = "",
                SQLiteType = ""
            });

            context.DataTypeConfigs.Add(new DataTypeConfig()
            {
                Type = Core.UsuallyCommon.DataBaseType.SQLServer
,
                SQLDBType = "SqlDbType.TinyInt",
                CSharpType = "Byte",
                SQLServerType = "tinyint",
                MySqlType = "",
                OracleType = "",
                SQLiteType = ""
            });

            context.DataTypeConfigs.Add(new DataTypeConfig()
            {
                Type = Core.UsuallyCommon.DataBaseType.SQLServer
,
                SQLDBType = "SqlDbType.NVarChar",
                CSharpType = "String",
                SQLServerType = "nvarchar",
                MySqlType = "",
                OracleType = "",
                SQLiteType = ""
            });


            context.DataTypeConfigs.Add(new DataTypeConfig()
            {
                Type = Core.UsuallyCommon.DataBaseType.SQLServer
,
                SQLDBType = "SqlDbType.VarChar",
                CSharpType = "String",
                SQLServerType = "varchar",
                MySqlType = "",
                OracleType = "",
                SQLiteType = ""
            });

            context.DataTypeConfigs.Add(new DataTypeConfig()
            {
                Type = Core.UsuallyCommon.DataBaseType.SQLServer
,
                SQLDBType = "SqlDbType.Text",
                CSharpType = "String",
                SQLServerType = "text",
                MySqlType = "",
                OracleType = "",
                SQLiteType = ""
            });

            context.DataTypeConfigs.Add(new DataTypeConfig()
            {
                Type = Core.UsuallyCommon.DataBaseType.SQLServer
,
                SQLDBType = "SqlDbType.NText",
                CSharpType = "String",
                SQLServerType = "ntext",
                MySqlType = "",
                OracleType = "",
                SQLiteType = ""
            });

            context.DataTypeConfigs.Add(new DataTypeConfig()
            {
                Type = Core.UsuallyCommon.DataBaseType.SQLServer
,
                SQLDBType = "SqlDbType.Image",
                CSharpType = "Byte",
                SQLServerType = "image",
                MySqlType = "",
                OracleType = "",
                SQLiteType = ""
            });


            context.DataTypeConfigs.Add(new DataTypeConfig()
            {
                Type = Core.UsuallyCommon.DataBaseType.SQLServer
,
                SQLDBType = "SqlDbType.Money",
                CSharpType = "Decimal",
                SQLServerType = "money",
                MySqlType = "",
                OracleType = "",
                SQLiteType = ""
            });

            context.DataTypeConfigs.Add(new DataTypeConfig()
            {
                Type = Core.UsuallyCommon.DataBaseType.SQLServer
,
                SQLDBType = "SqlDbType.NChar",
                CSharpType = "String",
                SQLServerType = "nchar",
                MySqlType = "",
                OracleType = "",
                SQLiteType = ""
            });

            context.DataTypeConfigs.Add(new DataTypeConfig()
            {
                Type = Core.UsuallyCommon.DataBaseType.SQLServer
,
                SQLDBType = "SqlDbType.Decimal",
                CSharpType = "Decimal",
                SQLServerType = "numeric",
                MySqlType = "",
                OracleType = "",
                SQLiteType = ""
            });


            context.DataTypeConfigs.Add(new DataTypeConfig()
            {
                Type = Core.UsuallyCommon.DataBaseType.SQLServer
,
                SQLDBType = "SqlDbType.Real",
                CSharpType = "Single",
                SQLServerType = "real",
                MySqlType = "",
                OracleType = "",
                SQLiteType = ""
            });

            context.DataTypeConfigs.Add(new DataTypeConfig()
            {
                Type = Core.UsuallyCommon.DataBaseType.SQLServer
,
                SQLDBType = "SqlDbType.SmallDateTime",
                CSharpType = "DateTime",
                SQLServerType = "smalldatetime",
                MySqlType = "",
                OracleType = "",
                SQLiteType = ""
            });

            context.DataTypeConfigs.Add(new DataTypeConfig()
            {
                Type = Core.UsuallyCommon.DataBaseType.SQLServer
,
                SQLDBType = "SqlDbType.SmallMoney",
                CSharpType = "Decimal",
                SQLServerType = "smallmoney",
                MySqlType = "",
                OracleType = "",
                SQLiteType = ""
            });

            context.DataTypeConfigs.Add(new DataTypeConfig()
            {
                Type = Core.UsuallyCommon.DataBaseType.SQLServer
,
                SQLDBType = "SqlDbType.Timestamp",
                CSharpType = "Byte",
                SQLServerType = "timestamp",
                MySqlType = "",
                OracleType = "",
                SQLiteType = ""
            });

            context.DataTypeConfigs.Add(new DataTypeConfig()
            {
                Type = Core.UsuallyCommon.DataBaseType.SQLServer
,
                SQLDBType = "SqlDbType.VarBinary",
                CSharpType = "Byte",
                SQLServerType = "varbinary",
                MySqlType = "",
                OracleType = "",
                SQLiteType = ""
            });
            context.DataTypeConfigs.Add(new DataTypeConfig()
            {
                Type = Core.UsuallyCommon.DataBaseType.SQLServer
,
                SQLDBType = "SqlDbType.String",
                CSharpType = "String",
                SQLServerType = "xml",
                MySqlType = "",
                OracleType = "",
                SQLiteType = ""
            });

            context.DataTypeConfigs.Add(new DataTypeConfig()
            {
                Type = Core.UsuallyCommon.DataBaseType.SQLServer
,
                SQLDBType = "SqlDbType.Variant",
                CSharpType = "Object",
                SQLServerType = "sql_variant",
                MySqlType = "",
                OracleType = "",
                SQLiteType = ""
            });

            

            context.ConnectionStrings.RemoveRange(context.ConnectionStrings.ToList());
            context.ConnectionStrings.Add(new ConnectionString() { Type = Core.UsuallyCommon.DataBaseType.SQLServer, WindowsAuthentication = false, Connection = "SERVER={0};UID={1};PWD={2};DATABASE={3}" });

            context.SQLConfigs.RemoveRange(context.SQLConfigs.ToList());
            context.SQLConfigs.Add(new SQLConfig()
            {
                Type = Core.UsuallyCommon.DataBaseType.SQLServer,
                GetDataBaseSQL = "SELECT name AS DataBaseName FROM sys.sysdatabases ORDER BY name",
                GetTableSQL = "USE @DataBaseName SELECT name AS TableName FROM sys.tables ORDER BY name",
                GetColumnSQL = @"USE @DataBaseName  SELECT a.name as ColumnName,b.name AS Type FROM sys.columns a INNER JOIN sys.types b 
                                 ON a.system_type_id = b.system_type_id  AND a.user_type_id = b.user_type_id WHERE OBJECT_ID = OBJECT_ID('@TableName')"
            });

            context.DataBaseAddresses.RemoveRange(context.DataBaseAddresses.ToList());
            context.DataBaseAddresses.Add(new Core.UsuallyCommon.DataBase.DataBaseAddress() { Address = ".", Password = "95938", User = "sa", DefaultDatabase = "", DBType = Core.UsuallyCommon.DataBaseType.SQLServer });

            context.Snippets.RemoveRange(context.Snippets.ToList());

            var databasedemo = new Snippet() { DataSourceType = DataSourceType.DatabaseType, IsFloder = true, Name = "DataBase Demo Folder" };
            context.Snippets.Add(databasedemo);
            context.SaveChanges();
            context.Snippets.Add(new Snippet() { DataSourceType = DataSourceType.DatabaseType, OutputPath=@"C:\Generator", IsFloder = false, Name = "DataBase Demo", GeneratorFileName = "@TableName.cs", IsEnabled = true, ParentId = databasedemo.Id, Context = @"public class @TableName{
                <%! public @ColumnType @ColumnName 
                !%> 
            }" });

            var csharpdemo = new Snippet() { DataSourceType = DataSourceType.CSharpType, IsFloder = true, Name = "Csharp Demo Folder" };
            context.Snippets.Add(csharpdemo);
            context.SaveChanges();
            context.Snippets.Add(new Snippet() { DataSourceType = DataSourceType.CSharpType, IsFloder = false, Name = "Csharp Demo", GeneratorFileName = "@ClassName.cs", IsEnabled = true, ParentId = csharpdemo.Id, Context = @" this is className:@ClassName 
            this is Propertys <%! @PropertyName !%>" });


            var xmldemo = new Snippet() { DataSourceType = DataSourceType.XMLType, IsFloder = true, Name = "XML Demo Folder" };
            context.Snippets.Add(xmldemo);
            context.SaveChanges();
            context.Snippets.Add(new Snippet() { DataSourceType = DataSourceType.XMLType, IsFloder = false, Name = "XML Demo", GeneratorFileName = "@DocumentName.cs", IsEnabled = true, ParentId = xmldemo.Id, Context = @" this is className:@ClassName 
            this is Propertys <%! @PropertyName !%>" });

            context.Snippets.Add(new Snippet() { DataSourceType = DataSourceType.StringType, IsFloder = true, Name = "String Demo" });

        }
    }
}
