using Mmu.Was.Application.Areas.Dtos;
using Mmu.Was.Application.Areas.RuleChecking;
using Mmu.Was.Domain.Areas;
using Mmu.Was.Domain.Areas.Rulings;
using Mmu.Was.DomainServices.Areas.Services;
using Mmu.Was.DomainServices.Areas.Services.RuleChecks;
using Mmu.Was.DomainServices.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mmu.Was.Application.Areas.Services.Implementation
{
    public class RuleCheckingService : IRuleCheckingService
    {
        private readonly IWordDocumentRepository _wordDocumentRepository;
        private readonly IRuleCheckService _ruleCheckService;

        public RuleCheckingService(
            IWordDocumentRepository wordDocumentRepository,
            IRuleCheckService ruleCheckService)
        {
            _wordDocumentRepository = wordDocumentRepository;
            _ruleCheckService = ruleCheckService;
        }

        public IReadOnlyCollection<RuleCheckResultDto> CheckRules(string wordFilePath)
        {
            var checkResults = _ruleCheckService.CheckRules(wordFilePath);

            var result = checkResults.Select(rs => new RuleCheckResultDto
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
