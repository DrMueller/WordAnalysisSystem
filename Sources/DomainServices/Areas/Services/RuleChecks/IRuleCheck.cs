using System.Threading.Tasks;
using Mmu.Was.Domain.Areas.Rulings;
using Mmu.Was.Domain.Areas.Word;

namespace Mmu.Was.DomainServices.Areas.Services.RuleChecks
{
    public interface IRuleCheck
    {
        Task<RuleCheckResult> CheckRuleAsync(WordDocument wordDocument);
    }
}