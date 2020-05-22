using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ModelProcessing
{
    public class ModelProcessor
    {
        private readonly CodeModel[] _codeModels;

        public ModelProcessor(params string[] solutionPaths)
        {
            _codeModels = solutionPaths.Select(CodeModelBuilder.Build).ToArray();
        }

        public string[] GetMetricsAsStrings()
        {
            var result = new List<string>();
            foreach (var codeModel in _codeModels)
            {
                var stringBuilder = new StringBuilder();
                stringBuilder.AppendLine($"Solution {codeModel.SolutionName}");

                foreach (var metricName in codeModel.MetricNames)
                {
                    stringBuilder.AppendLine($"{metricName, 30} {codeModel.GetMetric(metricName)}");
                }

                result.Add(stringBuilder.ToString());

            }

            return result.ToArray();
        }

        public string GetDistances()
        {
            var codeModelsLength = _codeModels.Length;
            var stringBuilder = new StringBuilder();

            for (int i = 0; i < codeModelsLength; i++)
            {
                for (int j = i + 1; j < codeModelsLength; j++)
                {
                    var codeModelA = _codeModels[i];
                    var codeModelB = _codeModels[j];
                    var distance = codeModelA.GetDistanceTo(codeModelB);
                    stringBuilder.AppendLine($"{codeModelA.SolutionName,30} {codeModelB.SolutionName,30} {distance,20}");

                }
            }

            return stringBuilder.ToString();
        }
    }
}