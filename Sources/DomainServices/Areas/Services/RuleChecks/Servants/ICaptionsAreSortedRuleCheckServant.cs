using System.Collections.Generic;
using System.Threading.Tasks;
using Mmu.Mlh.WordAccess.Areas.Models;
using Mmu.Was.Domain.Areas.Rulings;

namespace Mmu.Was.DomainServices.Areas.Services.RuleChecks.Servants
{
    public interface ICaptionsAreSortedRuleCheckServant
    {
        Task<RuleCheckResult> CheckElementsAsync(string ruleName, string captionPrefix, IReadOnlyCollection<IElementWithCaption> elementsWithCaption);
    }
}