using System.Linq;
using CodeAnalyzing;

namespace MetricsCalculating
{
    internal class MetricsCalculator
    {
        private readonly CodeAnalyzer _codeAnalyzer;

        public MetricsCalculator(string solutionPath)
        {
            _codeAnalyzer = new CodeAnalyzer(solutionPath);
        }

        public int MedianMethodNameLength()
        {
            return _codeAnalyzer.GetMethodNames().Select(x => x.Length).GetMedian();
        }

        public int MedianVariableNameLength()
        {
            return _codeAnalyzer.GetVariableNames().Select(x => x.Length).GetMedian();
        }

        public int MedianMethodLinesCount()
        {
            return _codeAnalyzer.GetMethodTexts().Select(x => x.Split('\n').Length).GetMedian();
        }

        public int MedianMethodLinesLength()
        {
            return _codeAnalyzer.GetMethodTexts().SelectMany(x => x.Split('\n')).Select(x => x.Length).GetMedian();
        }

        public int MedianMethodLength()
        {
            return _codeAnalyzer.GetMethodTexts().Select(x => x.Length).GetMedian();
        }

        public int MedianMethodsCountInDocuments()
        {
            return _codeAnalyzer.GetMethodsCountByDocuments().GetMedian();
        }

        public int MedianVariablesCountInMethods()
        {
            return _codeAnalyzer.GetVariablesCountInMethods().GetMedian();
        }

        public int MedianMethodDepth()
        {
            return _codeAnalyzer.GetMethodDepths().GetMedian();
        }

        public int MedianDocumentDepth()
        {
            return _codeAnalyzer.GetDocumentDepths().GetMedian();
        }
    }
}
