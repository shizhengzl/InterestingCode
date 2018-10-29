using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.UsuallyCommon
{
    public class Method
    {
        public Method()
        {
            MethodArguments = new List<MethodArgument>();
        }
        public string ClassName { get; set; }

        public string Name { get; set; }

        public string Comment { get; set; }

        public string ReturnType { get; set; }

        public List<MethodArgument> MethodArguments { get; set; }
    }
}
