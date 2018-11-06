using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.UsuallyCommon
{
    public class Method : Classs
    {
        public Method()
        {
            MethodArguments = new List<MethodArgument>();
        }
        //public string ClassName { get; set; }

        public string MethodName { get; set; }

        public string MethodComment { get; set; }

        public string MethodReturnType { get; set; }

        public List<MethodArgument> MethodArguments { get; set; }
    }
}
