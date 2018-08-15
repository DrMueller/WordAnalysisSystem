using System.Threading.Tasks;
using Mmu.Was.Domain.Areas.Rulings;
using Mmu.Was.Domain.Areas.Word;
using Mmu.Was.DomainServices.Areas.Services.RuleChecks.Servants;

namespace Mmu.Was.DomainServices.Areas.Services.RuleChecks.Implementation
{
    public class ShapeCaptionsAreSortedRuleCheck : IRuleCheck
    {
        public const string RuleName = "Shape captions are sorted";

        private ICaptionsAreSortedRuleCheckServant _servant;

        public ShapeCaptionsAreSortedRuleCheck(ICaptionsAreSortedRuleCheckServant servant) => _servant = servant;

        public Task<RuleCheckResult> CheckRuleAsync(WordDocument wordDocument) => _servant.CheckElementsAsync(RuleName, "Abbildung", wordDocument.Shapes);
    }
}