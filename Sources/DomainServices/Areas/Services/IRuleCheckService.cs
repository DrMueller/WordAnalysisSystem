using System.Collections.Generic;
using System.Threading.Tasks;
using Mmu.Was.Domain.Areas.Rulings;

namespace Mmu.Was.DomainServices.Areas.Services
{
    public interface IRuleCheckService
    {
        Task<IReadOnlyCollection<RuleCheckResult>> CheckRulesAsync(string wordFilePath);
    }
}