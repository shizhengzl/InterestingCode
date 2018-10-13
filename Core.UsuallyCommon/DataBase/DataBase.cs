using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.UsuallyCommon.DataBase
{
    [NotMapped]
    public class DataBase : DataBaseAddress
    { 
        public string DataBaseName { get; set; } 
        public string DataBaseDescription { get; set; }

        public List<Table> Tables { get; set; }
    }
}
