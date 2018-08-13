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

        public RuleCheckResultDetails Details { get; }
        public string ResultOverview { get; }
        public bool RuleCheckPassed { get; }
        public string RuleName { get; }

        public static RuleCheckResult CreatePassed(string ruleName) => new RuleCheckResult(true, ruleName, string.Empty, RuleCheckResultDetails.CreateEmpty());
    }
}