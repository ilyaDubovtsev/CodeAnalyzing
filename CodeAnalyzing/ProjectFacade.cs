using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.CodeAnalysis;

namespace CodeAnalyzing
{
    public class ProjectFacade
    {
        private readonly Project _project;

        public ProjectFacade(Project project)
        {
            _project = project;
        }

        public Document[] GetDocuments(Func<Document, bool> filter = null)
        {
            return _project.Documents.Where(x => filter?.Invoke(x) ?? true).ToArray();
        }
    }
}