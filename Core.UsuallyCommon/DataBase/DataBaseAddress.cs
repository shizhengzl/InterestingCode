using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.UsuallyCommon.DataBase
{
    public class DataBaseAddress
    {
        [Key]
        public Int32 Id { get; set; }
        public string Address { get; set; }

        public string User { get; set; }
        public string Password { get; set; }

        public DataBaseType DBType { get; set; }

        public List<DataBase> DataBases { get; set; }


        public string ConnectionStrings { get; set; }

       

        public string DefaultDatabase { get; set; } = "master";
    }
}
