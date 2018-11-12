using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.UsuallyCommon.DataBase;
using Core.UsuallyCommon;

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
                ChangeDataBase(baseAddress);
                string getDatabaseSql = dbContext.SQLConfigs.FirstOrDefault(x => x.Type == baseAddress.DBType).GetDataBaseSQL;
                baseAddress.DataBases = DatabaseHelper.ExecuteQuery(getDatabaseSql).Tables[0].ToList<DataBase>().Where(x =>
                string.IsNullOrEmpty(baseAddress.DefaultDatabase) || x.DataBaseName == baseAddress.DefaultDatabase).ToList<DataBase>();
                baseAddress.DataBases.ForEach(x => x.Address = baseAddress.Address);
                baseAddress.DataBases.ForEach(x => x.User = baseAddress.User);
                baseAddress.DataBases.ForEach(x => x.Password = baseAddress.Password);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public void InitTable(DataBase dataBase,List<string> list= null, SearchType searchType = 0,double center = 0.5)
        {
            ChangeDataBase(dataBase);
            string getDataTableSql = dbContext.SQLConfigs.FirstOrDefault(x => x.Type == dataBase.DBType).GetTableSQL.Replace("@DataBaseName", dataBase.DataBaseName);
            dataBase.Tables = DatabaseHelper.ExecuteQuery(getDataTableSql).Tables[0].ToList<Table>();
            dataBase.Tables.ForEach(x => x.Address = dataBase.Address);
            dataBase.Tables.ForEach(x => x.DataBaseName = dataBase.DataBaseName);
            dataBase.Tables.ForEach(x => x.User = dataBase.User);
            dataBase.Tables.ForEach(x => x.Password = dataBase.Password);

            if(list != null)
            { 
                switch (searchType)
                {
                    case SearchType.Complete:
                        dataBase.Tables = dataBase.Tables.Where(x => list.Any(y=>y.ToUpper() == x.TableName.ToUpper())).ToList<Table>();
                        break;
                    case SearchType.LikeSearch:
                        dataBase.Tables = dataBase.Tables.Where(x =>x.TableName.ToUpper().IndexOf(list.First().ToUpper()) > -1).ToList<Table>();
                        break;
                    case SearchType.FuzzySearch:
                        dataBase.Tables = dataBase.Tables.Where(x =>Core.UsuallyCommon.StringHelper.SearchExists(x.TableName,list.ToArray(), center)).ToList<Table>();
                        break;
                }
            }
        }

        public void InitColumn(Table table)
        {
            ChangeDataBase(table);
            string getColumnSql = dbContext.SQLConfigs.FirstOrDefault(x => x.Type == table.DBType).GetColumnSQL.Replace("@DataBaseName", table.DataBaseName).Replace("@TableName", table.TableName);
            table.Columns = DatabaseHelper.ExecuteQuery(getColumnSql).Tables[0].ToList<Column>();

            table.Columns.ForEach(x => x.Address = table.Address);
            table.Columns.ForEach(x => x.DataBaseName = table.DataBaseName);
            table.Columns.ForEach(x => x.TableName = table.TableName);
            table.Columns.ForEach(x => x.ColumnType = GetColumnType(x.DBType, x.Type));
        }

        public string GetColumnType(DataBaseType dataBaseType, string Type)
        {
            string columnType = string.Empty;
            switch (dataBaseType)
            {
                case DataBaseType.SQLServer:
                    columnType = dbContext.DataTypeConfigs.FirstOrDefault(y => y.Type == dataBaseType && y.SQLServerType == Type).CSharpType;
                    break;
                case DataBaseType.SQLite:
                    columnType = dbContext.DataTypeConfigs.FirstOrDefault(y => y.Type == dataBaseType && y.SQLiteType == Type).CSharpType;
                    break;
                case DataBaseType.MYSQL:
                    columnType = dbContext.DataTypeConfigs.FirstOrDefault(y => y.Type == dataBaseType && y.MySqlType == Type).CSharpType;
                    break;
                case DataBaseType.Oracle:
                    columnType = dbContext.DataTypeConfigs.FirstOrDefault(y => y.Type == dataBaseType && y.OracleType == Type).CSharpType;
                    break;
            }
            return columnType;
        }

        public void ChangeDataBase(DataBaseAddress baseAddress)
        {
            var con = dbContext.ConnectionStrings.FirstOrDefault(x => x.Type == baseAddress.DBType);
            if(!String.IsNullOrEmpty(baseAddress.User) && !String.IsNullOrEmpty(baseAddress.Password))
                DatabaseHelper.connectionString = string.Format(con.Connection, baseAddress.Address, baseAddress.User, baseAddress.Password, baseAddress.DefaultDatabase); //baseAddress.GetConnectionString();
        }
    }
}
