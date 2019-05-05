using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.UsuallyCommon.DataBase
{
    [NotMapped]
    public class Column : Table
    {  

        public bool IsSelect { get; set; }
        public string SearchControls { get; set; }
        public string GridControls { get; set; }
        public string CreateControls { get; set; }
        public string ModifyControls { get; set; }
        public string ColumnName { get; set; }
        public string ColumnDescription { get; set; }
        public string CSharpType { get; set; }
        public bool IsIdentity { get; set; }
        public bool IsPrimarykey { get; set;}
        public Int32? MaxLength { get; set; }
        public bool IsRequire { get; set; } 
        public byte Scale { get; set; }
        public string DefaultValue { get; set; }

        public string SQLType { get; set; }


        public string GetValue(string name)
        {
            return this.GetType().GetProperty(name).GetValue(this, null).ToStringExtension();
        }
    }
}
