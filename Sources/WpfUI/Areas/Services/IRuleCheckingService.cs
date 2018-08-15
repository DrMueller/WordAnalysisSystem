using System.Collections.Generic;
using System.Threading.Tasks;
using Mmu.Was.WpfUI.Areas.ViewData;

namespace Mmu.Was.WpfUI.Areas.Services
{
    public interface IRuleCheckingService
    {
        Task<IReadOnlyCollection<RuleCheckResultViewData>> CheckRulesAsync(string wordFilePath);
    }
}