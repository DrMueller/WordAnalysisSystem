using System.Collections.Generic;
using System.Threading.Tasks;
using Mmu.Was.Domain.Areas.Rulings;
using Mmu.Was.DomainServices.Areas.Repositories;
using Mmu.Was.DomainServices.Areas.Services.RuleChecks;

namespace Mmu.Was.DomainServices.Areas.Services.Implementation
{
    public class RuleCheckService : IRuleCheckService
    {
        private readonly IForbiddenWordsRuleCheckService _forbiddenWordsRuleCheckservice;

        private readonly IWordDocumentRepository _wordDocumentRepository;

        public RuleCheckService(
            IWordDocumentRepository wordDocumentRepository,
            IForbiddenWordsRuleCheckService forbiddenWordsRuleCheckservice)
        {
            _wordDocumentRepository = wordDocumentRepository;
            _forbiddenWordsRuleCheckservice = forbiddenWordsRuleCheckservice;
        }

        public async Task<IReadOnlyCollection<RuleCheckResult>> CheckRulesAsync(string wordFilePath)
        {
            var wordDocument = await _wordDocumentRepository.LoadAsync(wordFilePath);

            var result = new List<RuleCheckResult>
            {
                _forbiddenWordsRuleCheckservice.CheckForbiddenWords(wordDocument, ForbiddenWords.CreateDefault())
            };

            return result;
        }
    }
}