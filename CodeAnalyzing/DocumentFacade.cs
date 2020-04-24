using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;

namespace CodeAnalyzing
{
    public class DocumentFacade
    {
        private readonly Document _document;
        private SyntaxNode _root;


        public DocumentFacade(Document document)
        {
            _document = document;
            var syntaxTree = document.GetSyntaxTreeAsync().ConfigureAwait(false).GetAwaiter().GetResult();
            _root = syntaxTree.GetRoot();
        }

        public string[] GetMethodNames()
        {
            return GetTokens(_root, SyntaxKind.IdentifierToken, SyntaxKind.MethodDeclaration).Select(x => x.ValueText).ToArray();
        }

        public string[] GetVariableNames()
        {
            return GetTokens(_root, SyntaxKind.IdentifierToken, SyntaxKind.VariableDeclarator).Select(x => x.ValueText).ToArray();
        }

        public string[] GetTokenNamesWithKind()
        {
            return GetTokenNamesWithKind(_root).ToArray();
        }

        public string[] GetMethodText()
        {
            return GetNodes(_root, SyntaxKind.MethodDeclaration).Select(x => x.GetText().ToString()).ToArray();
        }

        public int GetDepth()
        {
            return GetDepth(_root, 0);
        }

        private int GetDepth(SyntaxNode node, int depth)
        {
            var maxDepth = depth;
            foreach (var childNode in node.ChildNodes())
            {
                var childNodeDepth = GetDepth(childNode, depth + 1);
                Console.WriteLine($"{new string('-', depth)} {childNode.Kind()}");
                if (maxDepth < childNodeDepth)
                {
                    maxDepth = childNodeDepth;
                }
            }

            return maxDepth;
        }

        private List<SyntaxNode> GetNodes(SyntaxNode node, SyntaxKind syntaxKind)
        {
            var methodNodes = new List<SyntaxNode>();

            foreach (var childNode in node.ChildNodes())
            {
                if (childNode.IsKind(syntaxKind))
                {
                    methodNodes.Add(childNode);
                }

                methodNodes.AddRange(GetNodes(childNode, syntaxKind)); 
            }

            return methodNodes;
        }

        private List<SyntaxToken> GetTokens(SyntaxNode node, SyntaxKind syntaxKind, SyntaxKind parentSyntaxKind)
        {
            var names = new List<SyntaxToken>();
            foreach (var token in node.ChildTokens())
            {
                if (token.IsKind(syntaxKind) && node.IsKind(parentSyntaxKind))
                {
                    names.Add(token);
                }
            }

            foreach (var childNode in node.ChildNodes())
            {
                names.AddRange(GetTokens(childNode, syntaxKind, parentSyntaxKind));
            }

            return names;
        }


        private List<string> GetTokenNamesWithKind(SyntaxNode node)
        {
            var names = new List<string>();
            names.Add($"NODE {node.Kind()}");
            foreach (var token in node.ChildTokens())
            {
                names.Add($"{token.ValueText} {token.Kind()}");
            }

            foreach (var childNode in node.ChildNodes())
            {
                names.AddRange(GetTokenNamesWithKind(childNode));
            }

            return names;
        }
    }
}