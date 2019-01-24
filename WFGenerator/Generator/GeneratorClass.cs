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
        public void GeneratorFile(string context, string path)
        {
            if (string.IsNullOrEmpty(path))
                return;
            Core.UsuallyCommon.IoHelper.CreateFile(path, context);
        }

        public string DataBaseGenerator(List<Column> columns, Snippet snippet, Boolean generatorFile)
        {
            if (string.IsNullOrEmpty(snippet.OutputPath))
                snippet.OutputPath = @"C:\Generator\";
            string context = snippet.Context;
            var listReplace = StringHelper.GetStringListByStartAndEndInner(context, SnippetReplace.Start.GetDescription(), SnippetReplace.End.GetDescription());

            StringBuilder sbResult = new StringBuilder();
            var tables = columns.GroupBy(x => x.TableName).Select(y => y.Key).ToList<string>();
            foreach (var table in tables)
            {
                var lists = columns.Where(x => x.TableName == table);
                context = snippet.Context;
                foreach (var item in listReplace)
                {
                    StringBuilder sb = new StringBuilder();
                    var inittempcontext = item.Replace(SnippetReplace.Start.GetDescription(), string.Empty).Replace(SnippetReplace.End.GetDescription(), string.Empty);

                    foreach (var column in lists)
                    {
                        sb.Append(this.ReplaceDataBase<Column>(inittempcontext, column, true));

                    }
                    context = context.Replace(item, sb.ToStringExtension());

                }
                context = this.ReplaceDataBase(context, columns.FirstOrDefault(), true);
                if (generatorFile)
                {
                    string filename = (ApplicationVsHelper._applicationObject == null
                        ? string.Empty : ApplicationVsHelper.VsProjectPath) + snippet.OutputPath.Replace("/", "\\") + "\\" + this.ReplaceDataBase(snippet.GeneratorFileName, columns.FirstOrDefault(), true);
                    GeneratorFile(context, filename);
                }
                sbResult.AppendLine(context);
            }
            return context;
        }

        public string ClassGenerator(List<Method> methods, List<Proterty> proterties, Snippet snippet, bool generatorFile)
        {
            string context = snippet.Context;
            string result = string.Empty;
            var listReplace = StringHelper.GetStringListByStartAndEndInner(context, SnippetReplace.Start.GetDescription(), SnippetReplace.End.GetDescription());
            StringBuilder sb = new StringBuilder();
            StringBuilder sbResult = new StringBuilder();
            var classnamelist = methods.GroupBy(g => g.ClassName).Select(x => x.Key).Union(proterties.GroupBy(g => g.ClassName).Select(x => x.Key));
            foreach (var classname in classnamelist)
            {
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
                        result = this.ReplaceDataBase(sb.ToStringExtension(), methodslist.FirstOrDefault(), true);
                    if (proertyslist.FirstOrDefault() != null)
                        result = this.ReplaceDataBase(result, proertyslist.FirstOrDefault(), true);
                }
                sbResult.AppendLine(result);
                if (generatorFile)
                {
                    string filename = (ApplicationVsHelper._applicationObject == null
                      ? string.Empty : ApplicationVsHelper.VsProjectPath)
                      + snippet.OutputPath.Replace("/", "\\") + "\\"
                      + this.ReplaceDataBase(snippet.GeneratorFileName, methods.FirstOrDefault(), true);
                    GeneratorFile(result, filename);
                }
            }
            return sb.ToString();
        }

        public string GetGenerator(Snippet snippet, object datasource, ServicesAddressHelper sh = null
           , Boolean generatorFile = false)
        {
            if (snippet.IsFloder)
                return string.Empty;
            List<TreeNode> listsource = datasource as List<TreeNode>;
            StringBuilder sbResult = new StringBuilder();

            if (snippet.DataSourceType == DataSourceType.DatabaseType)
            {
                foreach (TreeNode note in listsource)
                {
                    List<Column> listColumns = new List<Column>();
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
                    sbResult.AppendLine(DataBaseGenerator(listColumns, snippet, generatorFile));
                }
            }
            if (snippet.DataSourceType == DataSourceType.CSharpType)
            {
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
                sbResult.AppendLine(ClassGenerator(methods, proterties, snippet, generatorFile));
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
