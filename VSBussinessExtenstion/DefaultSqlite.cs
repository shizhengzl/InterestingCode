﻿namespace VSBussinessExtenstion
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Data.Entity;
    using System.Data.Entity.ModelConfiguration.Conventions;
    using System.Linq;
    using Core.UsuallyCommon;
    using Core.UsuallyCommon.DataBase;
    using MySql.Data.EntityFramework;

    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    public class DefaultSqlite : DbContext
    {
        //您的上下文已配置为从您的应用程序的配置文件(App.config 或 Web.config)
        //使用“DefaultSqlite”连接字符串。默认情况下，此连接字符串针对您的 LocalDb 实例上的
        //“VSBussinessExtenstion.DefaultSqlite”数据库。

        // 
        //如果您想要针对其他数据库和/或数据库提供程序，请在应用程序配置文件中修改“DefaultSqlite”
        //连接字符串。
        public DefaultSqlite()
            : base(DefaultSqltiteConnection)
        {

            this.Configuration.AutoDetectChangesEnabled = false;
        }

        //"Data Source=172.18.132.141;port=3306;Initial Catalog=DefaultSqlite;uid=root;password=123456;Charset=utf8"
        public static string DefaultSqltiteConnection { get { return System.Configuration.ConfigurationManager.ConnectionStrings["DefaultSqlite"].ToStringExtension(); } }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();//移除复数表名的契约  
        }

        //为您要在模型中包含的每种实体类型都添加 DbSet。有关配置和使用 Code First  模型
        //的详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=390109。

        // public virtual DbSet<MyEntity> MyEntities { get; set; }
        public virtual DbSet<SQLConfig> SQLConfigs { get; set; }
        public virtual DbSet<DataTypeConfig> DataTypeConfigs { get; set; }
        public virtual DbSet<DataBaseAddress> DataBaseAddresses { get; set; }
        public virtual DbSet<Variable> Variables { get; set; }

        public virtual DbSet<Snippet> Snippets { get; set; }

        public virtual DbSet<Intellisence> Intellisences { get; set; }

        public virtual DbSet<Control> Controls { get; set; }


        public virtual DbSet<CodeAppend> CodeAppends { get; set; }
    }



    public class Intellisence
    {
        [Key]
        public int Id { get; set; } 
        public string StartChar { get; set; } 
        public string DisplayText { get; set; }
        public string InsertionText { get; set; }
        public string Description { get; set; } 
        public string DefinedSql { get; set; } 
        public string ConnectionString { get; set; }
    }

    public class Snippet
    {
        [Key]
        public Int32 Id { get; set; }

        public string Name { get; set; }

        public Int32 ParentId { get; set; }

        public DataSourceType DataSourceType { get; set; } 
        public string Context { get; set; } 
        public string OutputPath { get; set; } 
        public string GeneratorFileName { get; set; } 
        public bool IsFloder { get; set; } 
        public bool IsEnabled { get; set; } 
        public bool IsMergin { get; set; } 
        public bool IsAutoFind { get; set; } 
        public bool IsSelectGenerator { get; set; }  
        public bool IsMultipleTable { get; set; } 
        public bool IsAppendSnippet { get; set; } 
    } 

    public class CodeAppend
    { 
        [Key]
        public Int32 Id { get; set; } 
        public bool IsAppend { get; set; }  
        public bool IsMethod { get; set; } 
        public bool IsProperty { get; set; }
        public bool IsAnyCode { get; set; } 
        public string AppendUrl { get; set; } 
        public string AppendCode { get; set; } 

        public Int32 ParentSnippetId { get; set; }
        public string ListSnippets { get; set; } 
    }



    public class SQLConfig
    {
        [Key]
        public Int32 Id { get; set; }
        public DataBaseType Type { get; set; }

        public string GetDataBaseSQL { get; set; }

        public string GetTableSQL { get; set; }

        public string GetColumnSQL { get; set; }

        public string GetProducuteSQL { get; set; }

        public string GetViewSQL { get; set; }

        public string GetIndexSQL { get; set; }

        public string GetSYNONYMSQL { get; set; }

        public string GetWhereSQL { get; set; }
    }

    public class DataTypeConfig
    {
        [Key]
        public Int32 Id { get; set; }

        public string SQLServerType { get; set; }
        public string MySqlType { get; set; }
        public string OracleType { get; set; }
        public string SQLiteType { get; set; }

        public string CSharpType { get; set; }

        public string SQLDBType { get; set; }
    }

    public class Variable
    {
        [Key]
        public Int32 Id { get; set; }
        public string VariableName { get; set; }

        public string ReplaceProperty { get; set; }

        public string ReplaceString { get; set; }

        public CharStatu FirstChar { get; set; }

        public bool IsSystemGenerator { get; set; }

        public DataSourceType VariableType { get; set; }
    }

    public enum DataSourceType
    {
        DatabaseType = 0,
        CSharpType = 1,
        XMLType = 2,
        StringType = 3
    }

    public enum CharStatu
    {
        ToUpper = 2,
        ToLower = 1,
        Default = 0
    }


}