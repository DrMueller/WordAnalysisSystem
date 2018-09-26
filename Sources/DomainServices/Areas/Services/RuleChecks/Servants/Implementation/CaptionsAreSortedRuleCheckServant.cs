using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mmu.Mlh.WordAccess.Areas.Models;
using Mmu.Was.Domain.Areas.Rulings;

namespace Mmu.Was.DomainServices.Areas.Services.RuleChecks.Servants.Implementation
{
    public class CaptionsAreSortedRuleCheckServant : ICaptionsAreSortedRuleCheckServant
    {
        public async Task<RuleCheckResult> CheckElementsAsync(string ruleName, string captionPrefix, IReadOnlyCollection<IElementWithCaption> elementsWithCaption)
        {
            return await Task.Run(
                () =>
                {
                    var details = new List<string>();

                    for (var i = 1; i <= elementsWithCaption.Count; i++)
                    {
                        var expectedPrefix = $"{captionPrefix} {i}: ";
                        var actualText = elementsWithCaption.ElementAt(i - 1).CaptionText;

                        if (!actualText.StartsWith(expectedPrefix, StringComparison.Ordinal))
                        {
                            details.Add($"Expected {actualText} to start with {expectedPrefix}");
                        }
                    }

                    if (details.Any())
                    {
                        return new RuleCheckResult(false, ruleName, $"Found {details.Count} wrong element sortings", new RuleCheckResultDetails(details));
                    }

                    return RuleCheckResult.CreatePassed(ruleName);
                });
        }
    }
}