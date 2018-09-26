using System.Collections.Generic;
using System.Threading.Tasks;
using Mmu.Mlh.WordAccess.Areas.Models;
using Mmu.Was.Domain.Areas.Rulings;

namespace Mmu.Was.DomainServices.Areas.Services.RuleChecks.Servants
{
    public interface ICaptionsExistRuleCheckServant
    {
        Task<RuleCheckResult> CheckElementsAsync(string ruleName, IReadOnlyCollection<IElementWithCaption> elementsWithCaption);
    }
}