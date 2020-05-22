using System.Linq;
using MetricsCalculating;
using ModelProcessing;

namespace ModelProcessing
{
    public static class CodeModelBuilder
    {
        public static CodeModel Build(string solutionPath)
        {
            var metricSet = MetricSetCompositor.GetMetricSet(solutionPath);
            var solutionName = solutionPath.Split('\\', '/').Last();
            return new CodeModel(metricSet, solutionName);
        }
    }
}