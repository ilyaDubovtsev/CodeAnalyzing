using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Build.Locator;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.MSBuild;

namespace CodeAnalyzing
{
    public class SolutionFacade
    {
        private static bool _msBuildWasLoaded = false;
        private static readonly object Locker = new object();
        private readonly Solution _solution;

        public SolutionFacade(string solutionPath)
        {
            _solution = OpenSolution(solutionPath);
        }

        public Project[] GetProjects(Func<Project, bool> filter = null)
        {
            return _solution.Projects.Where(x => filter?.Invoke(x) ?? true).ToArray();
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
            if (!_msBuildWasLoaded)
            {
                lock (Locker)
                {
                    if (!_msBuildWasLoaded)
                    {
                        MSBuildLocator.RegisterDefaults();
                        _msBuildWasLoaded = true;
                    }
                }
            }
        }
    }
}