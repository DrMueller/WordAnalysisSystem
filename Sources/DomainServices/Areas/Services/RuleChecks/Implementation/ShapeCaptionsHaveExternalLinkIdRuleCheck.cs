using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mmu.Mlh.WordAccess.Areas.Models;
using Mmu.Was.Domain.Areas.Rulings;

namespace Mmu.Was.DomainServices.Areas.Services.RuleChecks.Implementation
{
    public class ShapeCaptionsHaveExternalLinkIdRuleCheck : IRuleCheck
    {
        public const string RuleName = "Shapes have correct link ID";

        public async Task<RuleCheckResult> CheckRuleAsync(WordDocument wordDocument)
        {
            return await Task.Run(
                () =>
                {
                    var shapesWithExternalLink = wordDocument.Shapes.Where(f => f.CaptionText.Contains("[PIC")).ToList();

                    var details = new List<string>();

                    for (var i = 1; i <= shapesWithExternalLink.Count; i++)
                    {
                        var expectedPicLink = $"[PIC{i}]";
                        var currentItem = shapesWithExternalLink[i - 1];
                        if (!currentItem.CaptionText.EndsWith(expectedPicLink, StringComparison.Ordinal))
                        {
                            details.Add($"Expected {currentItem.CaptionText} to end with ${expectedPicLink}");
                        }
                    }

                    if (details.Any())
                    {
                        return new RuleCheckResult(false, RuleName, $"Found {details.Count} elements with invalid external link", new RuleCheckResultDetails(details));
                    }

                    return RuleCheckResult.CreatePassed(RuleName);
                });
        }
    }
}