using Mmu.Was.Domain.Areas.Rulings;
using Mmu.Was.Domain.Areas.Word;

namespace Mmu.Was.DomainServices.Areas.Services.RuleChecks
{
    public interface IForbiddenWordsRuleCheckService
    {
        RuleCheckResult CheckForbiddenWords(WordDocument wordDocument, ForbiddenWords forbiddenWords);
    }
}