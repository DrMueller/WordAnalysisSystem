using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mmu.Was.Domain.Areas;
using Mmu.Was.Domain.Areas.Rulings;
using Mmu.Was.DomainServices.Areas.Services.RuleChecks;
using Mmu.Was.DomainServices.Repositories;

namespace Mmu.Was.DomainServices.Areas.Services.Implementation
{
    public class RuleCheckService : IRuleCheckService
    {
        private readonly IWordDocumentRepository _wordDocumentRepository;
        private readonly IForbiddenWordsRuleCheckService _forbiddenWordsRuleCheckservice;

        public RuleCheckService(
            IWordDocumentRepository wordDocumentRepository,
            IForbiddenWordsRuleCheckService forbiddenWordsRuleCheckservice)
        {
            _wordDocumentRepository = wordDocumentRepository;
            _forbiddenWordsRuleCheckservice = forbiddenWordsRuleCheckservice;
        }

        public IReadOnlyCollection<RuleCheckResult> CheckRules(string wordFilePath)
        {
            var wordDocument = _wordDocumentRepository.Load(wordFilePath);

            var result = new List<RuleCheckResult>
            {
                _forbiddenWordsRuleCheckservice.CheckForbiddenWords(wordDocument, ForbiddenWords.CreateDefault())
            };

            return result;
        }
    }
}
