using System.Threading.Tasks;
using Mmu.Was.Domain.Areas.Rulings;
using Mmu.Was.Domain.Areas.Word;
using Mmu.Was.DomainServices.Areas.Services.RuleChecks.Servants;

namespace Mmu.Was.DomainServices.Areas.Services.RuleChecks.Implementation
{
    public class TableCaptionsExistRuleCheck : IRuleCheck
    {
        public const string RuleName = "Tables have captions";

        private readonly ICaptionsExistRuleCheckServant _servant;

        public TableCaptionsExistRuleCheck(ICaptionsExistRuleCheckServant servant) => _servant = servant;

        public Task<RuleCheckResult> CheckRuleAsync(WordDocument wordDocument) => _servant.CheckElementsAsync(RuleName, wordDocument.Tables);
    }
}