using System.Linq;
using CodeAnalyzing;
using FluentAssertions;
using NUnit.Framework;

namespace CodeAnalyzingTests.CodeAnalyzing
{
    [TestFixture]
    public class DocumentFacadeTest
    {
        private DocumentFacade _documentFacade;

        [SetUp]
        public void SetUp()
        {
            var solutionFacade = new SolutionFacade(@"C:\dev\diploma\CodeAnalyzing\Tests\TestSolutionFramework.sln");
            var project = solutionFacade.GetProjects(x => x.Name == "TestFrameworkProject").First();
            var projectFacade = new ProjectFacade(project);
            var document = projectFacade.GetDocuments(x => x.Name == "TestClassForNamesGetting.cs").First();
            _documentFacade = new DocumentFacade(document);
        }

        [Test]
        public void GetMethodNamesTest()
        {

            var methodNames = _documentFacade.GetMethodNames();
            methodNames.Length.Should().Be(4);
            methodNames.Should().Contain("Method1");
            methodNames.Should().Contain("Method2");
            methodNames.Should().Contain("Method3");
            methodNames.Should().Contain("Method4");
        }

        [Test]
        public void GetVariableNamesTest()
        {
            var variableNames = _documentFacade.GetVariableNames();
            variableNames.Length.Should().Be(2);
            variableNames.Should().Contain("a");
            variableNames.Should().Contain("b");
        }

        [Test]
        public void GetMethodBodiesTest()
        {
            var methodBodies = _documentFacade.GetMethodTexts();
            methodBodies.Should().NotBeNullOrEmpty();
        }

        [Test]
        public void GetDepthTest()
        {
            var depth = _documentFacade.GetDepth();
            depth.Should().Be(9);
        }

        [Test]
        public void GetMethodDepthsTest()
        {
            var depths = _documentFacade.GetMethodDepths();
            depths.Should().BeEquivalentTo(new []{6, 3, 6, 3});
        }

        [Test]
        public void GetMethodsCountTest()
        {
            var methodsCount = _documentFacade.GetMethodsCount();
            methodsCount.Should().Be(4);
        }

        [Test]
        public void GetVariablesCountInMethodsTest()
        {
            var methodsCount = _documentFacade.GetVariablesCountInMethods();
            methodsCount.Should().BeEquivalentTo(new []{1, 0, 1, 0});
        }
    }
}


