using System.Collections.Generic;

namespace Mmu.Was.Domain.Areas.Rulings
{
    public class RuleCheckResultDetails
    {
        public RuleCheckResultDetails(IReadOnlyCollection<string> report) => Report = report;

        public IReadOnlyCollection<string> Report { get; }

        public static RuleCheckResultDetails CreateEmpty() => new RuleCheckResultDetails(new List<string>());
    }
}