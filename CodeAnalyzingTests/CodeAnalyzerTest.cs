using CodeAnalyzing;
using FluentAssertions;
using NUnit.Framework;

namespace CodeAnalyzingTests
{
    [TestFixture]
    public class CodeAnalyzerTest
    {
        private CodeAnalyzer _codeAnalyzer;

        [SetUp]
        public void SetUp()
        {
            _codeAnalyzer = new CodeAnalyzer(@"C:\dev\diploma\CodeAnalyzing\Tests\TestSolutionFramework.sln");
        }

        [Test]
        public void GetMethodNamesTest()
        {
            var methodNames = _codeAnalyzer.GetMethodNames();
            methodNames.Length.Should().Be(9);
            methodNames.Should().Contain("Method1");
            methodNames.Should().Contain("Method2");
            methodNames.Should().Contain("Method3");
            methodNames.Should().Contain("Method4");
            methodNames.Should().Contain("Method12");
            methodNames.Should().Contain("Method22");
            methodNames.Should().Contain("Method32");
            methodNames.Should().Contain("Method42");
            methodNames.Should().Contain("TestMethod");
        }

        [Test]
        public void GetVariableNamesTest()
        {
            var variableNames = _codeAnalyzer.GetVariableNames();
            variableNames.Length.Should().Be(4);
            variableNames.Should().Contain("a");
            variableNames.Should().Contain("b");
            variableNames.Should().Contain("a2");
            variableNames.Should().Contain("b2");
        }

        [Test]
        public void GetMethodBodiesTest()
        {
            var methodBodies = _codeAnalyzer.GetMethodTexts();

            methodBodies.Length.Should().Be(9);
            methodBodies[0].Should().Contain("TestMethod");
            methodBodies[1].Should().Contain("Method1");
            methodBodies[2].Should().Contain("Method2");
            methodBodies[3].Should().Contain("Method3");
            methodBodies[4].Should().Contain("Method4");
            methodBodies[5].Should().Contain("Method12");
            methodBodies[6].Should().Contain("Method22");
            methodBodies[7].Should().Contain("Method32");
            methodBodies[8].Should().Contain("Method42");
        }

        [Test]
        public void GetDepthTest()
        {
            var depths = _codeAnalyzer.GetDocumentDepths();
            depths.Length.Should().Be(3);
        }

        [Test]
        public void GetMethodDepthsTest()
        {
            var depths = _codeAnalyzer.GetMethodDepths();
            depths.Length.Should().Be(9);
        }
    }
}