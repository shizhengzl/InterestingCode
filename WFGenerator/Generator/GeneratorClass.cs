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
using NLog;
using System.IO;

namespace WFGenerator
{
    public class GeneratorClass
    {

        public string DefaltPath = @"C:\Generator\";

        Logger logger = LogManager.GetLogger("NLogs");
        public ToolStripStatusLabel messages { get; set; }
        public GeneratorClass(ToolStripStatusLabel _messages)
        {
            messages = _messages;
        }

        DefaultSqlite defaultsqlite = new DefaultSqlite();
        public void GeneratorFile(string context, string path)
        {
            if (string.IsNullOrEmpty(path))
                return;
            if (File.Exists(path))
                IoHelper.FileOverWrite(path, context);
            else
                Core.UsuallyCommon.IoHelper.CreateFile(path, context);
        }

        public string DataBaseGenerator(List<Column> columns, Snippet snippet, ref StringBuilder messages)
        {
            try
            {
                columns = columns.Where(x => x.IsSelect).ToList();
                string context = snippet.Context;
                if (string.IsNullOrEmpty(snippet.OutputPath))
                {
                    snippet.OutputPath = DefaltPath;
                    messages.AppendLine($"没有设置生成路劲，系统初始化路劲为：{snippet.OutputPath}");
                }

                if (string.IsNullOrEmpty(snippet.GeneratorFileName))
                {
                    snippet.GeneratorFileName = "@TableName.cs";
                    messages.AppendLine($"没有设置生成文件名，系统初始化文件名为：{snippet.GeneratorFileName}");
                }
                context = UserDeclareVarbibles(context, columns, ref messages);
                // 处理controls
                columns.ForEach(x =>
                {
                    if (!string.IsNullOrEmpty(x.SearchControls))
                    {
                        x.SearchControls = ReplaceDataBase(x.SearchControl.ControlText, x, true);
                        if (x.SearchControl.ControlDataSources != null)
                            x.SearchControls = ReplaceDataBase(x.SearchControls, x.SearchControl.ControlDataSources, true);
                    }

                    if (!string.IsNullOrEmpty(x.GridControls))
                    {
                        x.GridControls = ReplaceDataBase(x.GridControl.ControlText, x, true);
                        if (x.GridControl.ControlDataSources != null)
                            x.GridControls = ReplaceDataBase(x.GridControls, x.GridControl.ControlDataSources, true);
                    }

                    if (!string.IsNullOrEmpty(x.CreateControls))
                    {
                        x.CreateControls = ReplaceDataBase(x.CreateControl.ControlText, x, true);
                        if (x.CreateControl.ControlDataSources != null)
                        {
                            x.CreateControls = ReplaceDataBase(x.CreateControls, x.CreateControl.ControlDataSources, true);
                            AppendCode(x.CreateControl, x);
                        }
                    }
                    if (!string.IsNullOrEmpty(x.ModifyControls))
                    {
                        x.ModifyControls = ReplaceDataBase(x.ModifyControl.ControlText, x, true);
                        if (x.ModifyControl.ControlDataSources != null)
                            x.ModifyControls = ReplaceDataBase(x.ModifyControls, x.ModifyControl.ControlDataSources, true);
                    }
                }
                );

                var listReplace = StringHelper.GetStringListByStartAndEndInner(context, SnippetReplace.Start.GetDescription(), SnippetReplace.End.GetDescription());

                messages.AppendLine($"开始替换模板变量........");
                foreach (var item in listReplace)
                {
                    var inittempcontext = item.Replace(SnippetReplace.Start.GetDescription(), string.Empty).Replace(SnippetReplace.End.GetDescription(), string.Empty);

                    context = context.Replace(item, ScriptsRuns.GetScriptsRuns(inittempcontext, columns));
                }

                context = this.ReplaceDataBase(context, columns.FirstOrDefault(), true);

                 
                string filename = this.ReplaceDataBase(snippet.GeneratorFileName, columns.FirstOrDefault(), true);

                string url = DefaltPath + filename;
                messages.AppendLine($"自动默认路径：{url}");
                string generatorurl = ApplicationVsHelper.VsProjectPath.ToStringExtension()
                          + snippet.OutputPath.Replace("/", "\\") + "\\" + filename;
                messages.AppendLine($"生成到工程路劲：{generatorurl}");
           

                if (snippet.IsAutoFind && !string.IsNullOrEmpty(generatorurl))
                {
                    messages.AppendLine($"启用了自动查找文件{generatorurl.GetFileDirectory()}下的文件：{generatorurl.GetFileName() + generatorurl.GetFileExtension()}");
                    List<string> list = new List<string>();
                    IoHelper.GetFiles(generatorurl.GetFileDirectory(), generatorurl.GetFileName() + generatorurl.GetFileExtension(), ref list);
                    if (list.Count > 0)
                    {
                        generatorurl = list.FirstOrDefault();
                        messages.AppendLine($"自动查找的路劲：{generatorurl}");
                    }
                }

                GeneratorFile(context, url);
                if (snippet.IsMergin && File.Exists(generatorurl))
                {
                    messages.AppendLine($"启用了自动合并功能");
                    context = CompileUnitParser.MergeFile(generatorurl,url, context);
                }

               

                if (!string.IsNullOrEmpty(generatorurl))
                { 
                    GeneratorFile(context, generatorurl);
                    ApplicationVsHelper.Open(generatorurl);
                }

               
                context = IoHelper.FileReader(url);
                messages.AppendLine($"生成完成........");
                return context;

            }
            catch (Exception ex)
            {
                logger.Error(ex);
                messages.AppendLine($"生成出错:{ex.Message}........");
            }
            return string.Empty;
        }

