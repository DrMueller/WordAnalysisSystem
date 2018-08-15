using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mmu.Was.WpfUI.Areas.ViewData;

namespace Mmu.Was.WpfUI.Areas.Services.Implementation
{
    public class RuleCheckingService : IRuleCheckingService
    {
        private readonly Application.Areas.Services.IRuleCheckingService _ruleCheckingService;

        public RuleCheckingService(Application.Areas.Services.IRuleCheckingService ruleCheckingService) => _ruleCheckingService = ruleCheckingService;

        public async Task<IReadOnlyCollection<RuleCheckResultViewData>> CheckRulesAsync(string wordFilePath)
        {
            var checkResult = await _ruleCheckingService.CheckRulesAsync(wordFilePath);

            return checkResult
                .Select(dto => new RuleCheckResultViewData(dto.RuleCheckPassed, dto.RuleName, dto.ResultOverview, dto.Details))
                .ToList();
        }
    }
}