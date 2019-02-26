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

            var input =@"        public static ";




            int p = 34;
            var sbs = StringHelper.GetStringSingleColumn(input);
            List<KeyValuePair<int, string>> col = new List<KeyValuePair<int, string>>();
            List<int> points = new List<int>();
            int indexs = 0;
            foreach (var bs in sbs)
            {
                var sk = input.IndexOf(bs, indexs);
                if(p - sk < 0)
                    break;
                
                col.Add(new KeyValuePair<int, string>(sk,bs));
                indexs = sk + bs.Length;
                points.Add(sk);
            }
             
            var result = col[points.Count-1].Value;
            

            return;
            var strs = @"
<page funcid = '01010110' >
 
   <controls >
 
     <control id = 'appFormMenu' >
  
        <menus >
  
          <menu title = '文件' >
   
             <menuitem title = '关闭' action = 'window.close()' />
      
              </menu >
      

            </menus >
      
     

</control >

<control id = 'appForm' >

<datasource entity = 's_AreaBcDetail' keyname = 'AreaBcDetailGUID' >

<sql > SELECT AreaBcDetailGUID, AreaBcFaSetGUID, CalcCondition, LeftData, RightData, LeftSymbol, RightSymbol, IsBc, BcgsData, Remark FROM s_AreaBcDetail WHERE(1 = 1) </sql >

</datasource >

<form showtab = 'false' >

<tab title = '补差方案明细' >

<section title = '计算条件' showtitle = 'true' showbar = 'true' cols = '2' titlewidth = '70' secid = 'Section1' >

<item type = 'hidden' name = 'oid' field = 'AreaBcDetailGUID' title = '补差明细GUID' />

<item type = 'hidden' name = 'areabcfasetguid' field = 'areabcfasetguid' title = '补差方案GUID' />

<item type = 'hidden' name = 'calccondition' field = 'CalcCondition' title = '计算条件' />

 
            
            <item type = 'radio' field='IsBc' title='是否补差' defaultvalue='1' colspan='2'>
              <option value = '1' > 补差 </option >
              <option value='0'>不补差</option>
            </item>
          </section>
          <section title = '' showtitle='true' showbar='true' titlewidth='210' cols='1' secid='Section2'>
            <item type = 'number' field='BcgsData' title='计算公式　 （面积差 * 合同单价） *'>
              <attribute min = '0' max='100' grp='false' acc='2' dt='' />
            </item>
          </section>
          <section title = '' showtitle='true' showbar='true' titlewidth='70' cols='2' secid='Section3'>
            <item type = 'text' field='Remark' title='备注' colspan='2'>
              <attribute maxlength = '100' />
            </item >
          </section >
        </tab >
      </form >
    </control >
  </controls >
</page > 

 "; 

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
