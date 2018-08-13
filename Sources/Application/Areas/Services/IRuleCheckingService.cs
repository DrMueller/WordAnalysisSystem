using System.Collections.Generic;
using System.Threading.Tasks;
using Mmu.Was.Application.Areas.Dtos;

namespace Mmu.Was.Application.Areas.Services
{
    public interface IRuleCheckingService
    {
        Task<IReadOnlyCollection<RuleCheckResultDto>> CheckRulesAsync(string wordFilePath);
    }
}