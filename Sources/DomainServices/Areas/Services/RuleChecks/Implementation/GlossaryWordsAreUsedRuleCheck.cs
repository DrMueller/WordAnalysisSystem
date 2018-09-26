using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mmu.Mlh.WordAccess.Areas.Models;
using Mmu.Was.Domain.Areas.Rulings;

namespace Mmu.Was.DomainServices.Areas.Services.RuleChecks.Implementation
{
    public class GlossaryWordsAreUsedRuleCheck : IRuleCheck
    {
        private const string RuleName = "Glossary words are used";

        public async Task<RuleCheckResult> CheckRuleAsync(WordDocument wordDocument)
        {
            return await Task.Run(
                () =>
                {
                    var glossaryTable = wordDocument.Tables.Single(f => f.CaptionText.EndsWith("Glossar", StringComparison.Ordinal));
                    var glossaryWords = glossaryTable.Cells.Where(f => f.ColumnIndex == 1 && f.RowIndex > 1).Select(f => f.Value).ToList();

                    var wordsNotFound = new List<string>();
                    var wordsCombined = string.Join(" ", wordDocument.Words.Select(word => word.Text));

                    foreach (var glossaryWord in glossaryWords)
                    {
                        var occurrences = FindOccurrences(wordsCombined, glossaryWord);
                        if (occurrences <= 1)
                        {
                            wordsNotFound.Add(glossaryWord);
                        }
                    }

                    if (wordsNotFound.Any())
                    {
                        var overviewMessage = $"Found {wordsNotFound.Count} unused Glossary Words.";
                        return new RuleCheckResult(false, RuleName, overviewMessage, new RuleCheckResultDetails(wordsNotFound));
                    }

                    return RuleCheckResult.CreatePassed(RuleName);
                });
        }

        private static int FindOccurrences(string wordsCombined, string glossaryWord)
        {
            var currentIndex = 0;
            var result = 0;

            while (true)
            {
                var foundIndex = wordsCombined.IndexOf(glossaryWord, currentIndex, StringComparison.Ordinal);
                if (foundIndex == -1)
                {
                    return result;
                }

                result++;
                currentIndex = foundIndex + 1;
            }
        }
    }
}