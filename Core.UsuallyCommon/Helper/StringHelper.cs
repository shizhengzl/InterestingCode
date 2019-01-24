using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.UsuallyCommon
{
    public class StringHelper
    {
        public static Boolean SearchWordExists(string param, string[] items)
        {
            return Search(param, items).Length > 0;
        }

        public static string[] Search(string param, string[] datas)
        {
            if (string.IsNullOrWhiteSpace(param))
                return new string[0];

            string[] words = param.Split(new char[] { ' ', '　' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (string word in words)
            {
                int maxDist = (word.Length - 1) / 2;

                var q = from str in datas
                        where word.Length <= str.Length
                            && Enumerable.Range(0, maxDist + 1)
                            .Any(dist =>
                            {
                                return Enumerable.Range(0, Math.Max(str.Length - word.Length - dist + 1, 0))
                                    .Any(f =>
                                    {
                                        return Distance(word, str.Substring(f, word.Length + dist)) <= maxDist;
                                    });
                            })
                        orderby str
                        select str;
                datas = q.ToArray();
            }

            return datas;
        }

        static int Distance(string str1, string str2)
        {
            int n = str1.Length;
            int m = str2.Length;
            int[,] C = new int[n + 1, m + 1];
            int i, j, x, y, z;
            for (i = 0; i <= n; i++)
                C[i, 0] = i;
            for (i = 1; i <= m; i++)
                C[0, i] = i;
            for (i = 0; i < n; i++)
                for (j = 0; j < m; j++)
                {
                    x = C[i, j + 1] + 1;
                    y = C[i + 1, j] + 1;
                    if (str1[i] == str2[j])
                        z = C[i, j];
                    else
                        z = C[i, j] + 1;
                    C[i + 1, j + 1] = Math.Min(Math.Min(x, y), z);
                }
            return C[n, m];
        }
    
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


        public static Boolean SearchExists(string param, string[] items)
        {
            if (string.IsNullOrWhiteSpace(param) || items == null || items.Length == 0)
                return false;

            string[] words = param
                                .Split(new char[] { ' ', '\u3000' }, StringSplitOptions.RemoveEmptyEntries)
                                .OrderBy(s => s.Length)
                                .ToArray();

            var q = from sentence in items.AsParallel()
                    let MLL = Mul_LnCS_Length(sentence, words)
                    where MLL >= 0
                    orderby (MLL + 0.5) / sentence.Length, sentence
                    select sentence;

            var list =  q.ToArray().ToList<string>();

            return list.Count > 0;
        }
        public static string[] Search(string param, string[] items,double Center = 0.50)
        {
            if (string.IsNullOrWhiteSpace(param) || items == null || items.Length == 0)
                return new string[0];

            string[] words = param
                                .Split(new char[] { ' ', '\u3000' }, StringSplitOptions.RemoveEmptyEntries)
                                .OrderBy(s => s.Length)
                                .ToArray();

            var q = from sentence in items.AsParallel()
                    let MLL = Mul_LnCS_Length(sentence, words)
                    where MLL >= 0
                    orderby (MLL + Center) / sentence.Length, sentence
                    select sentence;

            return q.ToArray();
        }

        //static int[,] C = new int[100, 100];

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sentence"></param>
        /// <param name="words">多个关键字。长度必须大于0，必须按照字符串长度升序排列。</param>
        /// <returns></returns>
        public static int Mul_LnCS_Length(string sentence, string[] words)
        {
            int sLength = sentence.Length;
            int result = sLength;
            bool[] flags = new bool[sLength];
            int[,] C = new int[sLength + 1, words[words.Length - 1].Length + 1];
            //int[,] C = new int[sLength + 1, words.Select(s => s.Length).Max() + 1];
            foreach (string word in words)
            {
                int wLength = word.Length;
                int first = 0, last = 0;
                int i = 0, j = 0, LCS_L;
                //foreach 速度会有所提升，还可以加剪枝
                for (i = 0; i < sLength; i++)
                    for (j = 0; j < wLength; j++)
                        if (sentence[i] == word[j])
                        {
                            C[i + 1, j + 1] = C[i, j] + 1;
                            if (first < C[i, j])
                            {
                                last = i;
                                first = C[i, j];
                            }
                        }
                        else
                            C[i + 1, j + 1] = Math.Max(C[i, j + 1], C[i + 1, j]);

                LCS_L = C[i, j];
                if (LCS_L <= wLength >> 1)
                    return -1;

                while (i > 0 && j > 0)
                {
                    if (C[i - 1, j - 1] + 1 == C[i, j])
                    {
                        i--;
                        j--;
                        if (!flags[i])
                        {
                            flags[i] = true;
                            result--;
                        }
                        first = i;
                    }
                    else if (C[i - 1, j] == C[i, j])
                        i--;
                    else// if (C[i, j - 1] == C[i, j])
                        j--;
                }

                if (LCS_L <= (last - first + 1) >> 1)
                    return -1;
            }

            return result;
        }
    }
}
