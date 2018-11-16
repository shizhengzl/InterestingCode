using EnvDTE;
using EnvDTE80;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace WFGenerator
{
    public static class ApplicationVsHelper
    {
        public static DTE2 _applicationObject;

        public static string VsProjectPath
        {
            get
            {
                try
                {
                    return
                        ApplicationVsHelper._applicationObject.Solution.FileName.Substring(0,
                        ApplicationVsHelper._applicationObject.Solution.FileName.LastIndexOf('\\')) + "\\";
                }
                catch
                {
                    return string.Empty;
                }
            }
        }

        // 关闭所有文件并保存
        public static void Close(bool isSave)
        {
            _applicationObject.Documents.CloseAll(isSave ? vsSaveChanges.vsSaveChangesYes : vsSaveChanges.vsSaveChangesNo);
        }

        public static void EditFormatDocument(string name)
        {
            try
            {
                // _applicationObject.ExecuteCommand("Edit.FormatDocument", name);
                _applicationObject.ExecuteCommand("编辑.设置文档的格式");
                _applicationObject.ExecuteCommand("编辑.折叠到定义");
                _applicationObject.ActiveDocument.Save();
            }
            catch (Exception ex)
            {
                //throw ex;
            }
        }

        // 打开文件
        public static void Open(string name)
        {
            try
            {
                _applicationObject.ExecuteCommand("文件.打开文件", "\"" + name + "\"");
                EditFormatDocument(name);
            }
            catch (Exception ex)
            {
                //throw ex;
            }
        }

        // 迁出工程
        public static void CheckOut(string name)
        {
            try
            {
                if (!_applicationObject.SourceControl.IsItemCheckedOut(name))
                    _applicationObject.SourceControl.CheckOutItem(name);
            }
            catch (Exception ex)
            {
                //throw ex;
            }
        }

        // 获取vs版本
        public static string GetVersion()
        {
            string result = string.Empty;
            if (_applicationObject == null)
                return "2013";
            switch (_applicationObject.Version)
            {
                case "9.0":
                    result = "2008";
                    break;
                case "10.0":
                    result = "2010";
                    break;
                case "11.0":
                    result = "2012";
                    break;
                case "12.0":
                    result = "2013";
                    break;
                default:
                    result = "2013";
                    break;

            }
            return result;
        }

        // 根据路径返回工程   **** 注明 -- 此返回只属于解决方案(sln)下的二级工程
        public static object GetProjItemByUrl(string url)
        {
            //foreach (Project proj in _applicationObject.Solution.Projects)
            //{
            //    if (proj.FullName.Equals("")) // 说明是虚拟文件夹
            //    {
            //        foreach (ProjectItem item in proj.ProjectItems) {
            //            if (item.SubProject != null && item.SubProject.FullName == url)
            //                return item;
            //        }

            //    }
            //    else{
            //        if (proj.FullName == url)
            //            return proj;
            //    }
            //}
            object obj = null;
            try
            {
                foreach (Project project in _applicationObject.Solution.Projects)
                {
                    if (project.FullName.IndexOf(".exe") > 0)
                        continue;
                    if (project.FullName == url)
                        return project;
                    // add proj
                    foreach (ProjectItem item in project.ProjectItems)
                    {
                        if (item.SubProject == null || item.SubProject.UniqueName == null)
                            continue;
                        if (item.SubProject != null && item.SubProject.FullName == url)
                            obj = item;
                        if (obj != null)
                            return obj;
                        CheckChild(item.SubProject.ProjectItems, url, ref obj);
                    }
                }
            }
            catch (System.Exception ex)
            {
                //Common.Controls.Utility.ShowTip("提示LoadComboTree", ex.Message, "", 10000);
            }
            return obj;
        }

        public static void CheckChild(ProjectItems projectitems, string url, ref object obj)
        {
            if (obj != null)
                return;
            foreach (ProjectItem item in projectitems)
            {
                if (item.SubProject == null || item.SubProject.UniqueName == null)
                    continue;
                if (item.SubProject != null && item.SubProject.FullName == url)
                    obj = item;
                CheckChild(item.SubProject.ProjectItems, url, ref obj);
            }
        }


        // 根据工程和文件夹找工程
        public static object FindByProjAndFloder(ProjectItem proj, string floder)
        {
            string result = floder.Replace(proj.SubProject.FullName.Replace("\\" + proj.Name + ".csproj", ""), "");
            string[] sArray; ProjectItem obj = proj;
            result = (result.IndexOf("\\") > -1) ? result.Replace("\\", "&&") : result.Replace("//", "&&");
            sArray = Regex.Split(result, "&&", RegexOptions.IgnorePatternWhitespace);
            foreach (string str in sArray)
            {
                if (str == null || str.Equals(""))
                    continue;
                obj = obj.SubProject.ProjectItems.Item(str);
            }
            return obj;
        }

        // 根据工程和文件夹找工程
        public static object FindByProjAndFloder(Project proj, string floder)
        {
            string result = floder.Replace(proj.FullName.Replace(proj.Name + ".csproj", ""), "");
            result = result.Replace("//", "&&").Replace("\\", "&&");
            string[] sArray; ProjectItem obj = null;

            sArray = Regex.Split(result, "&&", RegexOptions.IgnoreCase);
            foreach (string str in sArray)
            {
                if (str == null || str.Equals(""))
                    continue;
                if (obj != null)
                    obj = obj.ProjectItems.Item(str);
                else
                    obj = proj.ProjectItems.Item(str);
            }
            return obj;
        }

        // 判断工程下是否存在文件
        public static Boolean SearchProjItemByUrl(ProjectItem proj, string filename)
        {
            foreach (ProjectItem pro in proj.SubProject.ProjectItems)
            {
                if (pro.Name != null)
                {
                    if (pro.Name == filename)
                        return true;
                }
            }
            return false;

        }
    }
}
