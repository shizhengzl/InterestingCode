using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.UsuallyCommon.DataBase
{
    public class DataBase : DataBaseAddress
    { 
        public string DataBaseName { get; set; } 
        public string DataBaseDescription { get; set; }

        public List<Table> Tables { get; set; }
    }
}
