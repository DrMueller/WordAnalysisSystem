using System.Collections.Generic;
using System.Threading.Tasks;
using Mmu.Was.Domain.Areas.Rulings;
using Mmu.Was.Domain.Areas.Word;

namespace Mmu.Was.DomainServices.Areas.Services.RuleChecks.Servants
{
    public interface ICaptionsExistRuleCheckServant
    {
        Task<RuleCheckResult> CheckElementsAsync(string ruleName, IReadOnlyCollection<IElementWithCaption> elementsWithCaption);
    }
}