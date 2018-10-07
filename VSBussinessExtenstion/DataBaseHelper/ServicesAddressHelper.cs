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
        public List<DataBaseAddress> listServices = new List<DataBaseAddress>();
        public ServicesAddressHelper()
        {

        }

        public void Init(DataBaseAddress address)
        {
            if (!listServices.Any(x => x.Address == address.Address))
            {
                listServices.Add(address);
                InitDatabase(address);
            }
        }

        public void InitDatabase(DataBaseAddress baseAddress)
        {
            ChangeDataBase(baseAddress);
            string getDatabaseSql = dbContext.SQLConfigs.FirstOrDefault(x => x.Type == baseAddress.DBType).GetDataBaseSQL;
            baseAddress.DataBases =DatabaseHelper.ExecuteQuery(getDatabaseSql).Tables[0].ToList<DataBase>();
        }

        public void InitTable(DataBase dataBase)
        {
            ChangeDataBase(dataBase);
            string getDataTableSql = dbContext.SQLConfigs.FirstOrDefault(x => x.Type == dataBase.DBType).GetTableSQL;
            dataBase.Tables = DatabaseHelper.ExecuteQuery(getDataTableSql).Tables[0].ToList<Table>();
        }

        public void InitColumn(Table table)
        {
            ChangeDataBase(table);
            string getColumnSql = dbContext.SQLConfigs.FirstOrDefault(x => x.Type == table.DBType).GetColumnSQL;
            table.Columns = DatabaseHelper.ExecuteQuery(getColumnSql).Tables[0].ToList<Column>();
        }

        public void ChangeDataBase(DataBaseAddress baseAddress)
        {
            DatabaseHelper.connectionString = baseAddress.GetConnectionString();
        }
    }
}
