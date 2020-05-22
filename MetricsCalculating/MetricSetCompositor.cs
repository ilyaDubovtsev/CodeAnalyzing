using System.Collections.Generic;
using System.Linq;

namespace MetricsCalculating
{
    public static class MetricSetCompositor
    {
        public static Dictionary<string, int> GetMetricSet(string solutionPath)
        {
            var metricsCalculator = new MetricsCalculator(solutionPath);
            var metricSet = new Dictionary<string, int>();
            metricSet[nameof(metricsCalculator.MedianMethodNameLength)] = metricsCalculator.MedianMethodNameLength();
            metricSet[nameof(metricsCalculator.MedianVariableNameLength)] = metricsCalculator.MedianVariableNameLength();
            metricSet[nameof(metricsCalculator.MedianMethodLinesCount)] = metricsCalculator.MedianMethodLinesCount();
            metricSet[nameof(metricsCalculator.MedianMethodLinesLength)] = metricsCalculator.MedianMethodLinesLength();
            metricSet[nameof(metricsCalculator.MedianMethodLength)] = metricsCalculator.MedianMethodLength();
            metricSet[nameof(metricsCalculator.MedianMethodsCountInDocuments)] = metricsCalculator.MedianMethodsCountInDocuments();
            metricSet[nameof(metricsCalculator.MedianVariablesCountInMethods)] = metricsCalculator.MedianVariablesCountInMethods();
            metricSet[nameof(metricsCalculator.MedianMethodDepth)] = metricsCalculator.MedianMethodDepth();
            metricSet[nameof(metricsCalculator.MedianDocumentDepth)] = metricsCalculator.MedianDocumentDepth();
            return metricSet;
        }
    }
}