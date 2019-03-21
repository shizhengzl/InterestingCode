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
using DatabaseHelper = Core.UsuallyCommon.DatabaseHelper;

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
                var lists = columns.Where(x => x.TableName == table).ToList();
                context = snippet.Context;
                foreach (var item in listReplace)
                {
                    StringBuilder sb = new StringBuilder();
                    var inittempcontext = item.Replace(SnippetReplace.Start.GetDescription(), string.Empty).Replace(SnippetReplace.End.GetDescription(), string.Empty);

                    foreach (var column in lists)
                    {
                        if (CheckType(column, inittempcontext,lists))
                            sb.Append(this.ReplaceDataBase<Column>(inittempcontext, column, true));

                    }
                    context = context.Replace(item, sb.ToStringExtension());

                }
                context = context.Replace("@Key", string.Empty);
                context = BatchComma(context,columns.FirstOrDefault(),lists);
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


        public string BatchComma(string context, Column column,List<Column> list)
        {

            var defaultsqlite = new DefaultSqlite();
            var noSystemVarbables = defaultsqlite.Variables.Where(x => !x.IsSystemGenerator).ToList();
            foreach (var varbable in noSystemVarbables)
            {
                if (context.IndexOf(varbable.VariableName) > -1)
                {
                    var sql = ReplaceDataBase(varbable.ReplaceString, column, true);
                    if (string.IsNullOrEmpty(DatabaseHelper.connectionString))
                        DatabaseHelper.connectionString =
                            $"server={column.Address};uid={column.User};pwd={column.Password};database={column.DataBaseName};";
                    var replacestring = DatabaseHelper.ExecuteQuery(sql).Tables[0].Rows[0][0].ToString();
                    context = context.Replace(varbable.VariableName, replacestring);
                }
            } 
            StringBuilder stwhere = new StringBuilder();

            foreach (var columntypes in list)
            {
                context = context.Replace($"@{columntypes.CSharpType}", string.Empty);

                if (columntypes.IsPrimarykey)
                {
                    if (string.IsNullOrEmpty(stwhere.ToString()))
                    {
                        stwhere.Append($" Where {columntypes.ColumnName}=@{columntypes.ColumnName}");
                    }
                    else
                    {
                        stwhere.Append($" And {columntypes.ColumnName}=@{columntypes.ColumnName}");
                    }
                }
            }

            context = context.Replace("@Where", stwhere.ToString());
            var comma = "@Comma";
            if (context.IndexOf(comma) < 0)
                return context;
            context = context.Remove(context.LastIndexOf(comma), comma.Length);
            context = context.Replace(comma, ",");
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

        public bool CheckType(Column column, string snippetcontext,List<Column> list)
        {

            if (snippetcontext.Contains($"@NotKey") && (column.IsPrimarykey || column.IsIdentity ))
                return false;
            if (snippetcontext.Contains($"@Key") && (!column.IsPrimarykey) && !column.IsIdentity )
                return false;
            var isexists = false;
            foreach (var columntypes in list)
            {
                isexists = (snippetcontext.Contains($"@{columntypes.CSharpType}"));
                if(isexists)
                    break;
            }
             
            if (isexists)
                return (snippetcontext.Contains($"@{column.CSharpType}"));
           
            return true; 
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
                if(string.IsNullOrEmpty(property) ||  property.ToLower()== "id" || property.ToLower() == "key")
                    continue;
                var value = t.GetPropertyValue(property);
                value = string.IsNullOrEmpty(value) ? property : value;

                if (property == "IsRequire")
                    value = value == "false" ? string.Empty : "?";
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
