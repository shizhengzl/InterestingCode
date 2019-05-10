using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.UsuallyCommon.DataBase;
using Core.UsuallyCommon;
using MySql.Data.EntityFramework;

using System.Linq;
namespace VSBussinessExtenstion.DataBaseHelper
{

     
    public class ServicesAddressHelper
    {
        public DefaultSqlite dbContext = new DefaultSqlite();

        public void Init(DataBaseAddress address)
        {
            InitDatabase(address);
        }

        public void InitDatabase(DataBaseAddress baseAddress)
        {
            try
            { 
                string getDatabaseSql = dbContext.SQLConfigs.FirstOrDefault(x => x.Type == baseAddress.DBType).GetDataBaseSQL.Replace("@DataBaseName",baseAddress.DefaultDatabase);

                ChangeDataBase(baseAddress);
                baseAddress.DataBases = dbContext.Database.SqlQuery<DataBase>(getDatabaseSql).ToList<DataBase>().Where(x =>
                string.IsNullOrEmpty(baseAddress.DefaultDatabase) || x.DataBaseName.ToUpper() == baseAddress.DefaultDatabase.ToUpper()).ToList<DataBase>();
                baseAddress.DataBases.ForEach(x => x.Address = baseAddress.Address);
                baseAddress.DataBases.ForEach(x => x.User = baseAddress.User);
                baseAddress.DataBases.ForEach(x => x.Password = baseAddress.Password);
                baseAddress.DataBases.ForEach(x => x.ConnectionStrings = baseAddress.ConnectionStrings);
                baseAddress.DataBases.ForEach(x => x.DBType = baseAddress.DBType);
                BackConnection();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public void InitTable(DataBase dataBase,List<string> list= null, SearchType searchType = 0)
        {
        
            string getDataTableSql = dbContext.SQLConfigs.FirstOrDefault(x => x.Type == dataBase.DBType).GetTableSQL.Replace("@DataBaseName", dataBase.DataBaseName);
            ChangeDataBase(dataBase);
            dataBase.Tables = dbContext.Database.SqlQuery<Table>(getDataTableSql).ToList<Table>();
            dataBase.Tables.ForEach(x => x.Address = dataBase.Address);
            dataBase.Tables.ForEach(x => x.DataBaseName = dataBase.DataBaseName);
            dataBase.Tables.ForEach(x => x.User = dataBase.User);
            dataBase.Tables.ForEach(x => x.Password = dataBase.Password);

            dataBase.Tables.ForEach(x => x.ConnectionStrings = dataBase.ConnectionStrings);
            dataBase.Tables.ForEach(x => x.DBType = dataBase.DBType);

            if (list != null)
            {
                switch (searchType)
                {
                    case SearchType.Complete:
                        dataBase.Tables = dataBase.Tables
                            .Where(x => list.Any(y => y.ToUpper() == x.TableName.ToUpper())).ToList<Table>();
                        break;
                    case SearchType.LikeSearch:
                        dataBase.Tables = dataBase.Tables
                            .Where(x => x.TableName.ToUpper().IndexOf(list.First().ToUpper()) > -1).ToList<Table>();
                        break;
                    case SearchType.FuzzySearch:
                        dataBase.Tables = dataBase.Tables.Where(x =>
                            Core.UsuallyCommon.StringHelper.SearchWordExists(list.First().ToString()
                                , new string[] {x.TableName})).ToList<Table>();
                        break;
                }
            }

            BackConnection();
        }

        public void InitColumn(Table table)
        {
            string getColumnSql = dbContext.SQLConfigs.FirstOrDefault(x => x.Type == table.DBType).GetColumnSQL.Replace("@DataBaseName", table.DataBaseName).Replace("@TableName", table.TableName);
            ChangeDataBase(table);
            table.Columns = dbContext.Database.SqlQuery<Column>(getColumnSql).ToList<Column>();

            table.Columns.ForEach(x => { x.Address = table.Address;
                x.DataBaseName = table.DataBaseName;
                x.User = table.User;
                x.Password = table.Password;
                x.DBType = table.DBType;
                x.TableName = table.TableName;
                x.Key = table.Key;
                x.TableDescription = table.TableDescription;
                x.IsSelect = true;
                x.ConnectionStrings = table.ConnectionStrings;
            });     
            BackConnection();
            table.Columns.ForEach(x => x.CSharpType = GetColumnType(x.DBType, x.SQLType));
        }

        public string GetColumnType(DataBaseType dataBaseType, string Type)
        {
            string columnType = string.Empty; ;
            switch (dataBaseType)
            {
                case DataBaseType.SQLServer:
                    columnType = dbContext.DataTypeConfigs.FirstOrDefault(y => y.SQLServerType == Type).CSharpType;
                    break;
                case DataBaseType.SQLite:
                    columnType = dbContext.DataTypeConfigs.FirstOrDefault(y => y.SQLiteType == Type).CSharpType;
                    break;
                case DataBaseType.MySql:
                    columnType = dbContext.DataTypeConfigs.FirstOrDefault(y => y.MySqlType == Type).CSharpType;
                    break;
                case DataBaseType.Oracle:
                    columnType = dbContext.DataTypeConfigs.FirstOrDefault(y => y.OracleType == Type).CSharpType;
                    break;
            }
            return columnType;
        }

        public void ChangeDataBase(DataBaseAddress baseAddress)
        { 
            //var con = dbContext.ConnectionStrings.FirstOrDefault(x => x.Type == baseAddress.DBType);

            
                dbContext.Database.Connection.ConnectionString = baseAddress.ConnectionStrings;
            
            //if(!String.IsNullOrEmpty(baseAddress.User) && !String.IsNullOrEmpty(baseAddress.Password))
            //    DatabaseHelper.connectionString = string.Format(con.Connection, baseAddress.Address, baseAddress.User, baseAddress.Password, baseAddress.DefaultDatabase); //baseAddress.GetConnectionString();
        }

        public void BackConnection()
        {
            dbContext.Database.Connection.ConnectionString = DefaultSqlite.DefaultSqltiteConnection;
        }
    }
}
