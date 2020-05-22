using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace CodeAnalyzingTests.Demo
{
    [TestFixture]
    public class Demo
    {
        [Test]
        [TestCase(@"C:\dev\diploma\CodeAnalyzing\Tests\TestSolutionFramework.sln",
            @"C:\dev\diploma\CodeAnalyzing\Tests\TestSolutionFramework.sln",
            @"C:\dev\diploma\CodeAnalyzing\Tests\TestSolution.sln",
            @"C:\dev\diploma\CodeAnalyzing\Tests\TestSolutionCore.sln",
            @"C:\dev\diploma\CodeAnalyzing\Tests\TestSolutionStandard.sln")]
        public void DemoMethod(params string[] solutionPaths)
        {
            Console.Write("Введите количество солюшенов: ");
            var n = solutionPaths.Length;
            Console.WriteLine("Введите абсолютные пути солюшенов:");
            foreach (var solutionPath in solutionPaths)
            {
                Console.WriteLine(solutionPath);
            }

            var modelProcessor = new ModelProcessing.ModelProcessor(solutionPaths.ToArray());

            foreach (var metrics in modelProcessor.GetMetricsAsStrings())
            {
                Console.WriteLine(metrics);
                Console.WriteLine(new string('-', 16));
            }

            Console.WriteLine(modelProcessor.GetDistances());
        }
    }
}