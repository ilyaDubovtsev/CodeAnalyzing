using System.Linq;
using CodeAnalyzing;

namespace MetricsCalculating
{
    public class MetricsCalculator
    {
        private readonly CodeAnalyzer _codeAnalyzer;

        public MetricsCalculator(string solutionPath)
        {
            _codeAnalyzer = new CodeAnalyzer(solutionPath);
        }

        public int GetMedianMethodNameLength()
        {
            return _codeAnalyzer.GetMethodNames().Select(x => x.Length).GetMedian();
        }

        public int GetMedianVariableNameLength()
        {
            return _codeAnalyzer.GetVariableNames().Select(x => x.Length).GetMedian();
        }

        public int GetMedianMethodLinesCount()
        {
            return _codeAnalyzer.GetMethodTexts().Select(x => x.Split('\n').Length).GetMedian();
        }

        public int GetMedianMethodLinesLength()
        {
            return _codeAnalyzer.GetMethodTexts().SelectMany(x => x.Split('\n')).Select(x => x.Length).GetMedian();
        }

        public int GetMedianMethodLength()
        {
            return _codeAnalyzer.GetMethodTexts().Select(x => x.Length).GetMedian();
        }

        public int GetMedianMethodsCountInDocuments()
        {
            return _codeAnalyzer.GetMethodsCountByDocuments().GetMedian();
        }

        public int GetMedianVariablesCountInMethods()
        {
            return _codeAnalyzer.GetVariablesCountInMethods().GetMedian();
        }

        public int GetMedianMethodDepth()
        {
            return _codeAnalyzer.GetMethodDepths().GetMedian();
        }

        public int GetMedianDocumentDepth()
        {
            return _codeAnalyzer.GetDocumentDepths().GetMedian();
        }
    }
}
