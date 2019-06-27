using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        public int? MaxLength { get; set; }
        public bool IsRequire { get; set; } 
        public byte Scale { get; set; }
        public string DefaultValue { get; set; }

        public string SQLType { get; set; }

      

        public Control SearchControl { get; set; }

        public Control GridControl { get; set; }

        public Control CreateControl { get; set; }

        public Control ModifyControl { get; set; }

              public string GetValue(string name)
        {
            return this.GetType().GetProperty(name).GetValue(this, null).ToStringExtension();
        }
    }
    public class Control
    {
        [Key]
        public int Id { get; set; }

        public string ControlName { get; set; }

        public string ControlText { get; set; }
        public string CsharpType { get; set; }

        public ControlMode ControlMode { get; set; }

        public bool IsDefault { get; set; }

        public bool NeedDataSource { get; set; }

        public string AppendCodeUrl { get; set; }

        public string AppendCode { get; set; }

        public ControlDataSource ControlDataSources { get; set; }
    }
    public enum ControlMode
    {
        Search = 0,
        Grid = 1,
        Create = 2,
        Modify = 3
    }
    public class ControlDataSource
    {

        public int Id { get; set; }

        public String DataSourceUrl { get; set; }

        public String DataSourceName { get; set; }

        public String DataSourceInit { get; set; }

        public String DataSourceKey { get; set; }
         
        public String DataSourceVlaue { get; set; }
        public String DataSourceParentId { get; set; }
    }
}
