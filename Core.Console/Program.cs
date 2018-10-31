using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.UsuallyCommon;
namespace Core.ConsoleLog
{
    class Program
    {
        static void Main(string[] args)
        {
            var res = StringHelper.GetStringListByStartAndEnd("public class abcd { <%!public @ColumnName{get;set;!%>} <%!@ColumnName!%>", "<%!", "!%>");

            res.ForEach(x => Console.WriteLine(x));

            Console.ReadLine();
        }
    }
}
