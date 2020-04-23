using System;
using System.Collections.Generic;
using Microsoft.Build.Locator;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.MSBuild;

namespace CodeAnalyzing
{
    public class SolutionFacade
    {
        private static bool MsBuildWasLoaded = false;
        private static readonly object locker = new object();
        private Solution solution;

        public SolutionFacade(string solutionPath)
        {
            solution = OpenSolution(solutionPath);
        }

        public IEnumerable<Project> GetProjects()
        {
            return solution.Projects;
        }

        private Solution OpenSolution(string solutionPath)
        {
            LoadMsBuildAssemblies();

            using (var msWorkspace = MSBuildWorkspace.Create())
            {
                msWorkspace.WorkspaceFailed += (sender, args) =>
                    throw new Exception(
                        $"Fail to load Workspace with {args.Diagnostic.Kind} and message {args.Diagnostic.Message}");

                var solution = msWorkspace.OpenSolutionAsync(solutionPath).ConfigureAwait(false).GetAwaiter()
                    .GetResult();

                return solution;
            }
        }

        private static void LoadMsBuildAssemblies()
        {
            var _ = typeof(Microsoft.CodeAnalysis.CSharp.Formatting.CSharpFormattingOptions);
            if (!MsBuildWasLoaded)
            {
                lock (locker)
                {
                    if (!MsBuildWasLoaded)
                    {
                        MSBuildLocator.RegisterDefaults();
                        MsBuildWasLoaded = true;
                    }
                }
            }
        }
    }
}