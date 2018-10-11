﻿namespace VSBussinessExtenstion
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Data.Entity;
    using System.Linq;
    using Core.UsuallyCommon;
    using Core.UsuallyCommon.DataBase;

    public class DefaultSqlite : DbContext
    {
        //您的上下文已配置为从您的应用程序的配置文件(App.config 或 Web.config)
        //使用“DefaultSqlite”连接字符串。默认情况下，此连接字符串针对您的 LocalDb 实例上的
        //“VSBussinessExtenstion.DefaultSqlite”数据库。
        // 
        //如果您想要针对其他数据库和/或数据库提供程序，请在应用程序配置文件中修改“DefaultSqlite”
        //连接字符串。
        public DefaultSqlite()
            : base("name=DefaultSqlite")
        {

        }

        //为您要在模型中包含的每种实体类型都添加 DbSet。有关配置和使用 Code First  模型
        //的详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=390109。

        // public virtual DbSet<MyEntity> MyEntities { get; set; }
        public virtual DbSet<SQLConfig> SQLConfigs { get; set; }
        public virtual DbSet<DataTypeConfig> DataTypeConfigs { get; set; }
        public virtual DbSet<DataBaseAddress> DataBaseAddresss { get; set; }
        public virtual DbSet<Variable> Variables { get; set; }
        public virtual DbSet<ConnectionString> ConnectionStrings { get; set; }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}

    public class ConnectionString
    {
        [Key]
        public Int32 Id { get; set; }

        public DataBaseType Type { get; set; }

        public string Connection { get; set; }
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
        public DataBaseType Type { get; set; }

        public string DBType { get; set; }

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
        DatabaseType = 1,
        CSharpType = 2,
        StringType = 3,
        SQLType = 4
    }

    public enum CharStatu
    {
        ToUpper = 2,
        ToLower = 1,
        Default = 0
    }
}