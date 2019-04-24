using Core.UsuallyCommon.DataBase;

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
      
            context.DataTypeConfigs.RemoveRange(context.DataTypeConfigs.ToList());
            context.DataTypeConfigs.Add(new DataTypeConfig()
            { 
                SQLDBType = "SqlDbType.Int",
                CSharpType = "Int64",
                SQLServerType = "bigint",
                MySqlType = "bigint",
                OracleType = "",
                SQLiteType = ""
            });

            context.DataTypeConfigs.Add(new DataTypeConfig()
            { 
                SQLDBType = "SqlDbType.Binary",
                CSharpType = "Object",
                SQLServerType = "binary",
                MySqlType = "binary",
                OracleType = "",
                SQLiteType = ""
            });

            context.DataTypeConfigs.Add(new DataTypeConfig()
            { 
                SQLDBType = "SqlDbType.Bit",
                CSharpType = "Boolean",
                SQLServerType = "bit",
                MySqlType = "bit",
                OracleType = "",
                SQLiteType = ""
            });
             
            context.DataTypeConfigs.Add(new DataTypeConfig()
            { 
                SQLDBType = "SqlDbType.Char",
                CSharpType = "String",
                SQLServerType = "char",
                MySqlType = "char",
                OracleType = "",
                SQLiteType = ""
            });

            context.DataTypeConfigs.Add(new DataTypeConfig()
            { 
                SQLDBType = "SqlDbType.DateTime",
                CSharpType = "DateTime",
                SQLServerType = "datetime",
                MySqlType = "datetime",
                OracleType = "",
                SQLiteType = ""
            });
             
            context.DataTypeConfigs.Add(new DataTypeConfig()
            { 
                SQLDBType = "SqlDbType.DateTime",
                CSharpType = "DateTime",
                SQLServerType = "datetime2",
                MySqlType = "datetime",
                OracleType = "",
                SQLiteType = ""
            }); 

            context.DataTypeConfigs.Add(new DataTypeConfig()
            { 
                SQLDBType = "SqlDbType.Decimal",
                CSharpType = "Decimal",
                SQLServerType = "decimal",
                MySqlType = "decimal",
                OracleType = "",
                SQLiteType = ""
            });

            context.DataTypeConfigs.Add(new DataTypeConfig()
            { 
                SQLDBType = "SqlDbType.Float",
                CSharpType = "Double",
                SQLServerType = "float",
                MySqlType = "float",
                OracleType = "",
                SQLiteType = ""
            });

            context.DataTypeConfigs.Add(new DataTypeConfig()
            { 
                SQLDBType = "SqlDbType.UniqueIdentifier",
                CSharpType = "Guid",
                SQLServerType = "uniqueidentifier",
                MySqlType = "varchar",
                OracleType = "",
                SQLiteType = ""
            });

            context.DataTypeConfigs.Add(new DataTypeConfig()
            { 
                SQLDBType = "SqlDbType.Int32",
                CSharpType = "Int32",
                SQLServerType = "int",
                MySqlType = "int",
                OracleType = "",
                SQLiteType = ""
            });

            context.DataTypeConfigs.Add(new DataTypeConfig()
            { 
                SQLDBType = "SqlDbType.SmallInt",
                CSharpType = "Int16",
                SQLServerType = "smallint",
                MySqlType = "smallint",
                OracleType = "",
                SQLiteType = ""
            });

            context.DataTypeConfigs.Add(new DataTypeConfig()
            { 
                SQLDBType = "SqlDbType.TinyInt",
                CSharpType = "Byte",
                SQLServerType = "tinyint",
                MySqlType = "tinyint",
                OracleType = "",
                SQLiteType = ""
            });

            context.DataTypeConfigs.Add(new DataTypeConfig()
            { 
                SQLDBType = "SqlDbType.NVarChar",
                CSharpType = "String",
                SQLServerType = "nvarchar",
                MySqlType = "nvarchar",
                OracleType = "",
                SQLiteType = ""
            });


            context.DataTypeConfigs.Add(new DataTypeConfig()
            { 
                SQLDBType = "SqlDbType.VarChar",
                CSharpType = "String",
                SQLServerType = "varchar",
                MySqlType = "varchar",
                OracleType = "",
                SQLiteType = ""
            });

            context.DataTypeConfigs.Add(new DataTypeConfig()
            { 
                SQLDBType = "SqlDbType.Text",
                CSharpType = "String",
                SQLServerType = "text",
                MySqlType = "text",
                OracleType = "",
                SQLiteType = ""
            });

            context.DataTypeConfigs.Add(new DataTypeConfig()
            { 
                SQLDBType = "SqlDbType.NText",
                CSharpType = "String",
                SQLServerType = "ntext",
                MySqlType = "longtext",
                OracleType = "",
                SQLiteType = ""
            });

            context.DataTypeConfigs.Add(new DataTypeConfig()
            { 
                SQLDBType = "SqlDbType.Image",
                CSharpType = "Byte",
                SQLServerType = "image",
                MySqlType = "image",
                OracleType = "",
                SQLiteType = ""
            });


            context.DataTypeConfigs.Add(new DataTypeConfig()
            { 
                SQLDBType = "SqlDbType.Money",
                CSharpType = "Decimal",
                SQLServerType = "money",
                MySqlType = "decimal",
                OracleType = "",
                SQLiteType = ""
            });

            context.DataTypeConfigs.Add(new DataTypeConfig()
            { 
                SQLDBType = "SqlDbType.NChar",
                CSharpType = "String",
                SQLServerType = "nchar",
                MySqlType = "nchar",
                OracleType = "",
                SQLiteType = ""
            });

            context.DataTypeConfigs.Add(new DataTypeConfig()
            { 
                SQLDBType = "SqlDbType.Decimal",
                CSharpType = "Decimal",
                SQLServerType = "numeric",
                MySqlType = "decimal",
                OracleType = "",
                SQLiteType = ""
            });


            context.DataTypeConfigs.Add(new DataTypeConfig()
            { 
                SQLDBType = "SqlDbType.Real",
                CSharpType = "Single",
                SQLServerType = "real",
                MySqlType = "real",
                OracleType = "",
                SQLiteType = ""
            });

            context.DataTypeConfigs.Add(new DataTypeConfig()
            { 
                SQLDBType = "SqlDbType.SmallDateTime",
                CSharpType = "DateTime",
                SQLServerType = "smalldatetime",
                MySqlType = "smalldatetime",
                OracleType = "",
                SQLiteType = ""
            });

            context.DataTypeConfigs.Add(new DataTypeConfig()
            { 
                SQLDBType = "SqlDbType.SmallMoney",
                CSharpType = "Decimal",
                SQLServerType = "smallmoney",
                MySqlType = "decimal",
                OracleType = "",
                SQLiteType = ""
            });

            context.DataTypeConfigs.Add(new DataTypeConfig()
            { 
                SQLDBType = "SqlDbType.Timestamp",
                CSharpType = "Byte",
                SQLServerType = "timestamp",
                MySqlType = "timestamp",
                OracleType = "",
                SQLiteType = ""
            });

            context.DataTypeConfigs.Add(new DataTypeConfig()
            { 
                SQLDBType = "SqlDbType.VarBinary",
                CSharpType = "Byte",
                SQLServerType = "varbinary",
                MySqlType = "varbinary",
                OracleType = "",
                SQLiteType = ""
            });
            context.DataTypeConfigs.Add(new DataTypeConfig()
            { 
                SQLDBType = "SqlDbType.String",
                CSharpType = "String",
                SQLServerType = "xml",
                MySqlType = "xml",
                OracleType = "",
                SQLiteType = ""
            });

            context.DataTypeConfigs.Add(new DataTypeConfig()
            { 
                SQLDBType = "SqlDbType.Variant",
                CSharpType = "Object",
                SQLServerType = "sql_variant",
                MySqlType = "sql_variant",
                OracleType = "",
                SQLiteType = ""
            });


            var columnsproperty = typeof(Column).GetProperties();
            context.Variables.RemoveRange(context.Variables.ToList());
            foreach (var p in columnsproperty)
            {
                var item = new Variable()
                {
                    VariableName = $"@{p.Name}" ,
                    FirstChar = CharStatu.Default,
                    IsSystemGenerator = true,
                    ReplaceProperty = $"@{p.Name}" ,
                    ReplaceString = string.Empty,
                    VariableType = DataSourceType.DatabaseType
                };

                context.Variables.Add(item); 
            } 
            context.ConnectionStrings.RemoveRange(context.ConnectionStrings.ToList());
            context.ConnectionStrings.Add(new ConnectionString() { Type = Core.UsuallyCommon.DataBaseType.SQLServer, WindowsAuthentication = false, Connection = "SERVER={0};UID={1};PWD={2};DATABASE={3}" });

            context.SQLConfigs.RemoveRange(context.SQLConfigs.ToList());
            context.SQLConfigs.Add(new SQLConfig()
            {
                Type = Core.UsuallyCommon.DataBaseType.SQLServer,
                GetDataBaseSQL = "SELECT name AS DataBaseName FROM sys.sysdatabases ORDER BY name",
                GetTableSQL = "USE [@DataBaseName] SELECT name AS TableName FROM sys.tables ORDER BY name",
                GetColumnSQL = @"USE [@DataBaseName]  SELECT a.name as ColumnName,b.name AS Type FROM sys.columns a INNER JOIN sys.types b 
                                 ON a.system_type_id = b.system_type_id  AND a.user_type_id = b.user_type_id WHERE OBJECT_ID = OBJECT_ID('@TableName')"
            });

            context.SQLConfigs.Add(new SQLConfig()
            {
                Type = Core.UsuallyCommon.DataBaseType.MySql,
                GetDataBaseSQL = "SELECT `SCHEMA_NAME`   as DataBaseName FROM `information_schema`.`SCHEMATA`",
                GetTableSQL = @"use information_schema;  
                                select table_name as TableName,
                                table_comment As TableDescription from tables where table_schema = '@DataBaseName'",
                GetColumnSQL = @"
                                

                                use @DataBaseName;
                                SELECT TABLE_NAME 'TableName'
                                ,ORDINAL_POSITION 'ORDINAL_POSITION'
                                ,COLUMN_NAME 'ColumnName'
                                ,COLUMN_DEFAULT 'COLUMN_DEFAULT',
                                CASE WHEN IS_NULLABLE = 'YES' THEN 1 ELSE 0 END AS 'IsRequire'
																,DATA_TYPE 'SQLType'
                                ,CASE WHEN  ISNULL(CHARACTER_MAXIMUM_LENGTH) = 1 THEN 0 ELSE CHARACTER_MAXIMUM_LENGTH END AS 'MaxLength'
                                ,COLUMN_COMMENT 'ColumnDescription'
                                
                                FROM INFORMATION_SCHEMA.COLUMNS  
                                WHERE    TABLE_NAME='@TableName';;
                                 "
            });

            context.DataBaseAddresses.RemoveRange(context.DataBaseAddresses.ToList());
            context.DataBaseAddresses.Add(new Core.UsuallyCommon.DataBase.DataBaseAddress() { Address = "172.18.132.141", ConnectionStrings= "Data Source=172.18.132.141;port=3306;Initial Catalog=MisSystem;uid=root;password=123456;Charset=utf8" ,Password = "123456", User = "root", DefaultDatabase = "MisSystem", DBType = Core.UsuallyCommon.DataBaseType.MySql });

            context.Snippets.RemoveRange(context.Snippets.ToList());

            var databasedemo = new Snippet() { DataSourceType = DataSourceType.DatabaseType, IsFloder = true, Name = "Demo" };
            context.Snippets.Add(databasedemo);
            context.SaveChanges();

            var contexts = @"
            using Chloe.Annotations;  
            using System;  
            using System.Collections.Generic;  using System.ComponentModel.DataAnnotations;  
            namespace Core.Repositories.Models  
            {      
	            /// <summary>
	            /// @TableDescription
	            /// </summary>
	            public class @TableName      
	            {           
		            <%!              
		            StringBuilder sbs = new StringBuilder();
		            foreach (var item in columns)              
		            {                  
			            if(item.IsIdentity || item.IsPrimarykey)                  
			            {                     
				             sbs.AppendLine(""[Column(IsPrimaryKey = true)]"");                      
				             sbs.AppendLine(""[AutoIncrement]"");                   
			            }                      
			            sbs.AppendLine(""///<summary>"");                      
			            sbs.AppendLine($""///{item.ColumnDescription}"");                      
			            sbs.AppendLine(""///</summary>"");                      
			            sbs.AppendLine($""public {item.CSharpType} {((item.IsRequire && item.CSharpType != ""String"") ? ""?"" : """")} {item.ColumnName} {{get;}} {{set;}}"");                  
		            }              
		            return sbs.ToString();          
		            !%>      
	            }  
            }";

            context.Snippets.Add(new Snippet() { DataSourceType = DataSourceType.DatabaseType, OutputPath = @"C:\Generator", IsFloder = false, Name = "ClassDemo",
                GeneratorFileName = "@TableName.cs", IsEnabled = true, ParentId = databasedemo.Id, 
                Context = contexts
            });
            context.SaveChanges();
        }
    }
}
