using System.Collections.Generic;
using System.Threading.Tasks;
using Mmu.Was.WpfUI.Areas.Word.ViewData;

namespace Mmu.Was.WpfUI.Areas.Word.Services
{
    public interface IRuleCheckingService
    {
       Task<IReadOnlyCollection<RuleCheckResultViewData>> CheckRulesAsync(string wordFilePath);
    }
}