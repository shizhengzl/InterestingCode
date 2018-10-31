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
        public string GetGenerator(Snippet snippet,object datasource)
        { 
            if (snippet.IsFloder)
                return string.Empty;

            var context = snippet.Context;

            var listReplace = StringHelper.GetStringListByStartAndEnd(context, SnippetReplace.Start.GetDescription(), SnippetReplace.End.GetDescription());


            foreach (var item in listReplace)
            {
                if(snippet.DataSourceType == DataSourceType.DatabaseType)
                {
                    var columns = datasource as List<Column>;
                    if (columns.Count == 0)
                        continue;
                    StringBuilder sb = new StringBuilder();

                    var inittempcontext = item.Replace(SnippetReplace.Start.GetDescription(), string.Empty).Replace(SnippetReplace.End.GetDescription(), string.Empty);
                     
                    var listProperty = columns.FirstOrDefault().GetPropertyList();

                    foreach (var column in columns)
                    {
                        var itemreplace = inittempcontext;
                        foreach (var property in listProperty)
                        {
                            var value = column.GetValue(property);
                            value = string.IsNullOrEmpty(value) ? property : value;

                            if(itemreplace.IndexOf($"@{property}") >=0 )
                            {
                                itemreplace = itemreplace.Replace($"@{property}", value); 
                            }
                        }
                        sb.Append(itemreplace);
                    }

                    context = sb.ToStringExtension();
                }

                if(snippet.DataSourceType == DataSourceType.CSharpType)
                {

                }
            } 

            return context;
        }

        public enum SnippetReplace
        {
            [Description("<%!")]
            Start = 0 ,
            [Description("!%>")]
            End = 1
        }
    }
}
