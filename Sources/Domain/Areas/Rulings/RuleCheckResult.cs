using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mmu.Was.Domain.Areas.Rulings
{
    public class RuleCheckResult
    {
        public RuleCheckResult(bool ruleCheckPassed, string ruleName, string resultOverview, RuleCheckResultDetails details)
        {
            RuleCheckPassed = ruleCheckPassed;
            RuleName = ruleName;
            ResultOverview = resultOverview;
            Details = details;
        }

        public static RuleCheckResult CreatePassed(string ruleName) => new RuleCheckResult(true, ruleName, string.Empty, RuleCheckResultDetails.CreateEmpty());

        public bool RuleCheckPassed { get; }
        public string RuleName { get; }
        public string ResultOverview { get; }
        public RuleCheckResultDetails Details { get; }
    }
}
