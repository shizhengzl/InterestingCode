using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.UsuallyCommon
{
    public class Classs
    {
        public Classs()
        {
            Methods = new List<Method>();
            Protertys = new List<Proterty>();
        }
        public string ClassName { get; set; }

        public string ClassComment { get; set; }

        public string NameSpace { get; set; }

        public List<Method> Methods { get; set; }

        public List<Proterty> Protertys { get; set; }
    }
}
