using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VSBussinessExtenstion;
using Core.UsuallyCommon;
using System.ComponentModel;
using Core.UsuallyCommon.DataBase;
using System.Windows.Forms;
using VSBussinessExtenstion.DataBaseHelper;

namespace WFGenerator
{
    public class GeneratorClass
    {
        public string GetGenerator(Snippet snippet, object datasource, ServicesAddressHelper sh = null
            )
        {
            if (snippet.IsFloder)
                return string.Empty;
            List<TreeNode> listsource = datasource as List<TreeNode>;

            StringBuilder sb = new StringBuilder();
            StringBuilder sbResult = new StringBuilder(); 

            if (snippet.DataSourceType == DataSourceType.DatabaseType)
            { 
                foreach (TreeNode note in listsource)
                {
                    var context = snippet.Context;
                    List<Column> listColumns = new List<Column>();
                    var listReplace = StringHelper.GetStringListByStartAndEndInner(context, SnippetReplace.Start.GetDescription(), SnippetReplace.End.GetDescription());

                    if (string.IsNullOrEmpty(note.Nodes[0].Text))
                    {
                        Table table = note.Tag as Table;
                        sh.InitColumn(table);
                        listColumns.AddRange(table.Columns);
                    }
                    else
                    {
                        foreach (TreeNode childs in note.Nodes)
                        {
                            if (childs.Checked)
                                listColumns.Add(childs.Tag as Column);
                        }
                    }
                    foreach (var item in listReplace)
                    {
                        var inittempcontext = item.Replace(SnippetReplace.Start.GetDescription(), string.Empty).Replace(SnippetReplace.End.GetDescription(), string.Empty);
                        foreach (var column in listColumns)
                        { 
                            sb.Append(this.ReplaceDataBase<Column>(inittempcontext, column,true)); 
                        }
                        context = context.Replace(item, sb.ToStringExtension());
                    }
                    context = this.ReplaceDataBase(context, listColumns.FirstOrDefault(), true);
                    sbResult.AppendLine(context);
                }
            }
            if (snippet.DataSourceType == DataSourceType.CSharpType)
            {
                var context = snippet.Context;
                var listReplace = StringHelper.GetStringListByStartAndEndInner(context, SnippetReplace.Start.GetDescription(), SnippetReplace.End.GetDescription());

                List<Method> methods = new List<Method>();
                List<Proterty> proterties = new List<Proterty>();

                foreach (TreeNode note in listsource)
                {
                    if (note.Tag != null)
                    {
                        if (note.Tag is Method)
                            methods.Add(note.Tag as Method);
                        if (note.Tag is Proterty)
                            proterties.Add(note.Tag as Proterty);
                    }
                }
                var classnamelist = methods.GroupBy(g => g.ClassName).Select(x => x.Key).Union(proterties.GroupBy(g => g.ClassName).Select(x => x.Key));
                foreach (var classname in classnamelist)
                {
                    string generatorText = string.Empty;
                    context = snippet.Context;
                    var methodslist = methods.Where(x => x.ClassName == classname);
                    var proertyslist = proterties.Where(x => x.ClassName == classname);
                    foreach (var item in listReplace)
                    {
                        var inittempcontext = item.Replace(SnippetReplace.Start.GetDescription(), string.Empty).Replace(SnippetReplace.End.GetDescription(), string.Empty);
                        bool hasArugment = this.HasArgument<MethodArgument>(inittempcontext,
                        methodslist.FirstOrDefault() == null ? null : methodslist.FirstOrDefault().MethodArguments.FirstOrDefault());
                        foreach (var pt in proertyslist)
                        {
                            sb.AppendLine(this.ReplaceDataBase<Core.UsuallyCommon.Proterty>(context, pt, true));
                        }
                        foreach (var mt in methodslist)
                        {
                            if (hasArugment)
                            {
                                context = snippet.Context;
                                StringBuilder sbArgument = new StringBuilder();
                                foreach (var methodArgument in mt.MethodArguments)
                                {
                                    sbArgument.Append(this.ReplaceDataBase<Core.UsuallyCommon.MethodArgument>(inittempcontext, methodArgument, true));
                                }
                                // 改变模板
                                context = context.Replace(item, sbArgument.ToString());
                            }
                            sb.AppendLine(this.ReplaceDataBase<Core.UsuallyCommon.Method>(context, mt, true));
                        }

                        if (methodslist.FirstOrDefault() != null)
                            generatorText = this.ReplaceDataBase(sb.ToStringExtension(), methodslist.FirstOrDefault(), true);
                        if (proertyslist.FirstOrDefault() != null)
                            generatorText = this.ReplaceDataBase(generatorText, proertyslist.FirstOrDefault(), true);
                    }
                    sbResult.AppendLine(generatorText);
                }
            }
            return sbResult.ToStringExtension();
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


        public bool HasArgument<T>(string context, T t) where T : class
        {
            bool hasArgument = false;
            if (t == null)
                return hasArgument;
            var listProperty = t.GetPropertyList();
            foreach (var property in listProperty)
            {
                if (context.IndexOf($"@{property}") >= 0)
                {
                    hasArgument = true;
                    break;
                }
            }

            return hasArgument;
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
