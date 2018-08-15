using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mmu.Was.Domain.Areas.Rulings;
using Mmu.Was.DomainServices.Areas.Repositories;
using Mmu.Was.DomainServices.Areas.Services.RuleChecks;

namespace Mmu.Was.DomainServices.Areas.Services.Implementation
{
    public class RuleCheckService : IRuleCheckService
    {
        private readonly IRuleCheck[] _ruleChecks;

        private readonly IWordDocumentRepository _wordDocumentRepository;

        public RuleCheckService(
            IWordDocumentRepository wordDocumentRepository,
            IRuleCheck[] ruleChecks)
        {
            _wordDocumentRepository = wordDocumentRepository;
            _ruleChecks = ruleChecks;
        }

        public async Task<IReadOnlyCollection<RuleCheckResult>> CheckRulesAsync(string wordFilePath)
        {
            var wordDocument = await _wordDocumentRepository.LoadAsync(wordFilePath);
            var ruleCheckTasks = _ruleChecks.Select(rc => rc.CheckRuleAsync(wordDocument)).ToList();

            var ruleCheckResults = await Task.WhenAll(ruleCheckTasks);

            return ruleCheckResults.OrderBy(f => f.RuleCheckPassed)
                .ThenBy(f => f.RuleName)
                .ToList();
        }
    }
}