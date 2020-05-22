using System;
using System.Collections.Generic;
using System.Linq;

namespace ModelProcessor
{
    public class CodeModel
    {
        private readonly Dictionary<string, int> _metrics;

        public CodeModel(Dictionary<string, int> metrics, string solutionName)
        {
            SolutionName = solutionName;
            _metrics = metrics;
        }

        public string SolutionName { get; }

        public string[] MetricNames => _metrics.Keys.ToArray();

        public int GetMetric(string metricName)
        {
            if (_metrics.ContainsKey(metricName)) return _metrics[metricName];

            throw new Exception($"Метрики с именем {metricName} нет у модели.");
        }

        public double GetDistanceTo(CodeModel codeModel)
        {
            if (!HasEquivalentMetricsWith(codeModel)) throw new Exception("Разные метрики моделей исходного кода.");

            return Math.Sqrt(MetricNames.Sum(name => Math.Pow(GetMetric(name) - codeModel.GetMetric(name), 2)));
        }

        private bool HasEquivalentMetricsWith(CodeModel codeModel)
        {
            var anotherMetricNames = codeModel.MetricNames;
            var thisMetricNames = MetricNames;
            if (anotherMetricNames.Length != thisMetricNames.Length) return false;

            foreach (var metricName in thisMetricNames)
                if (!anotherMetricNames.Contains(metricName))
                    return false;

            return true;
        }
    }
}