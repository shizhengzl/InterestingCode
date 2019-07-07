using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.UsuallyCommon
{
    public class CSharpParser
    {
    

        public CSharpParser(String context)
        {
            root = CSharpSyntaxTree.ParseText(context).GetCompilationUnitRoot();
            collector = new ObjectCollector();
            collector.Visit(root);
        }

        public CSharpParser(String FilePath, bool IsUrl = true)
        {
            string context = IoHelper.FileReader(FilePath);
            root = CSharpSyntaxTree.ParseText(context).GetCompilationUnitRoot();
            collector = new ObjectCollector();
            collector.Visit(root);
        }

        public CompilationUnitSyntax root { get; set; }
        public ObjectCollector collector { get; set; }

        public List<Classs> GetClass()
        {
            return collector.classList;
        }

        public List<Proterty> GetProterty()
        {
            return collector.classList.SelectMany(x=>x.Protertys).ToList<Proterty>();
        }

        public List<string> GetUsing()
        {
            var list = new List<string>();
            foreach (var item in collector.Usings)
            {
                list.Add(item.Name.ToStringExtension());
            }
            return list;
        }
    }
}
