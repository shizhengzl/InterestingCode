using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomIntelliSenseExtension
{
    public class Intellisence
    {
        public int Id { get; set; }

        public  string DisplayText { get; set; }
         public  string InsertionText { get; set; }
          public  string Description { get; set; }

          public  string DefinedSql { get; set; }
    }
}
