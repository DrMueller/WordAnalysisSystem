using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Mmu.Was.Domain.Areas.Rulings;
using Mmu.Was.Domain.Areas.Word;

namespace Mmu.Was.DomainServices.Areas.Services.RuleChecks.Implementation
{
    public class ForbiddenWordsRuleCheckService : IForbiddenWordsRuleCheckService
    {
        private const string RuleName = "Forbidden Words";

        public RuleCheckResult CheckForbiddenWords(WordDocument wordDocument, ForbiddenWords forbiddenWords)
        {
            var foundForbiddenWordsReport = new List<string>();

            foreach (var forbiddenWord in forbiddenWords.Words)
            {
                var foundForbiddenWords = wordDocument
                    .Words
                    .Where(word => word.Text.ToUpper(CultureInfo.InvariantCulture) == forbiddenWord.ToUpper(CultureInfo.InvariantCulture))
                    .ToList();

                if (foundForbiddenWords.Any())
                {
                    foundForbiddenWordsReport.Add($"{foundForbiddenWords.Count}: {forbiddenWord}.");
                }
            }

            if (foundForbiddenWordsReport.Any())
            {
                var overviewMessage = $"Found {foundForbiddenWordsReport.Count} forbidden Words.";
                var sorted = foundForbiddenWordsReport.OrderBy(word => word).ToList();

                return new RuleCheckResult(false, RuleName, overviewMessage, new RuleCheckResultDetails(sorted));
            }

            return RuleCheckResult.CreatePassed(RuleName);
        }
    }
}