using System.Linq;
using System.Threading.Tasks;
using Mmu.Mlh.WordAccess.Areas.Models;
using Mmu.Was.Domain.Areas.Rulings;

namespace Mmu.Was.DomainServices.Areas.Services.RuleChecks.Implementation
{
    public class LinksAreValidRuleCheck : IRuleCheck
    {
        private const string RuleName = "Links are valid";
        private readonly IUriCheckService _uriCheckService;

        public LinksAreValidRuleCheck(IUriCheckService uriCheckService)
        {
            _uriCheckService = uriCheckService;
        }

        public async Task<RuleCheckResult> CheckRuleAsync(WordDocument wordDocument)
        {
            return await Task.Run(
                () =>
                {
                    var invalidLinks = _uriCheckService.CheckInvalidUris(wordDocument.HyperLinks);

                    if (!invalidLinks.Any())
                    {
                        return RuleCheckResult.CreatePassed(RuleName);
                    }

                    var overviewMessage = $"Found {invalidLinks.Count} invalid Links.";
                    var invalidLinkUris = invalidLinks.Select(link => link.Address.AbsoluteUri).ToList();
                    return new RuleCheckResult(false, RuleName, overviewMessage, new RuleCheckResultDetails(invalidLinkUris));
                });
        }
    }
}