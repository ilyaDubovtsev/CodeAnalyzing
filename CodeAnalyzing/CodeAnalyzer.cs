using System;
using System.Linq;

namespace CodeAnalyzing
{
    public class CodeAnalyzer
    {
        private DocumentFacade[] _documents;

        public CodeAnalyzer(string solutionPath)
        {
            var solutionFacade = new SolutionFacade(solutionPath);

            var projectFacades = solutionFacade
                .GetProjects()
                .Select(p => new ProjectFacade(p))
                .ToArray();

            _documents = projectFacades
                .SelectMany(p => p.GetDocuments())
                .Where(d => !d.FilePath.Contains("Properties"))
                .Where(d => !d.FilePath.Contains(".NET"))
                .Select(d => new DocumentFacade(d))
                .ToArray();
        }

        public string[] GetMethodNames()
        {
            return _documents.SelectMany(d => d.GetMethodNames()).ToArray();
        }

        public string[] GetVariableNames()
        {
            return _documents.SelectMany(d => d.GetVariableNames()).ToArray();
        }

        public string[] GetMethodTexts()
        {
            return _documents.SelectMany(d => d.GetMethodTexts()).ToArray();
        }

        public int[] GetDocumentDepths()
        {
            return _documents.Select(d => d.GetDepth()).ToArray();
        }

        public int[] GetMethodDepths()
        {
            return _documents.SelectMany(d => d.GetMethodDepths()).ToArray();
        }
    }
}