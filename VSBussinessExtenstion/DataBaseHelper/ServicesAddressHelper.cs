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
            }
            catch (Exception ex)
            {
                throw ex;
            }
          
        }

        public void InitTable(DataBase dataBase)
        {
            ChangeDataBase(dataBase);
            string getDataTableSql = dbContext.SQLConfigs.FirstOrDefault(x => x.Type == dataBase.DBType).GetTableSQL.Replace("@DataBaseName",dataBase.DataBaseName) ;
            dataBase.Tables = DatabaseHelper.ExecuteQuery(getDataTableSql).Tables[0].ToList<Table>();
            dataBase.Tables.ForEach(x => x.Address = dataBase.Address);
            dataBase.Tables.ForEach(x => x.DataBaseName = dataBase.DataBaseName);
        }

        public void InitColumn(Table table)
        {
            ChangeDataBase(table);
            string getColumnSql = dbContext.SQLConfigs.FirstOrDefault(x => x.Type == table.DBType).GetColumnSQL;
            table.Columns = DatabaseHelper.ExecuteQuery(getColumnSql).Tables[0].ToList<Column>();
        }

        public void ChangeDataBase(DataBaseAddress baseAddress)
        {
            var con = dbContext.ConnectionStrings.FirstOrDefault(x=>x.Type == baseAddress.DBType);
            DatabaseHelper.connectionString = string.Format(con.Connection, baseAddress.Address, baseAddress.User, baseAddress.Password, baseAddress.DefaultDatabase); //baseAddress.GetConnectionString();
        }
    }
}
