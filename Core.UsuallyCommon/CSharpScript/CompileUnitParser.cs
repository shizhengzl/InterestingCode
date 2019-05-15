using ICSharpCode.NRefactory;
using ICSharpCode.NRefactory.PrettyPrinter;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.UsuallyCommon
{
    public static class CompileUnitParser
    {


        public static bool IsExists(ICSharpCode.NRefactory.Ast.CompilationUnit New, string compareNameSpace, string compareClassName, ICSharpCode.NRefactory.Ast.INode Node)
        {
            bool result = false;

            ICSharpCode.NRefactory.Ast.MethodDeclaration compareMember = null;
            ICSharpCode.NRefactory.Ast.FieldDeclaration compareField = null;
            ICSharpCode.NRefactory.Ast.PropertyDeclaration compareProperty = null;
            if (Node is ICSharpCode.NRefactory.Ast.MethodDeclaration)
                compareMember = (ICSharpCode.NRefactory.Ast.MethodDeclaration)Node;

            if (Node is ICSharpCode.NRefactory.Ast.FieldDeclaration)
                compareField = (ICSharpCode.NRefactory.Ast.FieldDeclaration)Node;

            if (Node is ICSharpCode.NRefactory.Ast.PropertyDeclaration)
                compareProperty = (ICSharpCode.NRefactory.Ast.PropertyDeclaration)Node;

            //List<NamespaceMembers> list = new List<NamespaceMembers>();
            foreach (ICSharpCode.NRefactory.Ast.INode namespaces in New.Children)
            {
                // 排除using
                if (namespaces is ICSharpCode.NRefactory.Ast.UsingDeclaration)
                    continue;
                if (namespaces is ICSharpCode.NRefactory.Ast.NamespaceDeclaration)
                {
                    string nameSpaceName = ((ICSharpCode.NRefactory.Ast.NamespaceDeclaration)(namespaces)).Name;
                    foreach (ICSharpCode.NRefactory.Ast.INode classs in namespaces.Children)
                    {
                        // 排除不是class
                        if (!(classs is ICSharpCode.NRefactory.Ast.TypeDeclaration))
                            continue;
                        string className = ((ICSharpCode.NRefactory.Ast.TypeDeclaration)(classs)).Name;
                        // 字段和方法
                        foreach (ICSharpCode.NRefactory.Ast.INode members in classs.Children)
                        {
                            bool ismember = members is ICSharpCode.NRefactory.Ast.MethodDeclaration;
                            bool isfields = members is ICSharpCode.NRefactory.Ast.FieldDeclaration;
                            bool isproperty = members is ICSharpCode.NRefactory.Ast.PropertyDeclaration;
                            if (ismember || isfields || isproperty)
                            {
                                if (members is ICSharpCode.NRefactory.Ast.MethodDeclaration)
                                {
                                    ICSharpCode.NRefactory.Ast.MethodDeclaration md = ((ICSharpCode.NRefactory.Ast.MethodDeclaration)members);

                                    if (compareMember != null && compareNameSpace == nameSpaceName && className == compareClassName && compareMember.Name == md.Name && md.TypeReference.Type == compareMember.TypeReference.Type)
                                    {
                                        if (md.Parameters.Count == compareMember.Parameters.Count)
                                        {
                                            if (md.Parameters.Count == 0)
                                                result = true;
                                            for (int i = 0; i < md.Parameters.Count; i++)
                                            {
                                                if (md.Parameters[i].TypeReference.Type == compareMember.Parameters[i].TypeReference.Type)
                                                {
                                                    result = true;
                                                }
                                            }
                                        }
                                    }
                                }
                                if (members is ICSharpCode.NRefactory.Ast.FieldDeclaration)
                                {
                                    if (compareField != null && compareNameSpace == nameSpaceName && className == compareClassName)
                                    {
                                        ICSharpCode.NRefactory.Ast.FieldDeclaration mf = ((ICSharpCode.NRefactory.Ast.FieldDeclaration)members);
                                        if (mf.Fields[0].Name == compareField.Fields[0].Name)
                                        {
                                            result = true;
                                        }
                                    }
                                }
                                if (members is ICSharpCode.NRefactory.Ast.PropertyDeclaration)
                                {
                                    if (compareProperty != null && compareNameSpace == nameSpaceName && className == compareClassName)
                                    {
                                        ICSharpCode.NRefactory.Ast.PropertyDeclaration pd = (ICSharpCode.NRefactory.Ast.PropertyDeclaration)members;
                                        if (pd.Name == compareProperty.Name)
                                        {
                                            result = true;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            return result;
        }

        // 跟CompilationUnit追加节点
        public static void AppendNode(ICSharpCode.NRefactory.Ast.CompilationUnit New, ICSharpCode.NRefactory.Ast.INode Node, string compareNameSpace, string compareClassName, int CurrentIndex, ICSharpCode.NRefactory.Ast.CompilationUnit Old, IParser parser)
        {

            foreach (ICSharpCode.NRefactory.Ast.INode namespaces in New.Children)
            {
                // 排除using
                if (namespaces is ICSharpCode.NRefactory.Ast.UsingDeclaration)
                    continue;
                if (namespaces is ICSharpCode.NRefactory.Ast.NamespaceDeclaration)
                {
                    string nameSpaceName = ((ICSharpCode.NRefactory.Ast.NamespaceDeclaration)(namespaces)).Name;
                    foreach (ICSharpCode.NRefactory.Ast.INode classs in namespaces.Children)
                    {
                        // 排除不是class
                        if (!(classs is ICSharpCode.NRefactory.Ast.TypeDeclaration))
                            continue;
                        string className = ((ICSharpCode.NRefactory.Ast.TypeDeclaration)(classs)).Name;

                        if (nameSpaceName == compareNameSpace && className == compareClassName)
                        {
                            classs.Children.Add(Node);
                        }
                    }
                }
            }
        }

        // 更具路劲生成CompilationUnit
        public static ICSharpCode.NRefactory.Ast.CompilationUnit GetCompilationUnit(string path)
        {
            try
            {
                using (TextReader tr = new StreamReader(path, System.Text.Encoding.Default))
                {
                    IParser parser = ParserFactory.CreateParser(SupportedLanguage.CSharp, tr);
                    parser.Parse();
                    tr.Close();
                    return parser.CompilationUnit;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // 原始文件
        public static ICSharpCode.NRefactory.Ast.CompilationUnit GetMemberOrField(ICSharpCode.NRefactory.Ast.CompilationUnit New, ICSharpCode.NRefactory.Ast.CompilationUnit CompilationUnit, IParser parser, out string appendString)
        {
            StringBuilder sb = new StringBuilder();

            //List<NamespaceMembers> list = new List<NamespaceMembers>();
            foreach (ICSharpCode.NRefactory.Ast.INode namespaces in CompilationUnit.Children)
            {
                // 排除using
                if (namespaces is ICSharpCode.NRefactory.Ast.UsingDeclaration)
                    continue;
                if (namespaces is ICSharpCode.NRefactory.Ast.NamespaceDeclaration)
                {
                    string nameSpaceName = ((ICSharpCode.NRefactory.Ast.NamespaceDeclaration)(namespaces)).Name;
                    foreach (ICSharpCode.NRefactory.Ast.INode classs in namespaces.Children)
                    {
                        // 排除不是class
                        if (!(classs is ICSharpCode.NRefactory.Ast.TypeDeclaration))
                            continue;

                        string className = ((ICSharpCode.NRefactory.Ast.TypeDeclaration)(classs)).Name;
                        // 字段和方法
                        int classLastLine = 0;
                        foreach (ICSharpCode.NRefactory.Ast.INode members in classs.Children)
                        {

                            bool ismember = members is ICSharpCode.NRefactory.Ast.MethodDeclaration;
                            bool isfields = members is ICSharpCode.NRefactory.Ast.FieldDeclaration;
                            bool isprotory = members is ICSharpCode.NRefactory.Ast.PropertyDeclaration;
                            bool isconstract = members is ICSharpCode.NRefactory.Ast.ConstructorDeclaration;

                            if (ismember || isfields || isprotory || isconstract)
                            {
                                if (!IsExists(New, nameSpaceName, className, members))
                                {
                                    int MyLast = 0;
                                    if (ismember)
                                        MyLast = ((ICSharpCode.NRefactory.Ast.AbstractNode)(((ICSharpCode.NRefactory.Ast.MethodDeclaration)(members)).Body)).EndLocation.Y;
                                    if (isfields)
                                        MyLast = members.EndLocation.Y;
                                    if (isprotory)
                                        MyLast = ((ICSharpCode.NRefactory.Ast.PropertyDeclaration)(members)).BodyEnd.Y;
                                    if (isconstract)
                                        MyLast = ((ICSharpCode.NRefactory.Ast.AbstractNode)(((ICSharpCode.NRefactory.Ast.ConstructorDeclaration)(members)).Body)).EndLocation.Y;
                                    AppendNode(New, members, nameSpaceName, className, MyLast, CompilationUnit, parser);
                                    sb.AppendLine(GetComment(parser, classLastLine, MyLast, members));
                                }
                            }
                            if (ismember)
                                classLastLine = ((ICSharpCode.NRefactory.Ast.AbstractNode)(((ICSharpCode.NRefactory.Ast.MethodDeclaration)(members)).Body)).EndLocation.Y;
                            if (isfields)
                                classLastLine = members.EndLocation.Y;
                            if (isprotory)
                                classLastLine = ((ICSharpCode.NRefactory.Ast.PropertyDeclaration)(members)).BodyEnd.Y;
                            if (isconstract)
                                classLastLine = ((ICSharpCode.NRefactory.Ast.AbstractNode)(((ICSharpCode.NRefactory.Ast.ConstructorDeclaration)(members)).Body)).EndLocation.Y;
                        }
                    }
                }
            }
            appendString = sb.ToString();
            return New;
        }

        // 获取两个class 比较差距的文本
        public static string CompareCompilationUnit(string oldPath, string newPath)
        {
            IParser iparse = GetIParse(oldPath);

            ICSharpCode.NRefactory.Ast.CompilationUnit old = GetCompilationUnit(oldPath);
            ICSharpCode.NRefactory.Ast.CompilationUnit New = GetCompilationUnit(newPath);
            string outstr = string.Empty;
            ICSharpCode.NRefactory.Ast.CompilationUnit result = GetMemberOrField(New, old, iparse, out outstr);
            string context = IoHelper.FileReader(newPath);
            // find index
            int line = CompileUnitParser.GetClassLastLine(newPath);

            int start = 0;
            for (int i = 1; i <= line - 1; i++)
            {
                int index = context.IndexOf("\n", start);
                if (index >= 0)
                    start = index + 1;
            }
            context = context.Insert(start, outstr);
            return context;
        }

        public static void AppendCode(string path,string appcode)
        {
            string context = IoHelper.FileReader(path);
            int line = CompileUnitParser.GetClassLastLine(path);

            int start = 0;
            for (int i = 1; i <= line - 1; i++)
            {
                int index = context.IndexOf("\n", start);
                if (index >= 0)
                    start = index + 1;
            }
            context = context.Insert(start, appcode);
            IoHelper.FileOverWrite(path, context);
        }

        // 获取IParse
        public static IParser GetIParse(string path)
        {
            using (TextReader tr = new StreamReader(path, System.Text.Encoding.Default))
            {
                IParser pares = ParserFactory.CreateParser(SupportedLanguage.CSharp, tr);
                pares.Parse();
                return pares;
            }
        }

        // 根据NODE生成代码
        public static string GetCodeCompileUnit(string filepath, ICSharpCode.NRefactory.Ast.CompilationUnit New)
        {
            try
            {

                using (TextReader tr = new StreamReader(filepath, System.Text.Encoding.Default))
                {
                    IParser pares = ParserFactory.CreateParser(SupportedLanguage.CSharp, tr);
                    pares.Parse();
                    List<ISpecial> list = pares.Lexer.SpecialTracker.CurrentSpecials;

                    ICSharpCode.NRefactory.PrettyPrinter.CSharpOutputVisitor outVisitor = new ICSharpCode.NRefactory.PrettyPrinter.CSharpOutputVisitor();
                    List<ISpecial> specials = pares.Lexer.SpecialTracker.CurrentSpecials;
                    SpecialNodesInserter sni = new SpecialNodesInserter(specials, new SpecialOutputVisitor(outVisitor.OutputFormatter));
                    outVisitor.BeforeNodeVisit += sni.AcceptNodeStart;
                    outVisitor.AfterNodeVisit += sni.AcceptNodeEnd;
                    outVisitor.VisitCompilationUnit(New, null);
                    tr.Close();

                    return outVisitor.Text;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // 获取注释
        public static string GetComment(IParser parser, int startIndex, int endIndex, ICSharpCode.NRefactory.Ast.INode Node)
        {
            List<ISpecial> list = parser.Lexer.SpecialTracker.CurrentSpecials;
            List<ISpecial> specials = parser.Lexer.SpecialTracker.CurrentSpecials;
            // 过滤comment 
            specials = (List<ISpecial>)specials.Where(x => x.StartPosition.Line > startIndex
                                && x.GetType().Name == "Comment"
                                && x.StartPosition.Line < endIndex).ToList();

            ICSharpCode.NRefactory.PrettyPrinter.CSharpOutputVisitor outVisitor = new ICSharpCode.NRefactory.PrettyPrinter.CSharpOutputVisitor();
            SpecialNodesInserter sni = new SpecialNodesInserter(specials, new SpecialOutputVisitor(outVisitor.OutputFormatter));
            outVisitor.BeforeNodeVisit += sni.AcceptNodeStart;
            outVisitor.AfterNodeVisit += sni.AcceptNodeEnd;
            // 判断是属性还是方法
            bool ismember = Node is ICSharpCode.NRefactory.Ast.MethodDeclaration;
            bool isfields = Node is ICSharpCode.NRefactory.Ast.FieldDeclaration;
            bool isprotory = Node is ICSharpCode.NRefactory.Ast.PropertyDeclaration;
            if (ismember)
                outVisitor.VisitMethodDeclaration(((ICSharpCode.NRefactory.Ast.MethodDeclaration)(Node)), null);
            if (isfields)
                outVisitor.VisitFieldDeclaration(((ICSharpCode.NRefactory.Ast.FieldDeclaration)(Node)), null);
            if (isprotory)
                outVisitor.VisitPropertyDeclaration(((ICSharpCode.NRefactory.Ast.PropertyDeclaration)(Node)), null);
            return outVisitor.Text;
        }

        // 获取最有一行
        public static int GetClassLastLine(string path)
        {
            int classLastLine = 0;
            ICSharpCode.NRefactory.Ast.CompilationUnit CompilationUnit = GetCompilationUnit(path);
            foreach (ICSharpCode.NRefactory.Ast.INode namespaces in CompilationUnit.Children)
            {
                // 排除using
                if (namespaces is ICSharpCode.NRefactory.Ast.UsingDeclaration)
                    continue;
                if (namespaces is ICSharpCode.NRefactory.Ast.NamespaceDeclaration)
                {
                    string nameSpaceName = ((ICSharpCode.NRefactory.Ast.NamespaceDeclaration)(namespaces)).Name;
                    classLastLine = namespaces.Children[namespaces.Children.Count - 1].EndLocation.Line;

                }
            }
            return classLastLine;
        }





        public static string MergeFile(string oldFilePath, string newPath, string content)
        {
            IoHelper.CreateFile(newPath, content);
            content = CompileUnitParser.CompareCompilationUnit(newPath, oldFilePath);
            return content;
        }
    }
}