        public void AppendCode(Core.UsuallyCommon.DataBase.Control control, Column column)
        {
            var url = control.AppendCodeUrl;
            if (string.IsNullOrEmpty(url))
                return;
            url = this.ReplaceDataBase(url, control.ControlDataSources, true);
            url = this.ReplaceDataBase(url, column, true);


            string filename = (!string.IsNullOrEmpty(control.AppendCodeUrl)
                ? ApplicationVsHelper.VsProjectPath.ToStringExtension() : string.Empty) + url;

            var code = this.ReplaceDataBase(control.AppendCode, control.ControlDataSources, true);
            code = this.ReplaceDataBase(code, column, true);

            if (string.IsNullOrEmpty(control.AppendCodeUrl) || !File.Exists(filename))
            {
                url = DefaltPath + "AppendCode.cs";
                // 创建文件
                Core.UsuallyCommon.IoHelper.CreateFile(url, code);
            }
            else
            {
                // append code
                if (filename.GetFileExtension() == ".cs")
                {
                    // apend code
                    CompileUnitParser.AppendCode(filename, control.AppendCode);
                    ApplicationVsHelper.Open(filename);
                }
                else
                {
                    // show 
                }
            }



        }

        public string UserDeclareVarbibles(string context, List<Column> columns, ref StringBuilder messages)
        {
            try
            {
                var noSystemVarbables = defaultsqlite.Variables.Where(x => !x.IsSystemGenerator).ToList();

                foreach (var varbable in noSystemVarbables)
                {
                    StringBuilder sb = new StringBuilder();
                    if (context.IndexOf(varbable.VariableName) > -1)
                    {
                        messages.AppendLine($"找到自定义变量:{varbable.VariableName}");
                        var text = varbable.ReplaceString;
                        if (varbable.VariableType == DataSourceType.DatabaseType)
                        {
                            defaultsqlite.Database.Connection.ConnectionString = columns.FirstOrDefault().ConnectionStrings;
                            var sql = ReplaceDataBase(varbable.ReplaceString, columns.FirstOrDefault(), true);
                            messages.AppendLine($"改变量为数据库变量SQL:{sql}，执行数据库连接：{columns.FirstOrDefault().ConnectionStrings}");
                            var replacestring = defaultsqlite.Database.SqlQuery<string>(sql).ToString();
                            context = context.Replace(varbable.VariableName, replacestring);
                            defaultsqlite.Database.Connection.ConnectionString = DefaultSqlite.DefaultSqltiteConnection;
                        }
                        columns.ForEach(column =>
                        {

                            if (varbable.VariableType == DataSourceType.CSharpType)
                            {
                                if (column.SearchControl?.ControlDataSources != null)
                                    sb.AppendLine(this.ReplaceDataBase(text, column.SearchControl.ControlDataSources, true));
                                if (column.GridControl?.ControlDataSources != null)
                                    sb.AppendLine(this.ReplaceDataBase(text, column.GridControl.ControlDataSources, true));
                                if (column.CreateControl?.ControlDataSources != null)
                                    sb.AppendLine(this.ReplaceDataBase(text, column.CreateControl.ControlDataSources, true));
                                if (column.ModifyControl?.ControlDataSources != null)
                                    sb.AppendLine(this.ReplaceDataBase(text, column.ModifyControl.ControlDataSources, true));

                            }
                        });
                    }

                    context = context.Replace(varbable.VariableName, sb.ToString());
                }
                return context;

            }
            catch (Exception ex)
            {
                logger.Error(ex);
                messages.AppendLine($"生成出错:{ex.Message}........");
            }
            return string.Empty;
        }

        public string ClassGenerator(List<Method> methods, List<Proterty> proterties, Snippet snippet)
        {
            try
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

                    string filename = (ApplicationVsHelper._applicationObject == null
                      ? string.Empty : ApplicationVsHelper.VsProjectPath)
                      + snippet.OutputPath.Replace("/", "\\") + "\\"
                      + this.ReplaceDataBase(snippet.GeneratorFileName, methods.FirstOrDefault(), true);
                    GeneratorFile(result, filename);

                }
                return sb.ToString();

            }
            catch (Exception ex)
            {
                logger.Error(ex);
                messages.Text = $"生成出错：{ex.Message}........";
            }
            return string.Empty;
        }


        public string GetGenerator(Snippet snippet,Table table , ref StringBuilder sbResult)
        {
            if (snippet.DataSourceType == DataSourceType.DatabaseType)
            {

                if (snippet.IsSelectGenerator)
                {
                    SelectColumn selectColumn = new SelectColumn(table);
                    DialogResult diaResult = selectColumn.ShowDialog();
                }
                return DataBaseGenerator(table.Columns, snippet, ref sbResult);
            }
            if (snippet.DataSourceType == DataSourceType.CSharpType)
            {
                List<Method> methods = new List<Method>();
                List<Proterty> proterties = new List<Proterty>();
                return ClassGenerator(methods, proterties, snippet);
            }
            return string.Empty;
        }

        public string ReplaceDataBase<T>(string context, T t, bool nochange = false) where T : class
        {
            string returnValue = string.Empty;

            bool isstring = false;
            if (t.GetType().Name == typeof(Column).Name)
            {
                Column col = t as Column;
                isstring = col.CSharpType.ToLower() == "String".ToLower();
            }

            var listProperty = t.GetPropertyList();
            foreach (var property in listProperty)
            {
                if (string.IsNullOrEmpty(property))
                    continue;
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
