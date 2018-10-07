using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.UsuallyCommon.DataBase
{
    public class Table : DataBase
    { 
        public string TableName { get; set; }
        public string TableDescription { get; set; }
        public string TableType { get; set; }
        public List<Column> Columns { get; set; }
    }
}
