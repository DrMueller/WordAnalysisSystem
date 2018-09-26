using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mmu.Was.Application.Areas.Dtos;
using Mmu.Was.DomainServices.Areas.Services;

namespace Mmu.Was.Application.Areas.Services.Implementation
{
    public class RuleCheckingService : IRuleCheckingService
    {
        private readonly IRuleCheckService _ruleCheckService;
        private readonly IWordDocumentService _wordDocumentService;

        public RuleCheckingService(
            IRuleCheckService ruleCheckService,
            IWordDocumentService wordDocumentService)
        {
            _ruleCheckService = ruleCheckService;
            _wordDocumentService = wordDocumentService;
        }

        public async Task<IReadOnlyCollection<RuleCheckResultDto>> CheckRulesAsync(string wordFilePath)
        {
            _wordDocumentService.ClearWordDocumentInstances();
            var checkResults = await _ruleCheckService.CheckRulesAsync(wordFilePath);

            var result = checkResults.Select(
                rs => new RuleCheckResultDto
                {
                    Details = rs.Details.Report,
                    ResultOverview = rs.ResultOverview,
                    RuleCheckPassed = rs.RuleCheckPassed,
                    RuleName = rs.RuleName
                }).ToList();

            return result;
        }
    }
}