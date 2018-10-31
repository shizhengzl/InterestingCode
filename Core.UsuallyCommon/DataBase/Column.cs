﻿using System;
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
        public string ColumnName { get; set; }
        public string ColumnDescription { get; set; }
        public string ColumnType { get; set; }
        public bool IsIdentity { get; set; }
        public bool IsParmarykey { get; set;}
        public Int32 MaxLength { get; set; }
        public bool IsRequire { get; set; } 
        public byte Scale { get; set; }
        public string DefaultValue { get; set; }

        public string Type { get; set; }


        public string GetValue(string name)
        {
            return this.GetType().GetProperty(name).GetValue(this, null).ToStringExtension();
        }
    }
}
