using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Mmu.Mlh.WordAccess.Areas.Models;
using Mmu.Was.Domain.Areas.Rulings;

namespace Mmu.Was.DomainServices.Areas.Services.RuleChecks.Implementation
{
    public class NoForbiddenWordsRuleCheck : IRuleCheck
    {
        private const string RuleName = "No forbidden words";

        public async Task<RuleCheckResult> CheckRuleAsync(WordDocument wordDocument)
        {
            return await Task.Run(
                () =>
                {
                    var forbiddenCounts = new List<Tuple<int, string>>();
                    var forbiddenWords = ForbiddenWords.CreateDefault();

                    foreach (var forbiddenWord in forbiddenWords.Words)
                    {
                        var foundForbiddenWords = wordDocument
                            .Words
                            .Where(word => word.Text.ToUpper(CultureInfo.InvariantCulture) == forbiddenWord.ToUpper(CultureInfo.InvariantCulture))
                            .ToList();

                        if (foundForbiddenWords.Any())
                        {
                            forbiddenCounts.Add(new Tuple<int, string>(foundForbiddenWords.Count, forbiddenWord));
                        }
                    }

                    if (forbiddenCounts.Any())
                    {
                        var overviewMessage = $"Found {forbiddenCounts.Count} forbidden Words.";
                        var sorted = forbiddenCounts
                            .OrderByDescending(w => w.Item1)
                            .Select(w => $"{w.Item1}: {w.Item2}")
                            .ToList();

                        return new RuleCheckResult(false, RuleName, overviewMessage, new RuleCheckResultDetails(sorted));
                    }

                    return RuleCheckResult.CreatePassed(RuleName);
                });
        }
    }
}