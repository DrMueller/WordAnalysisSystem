using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mmu.Was.Domain.Areas.Rulings;
using Mmu.Was.Domain.Areas.Word;

namespace Mmu.Was.DomainServices.Areas.Services.RuleChecks.Servants.Implementation
{
    public class CaptionsExistRuleCheckServant : ICaptionsExistRuleCheckServant
    {
        public async Task<RuleCheckResult> CheckElementsAsync(string ruleName, IReadOnlyCollection<IElementWithCaption> elementsWithCaption)
        {
            return await Task.Run(
                () =>
                {
                    var elementsWithoutCaption = elementsWithCaption.Where(f => string.IsNullOrEmpty(f.CaptionText)).ToList();

                    if (elementsWithoutCaption.Any())
                    {
                        return new RuleCheckResult(false, ruleName, $"{elementsWithoutCaption.Count} elements have no caption.", RuleCheckResultDetails.CreateEmpty());
                    }

                    return RuleCheckResult.CreatePassed(ruleName);
                });
        }
    }
}