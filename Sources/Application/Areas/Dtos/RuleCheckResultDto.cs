using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mmu.Was.Application.Areas.Dtos
{
    public class RuleCheckResultDto
    {
        public bool RuleCheckPassed { get; set; }
        public string RuleName { get; set; }
        public string ResultOverview { get; set; }
        public IReadOnlyCollection<string> Details { get; set; }
    }
}
