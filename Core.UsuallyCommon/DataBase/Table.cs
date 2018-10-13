using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.UsuallyCommon.DataBase
{
    [NotMapped]
    public class Table : DataBase
    { 
        public string TableName { get; set; }
        public string TableDescription { get; set; }
        public string TableType { get; set; }
        public List<Column> Columns { get; set; }
    }
}
