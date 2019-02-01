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
            var strs = "post^";
            var result = Core.UsuallyCommon.StringHelper.GetStringSingleColumn(strs);
            foreach (var rs in result)
            {
                Console.WriteLine(rs);
            }

            Console.ReadLine();

            //var s = Core.UsuallyCommon.StringHelper.Search("just", new List<string>() { "cb_Adjust" }.ToArray());

            return;
            string str = @" <%! var option = {
                //rviceInfo格式为:命名空间.类名.方法名
				//Slxt.Services为namespace下面的 Slxt.Services
                serviceInfo:  '@NameSpace.@ClassName.@MethodName',
                //Javascript对象，键值对形式，直接匹配服务端函数参数。
                data: {<%! @MethodArgumentName : @MethodArgumentName !%> }
                }
                //发起GET请求
                var vals = MapExt.postJSON(option);
                if(vals.result){
                    alert('删除成功');
                    appGrid.frameElement.Query();
                }else{
                    alert('删除失败');
                } 
			!%>";
            var list = Core.UsuallyCommon.StringHelper.GetStringListByStartAndEndInner(str,"<%!","!%>");

            var res = StringHelper.GetStringListByStartAndEnd("public class abcd { <%!public @ColumnName{get;set;!%>} <%!@ColumnName!%>", "<%!", "!%>");

            res.ForEach(x => Console.WriteLine(x));

            Console.ReadLine();
        }
    }
}
