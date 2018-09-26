using System.Threading.Tasks;
using Mmu.Mlh.WordAccess.Areas.Models;
using Mmu.Was.Domain.Areas.Rulings;
using Mmu.Was.DomainServices.Areas.Services.RuleChecks.Servants;

namespace Mmu.Was.DomainServices.Areas.Services.RuleChecks.Implementation
{
    public class ShapeCaptionsExistRuleCheck : IRuleCheck
    {
        public const string RuleName = "Shapes have captions";
        private readonly ICaptionsExistRuleCheckServant _servant;

        public ShapeCaptionsExistRuleCheck(ICaptionsExistRuleCheckServant servant)
        {
            _servant = servant;
        }

        public Task<RuleCheckResult> CheckRuleAsync(WordDocument wordDocument)
        {
            return _servant.CheckElementsAsync(RuleName, wordDocument.Shapes);
        }
    }
}