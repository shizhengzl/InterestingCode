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

        public static List<string> GetStringListByStartAndEndInner(string str, string start, string end)
        {
            List<string> list = new List<string>();

            List<int> starts = GetPostion(str, start).OrderByDescending(x => x).ToList<int>();
            List<int> ends = GetPostion(str, end).OrderBy(x => x).ToList<int>();
            for (int i = 0; i < starts.Count; i++)
            { 
                list.Add(str.Substring(starts[i], ends.FirstOrDefault(x=>x > starts[i]) - starts[i] + start.Length));
            } 

            return list; 
        }

        public static List<int> GetPostion(string str,string chars)
        {
            List<int> result = new List<int>();

            int cacl = 0; 
            int length = (str.Length - str.Replace(chars, string.Empty).Length) / chars.Length;
            for (int i = 0; i < length; i++)
            {
                int index = str.IndexOf(chars, cacl);
                if (index > -1)
                {
                    result.Add(index);
                    cacl = index + 1;
                }
            } 
            return result;
        } 

    }
}
