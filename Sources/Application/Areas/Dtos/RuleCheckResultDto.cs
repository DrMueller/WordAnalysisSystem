using System.Collections.Generic;

namespace Mmu.Was.Application.Areas.Dtos
{
    public class RuleCheckResultDto
    {
        public IReadOnlyCollection<string> Details { get; set; }
        public string ResultOverview { get; set; }
        public bool RuleCheckPassed { get; set; }
        public string RuleName { get; set; }
    }
}