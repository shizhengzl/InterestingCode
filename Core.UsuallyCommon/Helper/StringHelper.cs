using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.UsuallyCommon
{
    public class StringHelper
    { 
        public static List<String> GetStringSingleColumn(string context)
        { 
            string[] separatingChars = new string[] { "\r\n", "\n", "\r", "\t" };
            string[] linedatas = context.Split(separatingChars, System.StringSplitOptions.RemoveEmptyEntries); 
            return linedatas.ToList<string>(); 
        }
    }
}
