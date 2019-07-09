using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.UsuallyCommon
{
    public class Classs
    {

        /// <summary>
        /// 描述
        /// </summary>
        /// <returns>ABD</returns> 
        public List<string> GetMethod()
        {
            return null;

        }

        public Classs()
        {
            Methods = new List<Method>();
            Protertys = new List<Proterty>();
        }
        public string ClassName { get; set; }

        public string ClassComment { get; set; }
        /// <summary>
        /// 命名空间
        /// </summary>
        public string NameSpace { get; set; }

        public List<Method> Methods { get; set; }

        public List<Proterty> Protertys { get; set; }
    }
}
