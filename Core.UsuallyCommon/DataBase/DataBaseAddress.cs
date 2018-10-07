using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.UsuallyCommon.DataBase
{
    public class DataBaseAddress
    {
        public string Address { get; set; }

        public string User { get; set; }
        public string Password { get; set; }

        public DataBaseType DBType { get; set; }

        public List<DataBase> DataBases { get; set; }

        public string GetConnectionString()
        {
            string connectionstring = string.Empty;
            switch (DBType)
            {
                case DataBaseType.SQLServer:
                    break;
                case DataBaseType.MYSQL:
                    break;
                case DataBaseType.Oracle:
                    break;
                case DataBaseType.SQLite:
                    break;
            }
            return connectionstring;
        }

        public string DefaultDatabase = "master";
    }
}
