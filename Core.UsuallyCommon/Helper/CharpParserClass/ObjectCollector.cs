using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.UsuallyCommon
{
    public class ObjectCollector : CSharpSyntaxWalker
    {
        public ICollection<UsingDirectiveSyntax> Usings { get; } = new List<UsingDirectiveSyntax>();
        // </Snippet4>
        public ICollection<ClassDeclarationSyntax> Classs { get; } = new List<ClassDeclarationSyntax>();

        public List<Classs> classList = new List<Classs>();

        // <SNippet5>
        public override void VisitUsingDirective(UsingDirectiveSyntax node)
        {
            this.Usings.Add(node);
        }

        public override void VisitClassDeclaration(ClassDeclarationSyntax node)
        {
            var trivia = node.GetLeadingTrivia().FirstOrDefault(x => x.Kind() == SyntaxKind.SingleLineDocumentationCommentTrivia || x.Kind() == SyntaxKind.SingleLineCommentTrivia);
            var name = node.Identifier.Value.ToStringExtension();
            var comment = trivia.Token.LeadingTrivia.ToStringExtension();
            Classs.Add(node);

            var classs = new Classs() { Name = name, Comment = comment };
            foreach (var item in node.Members)
            {
                if (item.GetType() == typeof(PropertyDeclarationSyntax))
                {
                    var proterty = item as PropertyDeclarationSyntax;
                    var protertyComment = proterty.GetLeadingTrivia().FirstOrDefault(x => x.Kind() == SyntaxKind.SingleLineDocumentationCommentTrivia
                    || x.Kind() == SyntaxKind.SingleLineCommentTrivia).Token.LeadingTrivia.ToStringExtension();
                    var protertys = new Proterty() { ClassName = name, ProtertyType = proterty.Type.ToString(), Comment = protertyComment, Name = proterty.Identifier.ValueText };
                    classs.Protertys.Add(protertys);
                }
                if (item.GetType() == typeof(MethodDeclarationSyntax))
                {
                    var methods = item as MethodDeclarationSyntax;
                    var returnType = string.Empty;
                    if (methods.ReturnType.GetType() == typeof(IdentifierNameSyntax))
                    {
                        returnType = (methods.ReturnType as IdentifierNameSyntax).Identifier.ValueText;
                    }
                    if (methods.ReturnType.GetType() == typeof(PredefinedTypeSyntax))
                    {
                        returnType = (methods.ReturnType as PredefinedTypeSyntax).Keyword.ValueText;
                    }
                    var methodComment = methods.GetLeadingTrivia().FirstOrDefault(x => x.Kind() == SyntaxKind.SingleLineDocumentationCommentTrivia
                  || x.Kind() == SyntaxKind.SingleLineCommentTrivia).Token.LeadingTrivia.ToStringExtension();

                    Method methodClass = new Method()
                    {
                        ClassName = name,
                        Name = methods.Identifier.ValueText,
                        ReturnType = returnType,
                        Comment = methodComment
                    };

                    var paramsList = methods.ParameterList.Parameters;
                    foreach (var iparams in paramsList)
                    {
                        MethodArgument methodArgument = new MethodArgument()
                        {
                            Name = iparams.Identifier.ValueText,
                            ArgumentType = iparams.Type.ToStringExtension(),
                            ClassName = name,
                            MethodName = methods.Identifier.ValueText,
                        };
                        methodClass.MethodArguments.Add(methodArgument);

                    }

                    classs.Methods.Add(methodClass);
                }
            }

            classList.Add(classs);
        }
    }
}
