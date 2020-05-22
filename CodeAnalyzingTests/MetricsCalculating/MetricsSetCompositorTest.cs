using FluentAssertions;
using MetricsCalculating;
using NUnit.Framework;

namespace CodeAnalyzingTests.MetricsCalculating
{
    [TestFixture]
    public class MetricsSetCompositorTest
    {
        [Test]
        public void GetMetricSetTest()
        {
            var metricSet = MetricSetCompositor.GetMetricSet(@"C:\dev\diploma\CodeAnalyzing\Tests\TestSolutionFramework.sln");
            metricSet.Count.Should().Be(9);
        }
    }
}