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

        public static List<string> GetStringListByStartAndEnd(string str, string start, string end)
        {
            List<string> list = new List<string>(); 
            int length = str.Length;
            int startNumber = (length - str.Replace(start, string.Empty).Length) / start.Length;

            int cacleIndex = 0;

            for (int i = 0; i < startNumber; i++)
            {
                StringBuilder sb = new StringBuilder();
                int startIndex = str.IndexOf(start, cacleIndex);
                if (startIndex < 0)
                    continue;
                int lastIndex = str.IndexOf(end, cacleIndex);
                list.Add(str.Substring(startIndex, lastIndex - startIndex + start.Length));

                cacleIndex = lastIndex + 1;
            } 
            return list;
        }
    }
}
