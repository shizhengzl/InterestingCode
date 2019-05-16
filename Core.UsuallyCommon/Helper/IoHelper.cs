using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.UsuallyCommon
{
    public static class IoHelper
    {
        /// <summary>
        /// 替换字符串之间的类容
        /// </summary>
        /// <param name="oldchar"></param>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        public static string ReplaceStartToEnd(string oldchar, string start, string end, string replace)
        {
            Int32 startidex = oldchar.IndexOf(start);
            Int32 endindex = oldchar.IndexOf(end);
            return oldchar.Replace(oldchar.Substring(startidex, endindex - startidex + 2), replace);

        }

        /// <summary>
        /// 读取字符串之间的类容
        /// </summary>
        /// <param name="oldchar"></param>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        public static string ReadStartToEnd(string oldchar, string start, string end)
        {
            Int32 startidex = oldchar.IndexOf(start);
            Int32 endindex = oldchar.IndexOf(end);
            return oldchar.Substring(startidex + 2, endindex - startidex - 2);
        }

        /// <summary>
        /// 读取文件形成字符串
        /// </summary>
        /// <param name="Path">文件路径</param>
        /// <returns></returns>
        public static string FileReader(string Path)
        {
            StreamReader dvStreamReader = new StreamReader(Path, Encoding.Default);
            string result = dvStreamReader.ReadToEnd();
            dvStreamReader.Close();
            return result;
        }

        /// <summary>
        /// 写入文件
        /// </summary>
        /// <param name="path">要写入的路径</param>
        /// <param name="content">要写入的内容</param>
        public static void WrireFile(string path, string content)
        {
            //StreamWriter writer = new FileInfo(path).CreateText();
            FileStream fs = new FileStream(path, FileMode.Create);
            StreamWriter writer = new StreamWriter(fs, Encoding.Default);
            writer.Flush();
            writer.Write(content);
            writer.Close();
            fs.Close();
        }

        /// <summary>
        /// 覆盖文件
        /// </summary>
        /// <param name="path"></param>
        /// <param name="content"></param>
        public static void FileOverWrite(string path, string content)
        {

            StreamWriter writer = new StreamWriter(path, false, Encoding.Default);
            writer.Flush();
            writer.Write(content);
            writer.Close();

        }

        /// <summary>
        /// 创建文件
        /// </summary>
        /// <param name="Path">路劲</param>
        /// <param name="Content">内容</param>
        public static void CreateFile(string Path, string Content)
        {
            if (!System.IO.File.Exists(Path))
            {
                var url = Path.GetFileDirectory();
                if (!Directory.Exists(url))//如果不存在就创建file文件夹　　             　　              
                    Directory.CreateDirectory(url);//创建该文件夹　　       
                AppendFile(Path, Content);
            }
            else
            {
                StreamWriter writer = new StreamWriter(Path, false, Encoding.Default);
                writer.Flush();
                writer.Write(Content);
                writer.Close();
            }
        }

        /// <summary>
        /// 追加文件
        /// </summary>
        /// <param name="path"></param>
        /// <param name="Content"></param>
        public static void AppendFile(string path, string Content)
        {
            if (!File.Exists(path))
            {
                FileInfo myfile = new FileInfo(path);
                FileStream fs = myfile.Create();
                fs.Close();
            }
            StreamWriter sw = File.AppendText(path);
            sw.WriteLine(Content);
            sw.Flush();
            sw.Close();
        }

        /// <summary>
        /// 追加方法 
        /// </summary>
        /// <param name="Path"></param>
        /// <param name="chr"></param>
        /// <param name="Count"></param>
        /// <param name="AppendContent"></param>
        public static string ReplaceToEndAndAppend(string Path, string chr, Int32 Count, string AppendContent)
        {
            string content = FileReader(Path);
            for (int i = 0; i < Count; i++)
            {
                content = content.Substring(0, content.LastIndexOf(chr));
            }

            for (int j = 0; j < Count; j++)
            {
                AppendContent += chr;
            }

            content += AppendContent;
            return content;
        }

        /// <summary>
        /// 追加方法 
        /// </summary>
        /// <param name="Path"></param>
        /// <param name="chr"></param>
        /// <param name="Count"></param>
        /// <param name="AppendContent"></param>
        public static string ReplaceToEndAndAppend_SET(string content, string chr, Int32 Count, string AppendContent)
        {

            for (int i = 0; i < Count; i++)
            {
                content = content.Substring(0, content.LastIndexOf(chr));
            }

            for (int j = 0; j < Count; j++)
            {
                AppendContent += chr;
            }

            content += AppendContent;
            return content;
        }

        public static void DeleteFile(string path)
        {
            if (File.Exists(path))
            {
                File.Delete(path);
            }
        }

        /// <summary>
        /// 将文件转换为byte数组
        /// </summary>
        /// <param name="path">文件地址</param>
        /// <returns>转换后的byte数组</returns>
        public static byte[] FileToBytes(this string path)
        {
            if (!System.IO.File.Exists(path))
            {
                return new byte[0];
            }

            FileInfo fi = new FileInfo(path);
            byte[] buff = new byte[fi.Length];

            FileStream fs = fi.OpenRead();
            fs.Read(buff, 0, Convert.ToInt32(fs.Length));
            fs.Close();

            return buff;
        }

        /// <summary>
        /// 将byte数组转换为文件并保存到指定地址
        /// </summary>
        /// <param name="buff">byte数组</param>
        /// <param name="savepath">保存地址</param>
        public static void BytesToFile(this byte[] buff, string savepath)
        {
            if (System.IO.File.Exists(savepath))
            {
                System.IO.File.Delete(savepath);
            }

            FileStream fs = new FileStream(savepath, FileMode.CreateNew);
            BinaryWriter bw = new BinaryWriter(fs);
            bw.Write(buff, 0, buff.Length);
            bw.Close();
            fs.Close();
        } 

        /// <summary>
        /// 判断文件夹是否存在文件
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="FileName"></param>
        /// <param name="list"></param>
        public static void GetFiles(string filePath, string FileName, ref List<string> list)
        {
            if (!System.IO.Directory.Exists(filePath))
                return;
            try
            {
                DirectoryInfo folder = new DirectoryInfo(filePath);
                FileInfo[] chldFiles = folder.GetFiles("*.*");
                foreach (FileInfo chlFile in chldFiles)
                {
                    if (chlFile.Name.ToUpper() == FileName.ToUpper())
                    {
                        list.Add(chlFile.FullName);
                    } 
                }
                DirectoryInfo[] chldFolders = folder.GetDirectories();
                foreach (DirectoryInfo chldFolder in chldFolders)
                {
                    GetFiles(chldFolder.FullName, FileName,ref list);
                }
            }
            catch (System.Exception ex)
            {

            } 
        }
    }
}
