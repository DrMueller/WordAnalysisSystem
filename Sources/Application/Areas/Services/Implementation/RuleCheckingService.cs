using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mmu.Mlh.ApplicationExtensions.Areas.InformationHandling.Models;
using Mmu.Mlh.ApplicationExtensions.Areas.InformationHandling.Services;
using Mmu.Was.Application.Areas.Dtos;
using Mmu.Was.DomainServices.Areas.Services;

namespace Mmu.Was.Application.Areas.Services.Implementation
{
    public class RuleCheckingService : IRuleCheckingService
    {
        private readonly IInformationPublishingService _informationPublishingService;

        private readonly IRuleCheckService _ruleCheckService;

        private readonly IWordDocumentService _wordDocumentService;

        public RuleCheckingService(
            IRuleCheckService ruleCheckService,
            IInformationPublishingService informationPublishingService,
            IWordDocumentService wordDocumentService)
        {
            _ruleCheckService = ruleCheckService;
            _informationPublishingService = informationPublishingService;
            _wordDocumentService = wordDocumentService;
        }

        public async Task<IReadOnlyCollection<RuleCheckResultDto>> CheckRulesAsync(string wordFilePath)
        {
            _informationPublishingService.Publish(InformationEntry.CreateInfo("Clearing Word instances..", true));
            _wordDocumentService.ClearWordDocumentInstances();

            _informationPublishingService.Publish(InformationEntry.CreateInfo("Checking Rules..", true));
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