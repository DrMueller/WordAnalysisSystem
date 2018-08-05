using System.Collections.Generic;
using System.Linq;
using Mmu.Was.Domain.Areas;
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

            foreach(var forbiddenWord in forbiddenWords.Words)
            {
                var foundForbiddenWords = wordDocument.FindWord(forbiddenWord);
                if ( foundForbiddenWords.Any())
                {
                    foundForbiddenWordsReport.Add($"Word { forbiddenWord } was found { foundForbiddenWords.Count() } times.");
                }
            }
            
            if (foundForbiddenWordsReport.Any())
            {
                var overviewMessage = $"Found { foundForbiddenWordsReport.Count } forbidden Words.";
                return new RuleCheckResult(false, RuleName, overviewMessage, new RuleCheckResultDetails(foundForbiddenWordsReport));
            }

            return RuleCheckResult.CreatePassed(RuleName);
        }
    }
}
