using System.Collections.Generic;
using System.Threading.Tasks;
using Mmu.Was.Domain.Areas.Rulings;
using Mmu.Was.Domain.Areas.Word;

namespace Mmu.Was.DomainServices.Areas.Services.RuleChecks.Servants
{
    public interface ICaptionsAreSortedRuleCheckServant
    {
        Task<RuleCheckResult> CheckElementsAsync(string ruleName, string captionPrefix, IReadOnlyCollection<IElementWithCaption> elementsWithCaption);
    }
}