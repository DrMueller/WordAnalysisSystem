using System.Threading.Tasks;
using Mmu.Was.Domain.Areas.Rulings;
using Mmu.Was.Domain.Areas.Word;
using Mmu.Was.DomainServices.Areas.Services.RuleChecks.Servants;

namespace Mmu.Was.DomainServices.Areas.Services.RuleChecks.Implementation
{
    public class TableCaptionsAreSortedRuleCheck : IRuleCheck
    {
        public const string RuleName = "Table captions are sorted";

        private readonly ICaptionsAreSortedRuleCheckServant _servant;

        public TableCaptionsAreSortedRuleCheck(ICaptionsAreSortedRuleCheckServant servant) => _servant = servant;

        public Task<RuleCheckResult> CheckRuleAsync(WordDocument wordDocument) => _servant.CheckElementsAsync(RuleName, "Tabelle", wordDocument.Tables);
    }
}