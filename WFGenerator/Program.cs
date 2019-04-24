using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WFGenerator
{

    /*
     C:\Windows\Microsoft.NET\Framework\v4.0.30319\Config
 
    <add name="DefaultSqlite" connectionString="Data Source=172.18.132.141;port=3306;Initial Catalog=DefaultSqlite;uid=root;password=123456;Charset=utf8" providerName="MySql.Data.MySqlClient"/>
   */
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {

              

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new GeneartorTools());
        }
    }
}
