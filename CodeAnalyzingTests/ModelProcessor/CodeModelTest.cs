using System.Collections.Generic;
using FluentAssertions;
using ModelProcessing;
using NUnit.Framework;

namespace CodeAnalyzingTests.ModelProcessor
{
    [TestFixture]
    public class CodeModelTest
    {
        [Test]
        public void GetDistanceTest()
        {
            var codeModel1 = new CodeModel(new Dictionary<string, int>(){{"x", 0}, {"y", 0}}, "solution1");
            var codeModel2 = new CodeModel(new Dictionary<string, int>(){{"x", 0}, {"y", 2}}, "solution2");

            var distance = codeModel1.GetDistanceTo(codeModel2);

            distance.Should().Be(2);
        }
    }
}