using System.Collections.Generic;
using System.Linq;

namespace MetricsCalculating
{
    public static class MetricSetCompositor
    {
        public static int[] GetMetricSet(string solutionPath)
        {
            var metricsCalculator = new MetricsCalculator(solutionPath);
            return new[]
            {
                metricsCalculator.GetMedianMethodNameLength(),
                metricsCalculator.GetMedianVariableNameLength(),
                metricsCalculator.GetMedianMethodLinesCount(),
                metricsCalculator.GetMedianMethodLinesLength(),
                metricsCalculator.GetMedianMethodLength(),
                metricsCalculator.GetMedianMethodsCountInDocuments(),
                metricsCalculator.GetMedianVariablesCountInMethods(),
                metricsCalculator.GetMedianMethodDepth(),
                metricsCalculator.GetMedianDocumentDepth()
            };
        }
    }
}