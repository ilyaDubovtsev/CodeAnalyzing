using CodeAnalyzing;
using FluentAssertions;
using NUnit.Framework;

namespace CodeAnalyzingTests.CodeAnalyzing
{
    [TestFixture]
    public class SolutionFacadeTest
    {
        [Test]
        [TestCase(@"C:\dev\diploma\CodeAnalyzing\Tests\TestSolutionCore.sln", TestName = "Core")]
        [TestCase(@"C:\dev\diploma\CodeAnalyzing\Tests\TestSolutionFramework.sln", TestName = "Framework")]
        [TestCase(@"C:\dev\diploma\CodeAnalyzing\Tests\TestSolutionStandard.sln", TestName = "Standard")]
        public void TestGetProjects(string solutionPath)
        {
            var solutionFacade = new SolutionFacade(solutionPath);

            var projects = solutionFacade.GetProjects();

            projects.Should().NotBeNullOrEmpty();
        }
    }
}