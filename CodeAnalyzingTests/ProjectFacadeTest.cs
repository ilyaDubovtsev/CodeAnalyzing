using System.Linq;
using CodeAnalyzing;
using FluentAssertions;
using NUnit.Framework;

namespace CodeAnalyzingTests
{
    [TestFixture]
    public class ProjectFacadeTest
    {
        [Test]
        public void GetDocumentsTest()
        {
            var solutionFacade = new SolutionFacade(@"C:\dev\diploma\CodeAnalyzing\Tests\TestSolutionFramework.sln");
            var projects = solutionFacade.GetProjects();

            projects.Length.Should().Be(1);
            var project = projects.First();
            project.Name.Should().BeEquivalentTo("TestFrameworkProject");
        }

        [Test]
        public void GetDocumentsWithFilterTest()
        {
            var solutionFacade = new SolutionFacade(@"C:\dev\diploma\CodeAnalyzing\Tests\TestSolutionFramework.sln");
            var projects = solutionFacade.GetProjects(x => x.Name != "TestFrameworkProject");

            projects.Length.Should().Be(0);
        }
    }
}