using System.Threading.Tasks;
using Mmu.Mlh.WordAccess.Areas.Models;
using Mmu.Was.Domain.Areas.Rulings;

namespace Mmu.Was.DomainServices.Areas.Services.RuleChecks
{
    public interface IRuleCheck
    {
        Task<RuleCheckResult> CheckRuleAsync(WordDocument wordDocument);
    }
}