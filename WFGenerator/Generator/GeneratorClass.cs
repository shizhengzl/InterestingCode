using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VSBussinessExtenstion;
using Core.UsuallyCommon;
using System.ComponentModel;
using Core.UsuallyCommon.DataBase;

namespace WFGenerator
{
    public class GeneratorClass
    {
        public string GetGenerator(Snippet snippet, object datasource)
        {
            if (snippet.IsFloder)
                return string.Empty;

            var context = snippet.Context;

            var listReplace = StringHelper.GetStringListByStartAndEnd(context, SnippetReplace.Start.GetDescription(), SnippetReplace.End.GetDescription());


            foreach (var item in listReplace)
            {
                if (snippet.DataSourceType == DataSourceType.DatabaseType)
                {
                    var columns = datasource as List<Column>;
                    if (columns.Count == 0)
                        continue;
                    StringBuilder sb = new StringBuilder();
                    var inittempcontext = item.Replace(SnippetReplace.Start.GetDescription(), string.Empty).Replace(SnippetReplace.End.GetDescription(), string.Empty);

                    foreach (var column in columns)
                        sb.Append(this.ReplaceDataBase<Column>(inittempcontext, column));
                    context = context.Replace(item, sb.ToStringExtension());

                    context = this.ReplaceDataBase(context, columns.FirstOrDefault(), true);
                }
                if (snippet.DataSourceType == DataSourceType.CSharpType)
                {

                    var classs = datasource as Classs;
                    StringBuilder sb = new StringBuilder();
                    var inittempcontext = item.Replace(SnippetReplace.Start.GetDescription(), string.Empty).Replace(SnippetReplace.End.GetDescription(), string.Empty);
                    
                    //sb.Append(this.ReplaceDataBase<Classs>(inittempcontext, classs));

                    foreach (var property in classs.Protertys)
                    {
                        sb.Append(this.ReplaceDataBase<Core.UsuallyCommon.Proterty>(inittempcontext, property));
                    }

                    foreach (var method in classs.Methods)
                    {
                        //inittempcontext = this.ReplaceDataBase<Core.UsuallyCommon.Method>(inittempcontext, method, true);
                        //sb.Append(this.ReplaceDataBase<Core.UsuallyCommon.Method>(inittempcontext, method,true));
                        foreach (var methodArgument in method.MethodArguments)
                        {
                            sb.Append(this.ReplaceDataBase<Core.UsuallyCommon.MethodArgument>(inittempcontext, methodArgument));
                        }
                    }

                    context = context.Replace(item, sb.ToStringExtension());

                    if(classs.Protertys.Count > 0 )
                        context = this.ReplaceDataBase(context, classs.Protertys.FirstOrDefault(), true);

                    if (classs.Methods.Count > 0)
                        context = this.ReplaceDataBase(context, classs.Methods.FirstOrDefault(), true);

                 
                }
            }
            return context;
        }

        public string ReplaceDataBase<T>(string context, T t, bool nochange = false) where T : class
        {
            string returnValue = string.Empty;
            var listProperty = t.GetPropertyList();
            foreach (var property in listProperty)
            {
                var value = t.GetPropertyValue(property);
                value = string.IsNullOrEmpty(value) ? property : value; 
                if (context.IndexOf($"@{property}") >= 0)
                {
                    if (nochange)
                        context = context.Replace($"@{property}", value);
                    else
                        returnValue = context.Replace($"@{property}", value);
                }
            }
            return nochange ? context : returnValue;
        }

        public enum SnippetReplace
        {
            [Description("<%!")]
            Start = 0,
            [Description("!%>")]
            End = 1
        }
    }
}
