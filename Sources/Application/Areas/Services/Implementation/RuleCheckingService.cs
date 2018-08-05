using Mmu.Was.Application.Areas.Dtos;
using Mmu.Was.Application.Areas.RuleChecking;
using Mmu.Was.Domain.Areas;
using Mmu.Was.Domain.Areas.Rulings;
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
        private readonly IForbiddenWordsRuleCheckService _forbiddenWordsRuleCheckService;

        public RuleCheckingService(
            IWordDocumentRepository wordDocumentRepository,
            IForbiddenWordsRuleCheckService forbiddenWordsRuleCheckService)
        {
            _wordDocumentRepository = wordDocumentRepository;
            _forbiddenWordsRuleCheckService = forbiddenWordsRuleCheckService;
        }

        public IReadOnlyCollection<RuleCheckResultDto> CheckRules(string wordFilePath)
        {
            var wordDocoument = _wordDocumentRepository.Load(wordFilePath);
            var checkResults = new List<RuleCheckResult>();
            checkResults.Add(_forbiddenWordsRuleCheckService.CheckForbiddenWords(wordDocoument, ForbiddenWords.CreateDefault()));

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
