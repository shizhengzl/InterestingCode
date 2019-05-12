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
            Core.UsuallyCommon.IoHelper.CreateFile(path, context);
        }

        public string DataBaseGenerator(List<Column> columns, Snippet snippet, Boolean generatorFile)
        {
            try
            {
                columns = columns.Where(x => x.IsSelect).ToList();
                if (string.IsNullOrEmpty(snippet.OutputPath))
                    snippet.OutputPath = DefaltPath;
                if (string.IsNullOrEmpty(snippet.GeneratorFileName))
                    snippet.GeneratorFileName = "@TableName.cs";
                string context = snippet.Context;

                messages.Text = $"开始替自定义变量........";
                context = UserDeclareVarbibles(context, columns);

                messages.Text = $"正在处理控件数据........";
                // 处理controls
                columns.ForEach(x =>
                {
                    if (!string.IsNullOrEmpty(x.SearchControls))
                    {
                        var control = defaultsqlite.Controls.FirstOrDefault(y => y.ControlName == x.SearchControls);
                        x.SearchControls = ReplaceDataBase(control.ControlText, x, true);
                        if (x.SearchControl.ControlDataSources != null)
                            x.SearchControls = ReplaceDataBase(x.SearchControls, x.SearchControl.ControlDataSources, true);
                    }

                    if (!string.IsNullOrEmpty(x.GridControls))
                    {
                        var control = defaultsqlite.Controls.FirstOrDefault(y => y.ControlName == x.GridControls);
                        x.GridControls = ReplaceDataBase(control.ControlText, x, true);
                        if (x.GridControl.ControlDataSources != null)
                            x.GridControls = ReplaceDataBase(x.GridControls, x.GridControl.ControlDataSources, true);
                    }

                    if (!string.IsNullOrEmpty(x.CreateControls))
                    {
                        var control = defaultsqlite.Controls.FirstOrDefault(y => y.ControlName == x.CreateControls);
                        x.CreateControls = ReplaceDataBase(control.ControlText, x, true);
                        if (x.CreateControl.ControlDataSources != null)
                            x.CreateControls = ReplaceDataBase(x.CreateControls, x.CreateControl.ControlDataSources, true);
                    }

                    if (!string.IsNullOrEmpty(x.ModifyControls))
                    {
                        var control = defaultsqlite.Controls.FirstOrDefault(y => y.ControlName == x.ModifyControls);
                        x.ModifyControls = ReplaceDataBase(control.ControlText, x, true);
                        if (x.ModifyControl.ControlDataSources != null)
                            x.ModifyControls = ReplaceDataBase(x.ModifyControls, x.ModifyControl.ControlDataSources, true);
                    }

                }
                );

                var listReplace = StringHelper.GetStringListByStartAndEndInner(context, SnippetReplace.Start.GetDescription(), SnippetReplace.End.GetDescription());
                
                messages.Text = $"开始替换模板变量........";
                foreach (var item in listReplace)
                {
                    var inittempcontext = item.Replace(SnippetReplace.Start.GetDescription(), string.Empty).Replace(SnippetReplace.End.GetDescription(), string.Empty);

                    context = context.Replace(item, ScriptsRuns.GetScriptsRuns(inittempcontext, columns));
                }

                context = this.ReplaceDataBase(context, columns.FirstOrDefault(), true);


                string filename = ApplicationVsHelper.VsProjectPath.ToStringExtension()
                + snippet.OutputPath.Replace("/", "\\") + "\\" + this.ReplaceDataBase(snippet.GeneratorFileName, columns.FirstOrDefault(), true);

                messages.Text = $"开始生成文件........";
                GeneratorFile(context, filename);

                if (ApplicationVsHelper._applicationObject != null)
                {
                    var ext = filename.GetFileExtension();
                    List<string> vs = new List<string>() { ".cs", ".js", ".aspx", ".cshtml" };
                    if (vs.Any(x => x == ext))
                    {
                        ApplicationVsHelper.Open(filename);
                        if (!generatorFile)
                            ApplicationVsHelper.Close(filename);
                    }

                }
                context = IoHelper.FileReader(filename);
                messages.Text += $"生成完成........";
                return context;

            }
            catch (Exception ex)
            {
                logger.Error(ex);
                messages.Text = $"生成出错:{ex.Message}........";
            }
            return string.Empty;
        }

        public void AppendCode(Core.UsuallyCommon.DataBase.Control control, Column column)
        {
            var url = control.AppendCodeUrl;
            if(string.IsNullOrEmpty(control.AppendCodeUrl))
            {
                url = DefaltPath + "AppendCode.cs";
            }
            url = this.ReplaceDataBase(url, control.ControlDataSources, true);
            url = this.ReplaceDataBase(url, column, true);

            string filename = !string.IsNullOrEmpty(control.AppendCodeUrl) ? ApplicationVsHelper.VsProjectPath.ToStringExtension() : string.Empty  + url;

            var code = this.ReplaceDataBase(control.AppendCode, control.ControlDataSources, true);
            code = this.ReplaceDataBase(code, column, true);
             
             
        }

        public string UserDeclareVarbibles(string context, List<Column> columns)
        {
            try
            {
                var controls = defaultsqlite.Controls.ToList();
                var noSystemVarbables = defaultsqlite.Variables.Where(x => !x.IsSystemGenerator).ToList();
                messages.Text = $"初始化自定义变的数据库连接........";


                foreach (var varbable in noSystemVarbables)
                {
                    StringBuilder sb = new StringBuilder();
                    if (context.IndexOf(varbable.VariableName) > -1)
                    { 
                        foreach (var column in columns)
                        { 
                            var text = varbable.ReplaceString;
                            if (varbable.VariableType == DataSourceType.DatabaseType)
                            {
                                defaultsqlite.Database.Connection.ConnectionString = column.ConnectionStrings;
                                var sql = ReplaceDataBase(varbable.ReplaceString, column, true);
                                var replacestring = defaultsqlite.Database.SqlQuery<string>(sql).ToString();
                                context = context.Replace(varbable.VariableName, replacestring);
                                defaultsqlite.Database.Connection.ConnectionString = DefaultSqlite.DefaultSqltiteConnection;
                            }
                            if (varbable.VariableType == DataSourceType.CSharpType)
                            {
                                var searchcontrol = controls.FirstOrDefault(x => x.ControlName == column.SearchControls);
                                if (column.SearchControl?.ControlDataSources != null)
                                    sb.AppendLine(this.ReplaceDataBase(text, column.SearchControl.ControlDataSources, true));


                                var createcontrol = controls.FirstOrDefault(x => x.ControlName == column.CreateControls);
                                if (column.CreateControl?.ControlDataSources != null)
                                    sb.AppendLine(this.ReplaceDataBase(text, column.CreateControl.ControlDataSources, true));


                                var modifycontrol = controls.FirstOrDefault(x => x.ControlName == column.ModifyControls);
                                if (column.ModifyControl?.ControlDataSources != null)
                                    sb.AppendLine(this.ReplaceDataBase(text, column.ModifyControl.ControlDataSources, true));

                            }
                        }
                    }

                    context = context.Replace(varbable.VariableName, sb.ToString());
                }
                messages.Text = $"替换自定义变量完成........";
                return context;

            }
            catch (Exception ex)
            {
                logger.Error(ex);
                messages.Text = $"生成出错:{ex.Message}........";
            }
            return string.Empty;
        }

        public string ClassGenerator(List<Method> methods, List<Proterty> proterties, Snippet snippet, bool generatorFile)
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
            catch (Exception ex)
            {
                logger.Error(ex);
                messages.Text = $"生成出错：{ex.Message}........";
            }
            return string.Empty;
        }


        public string GetGenerator(Snippet snippet, object datasource, ServicesAddressHelper sh = null
           , Boolean generatorFile = false)
        {
            if (snippet.IsFloder)
            {
                messages.Text = $"请选择模板，而非文件夹生成。";
                return string.Empty;
            }
            List<TreeNode> listsource = datasource as List<TreeNode>;
            if (listsource.Count == 0)
            {
                messages.Text = $"请选表来生成。";
                return string.Empty;
            }

            StringBuilder sbResult = new StringBuilder();

            if (snippet.DataSourceType == DataSourceType.DatabaseType)
            {
                if (!generatorFile)
                {
                    Table table = listsource.FirstOrDefault().Tag as Table;
                    messages.Text = $"初始化表结构数据........";
                    sh.InitColumn(table);
                    if (snippet.IsSelectGenerator)
                    {
                        SelectColumn selectColumn = new SelectColumn(table);
                        DialogResult diaResult = selectColumn.ShowDialog();
                    }

                    sbResult.AppendLine(DataBaseGenerator(table.Columns, snippet, generatorFile));
                }
                else
                {
                    listsource.ForEach(x =>
                    {
                        var table = x.Tag as Table;
                        sh.InitColumn(table);

                        if (snippet.IsSelectGenerator)
                        {
                            SelectColumn selectColumn = new SelectColumn(table);
                            DialogResult diaResult = selectColumn.ShowDialog();
                        }


                        DataBaseGenerator(table.Columns, snippet, generatorFile);
                    });
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
