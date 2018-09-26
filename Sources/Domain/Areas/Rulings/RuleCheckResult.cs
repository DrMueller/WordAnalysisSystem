namespace Mmu.Was.Domain.Areas.Rulings
{
    public class RuleCheckResult
    {
        public RuleCheckResultDetails Details { get; }
        public string ResultOverview { get; }
        public bool RuleCheckPassed { get; }
        public string RuleName { get; }

        public RuleCheckResult(bool ruleCheckPassed, string ruleName, string resultOverview, RuleCheckResultDetails details)
        {
            RuleCheckPassed = ruleCheckPassed;
            RuleName = ruleName;
            ResultOverview = resultOverview;
            Details = details;
        }

        public static RuleCheckResult CreatePassed(string ruleName)
        {
            return new RuleCheckResult(true, ruleName, string.Empty, RuleCheckResultDetails.CreateEmpty());
        }
    }
}