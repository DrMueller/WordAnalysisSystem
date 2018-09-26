using System.Collections.Generic;

namespace Mmu.Was.Domain.Areas.Rulings
{
    public class RuleCheckResultDetails
    {
        public IReadOnlyCollection<string> Report { get; }

        public RuleCheckResultDetails(IReadOnlyCollection<string> report)
        {
            Report = report;
        }

        public static RuleCheckResultDetails CreateEmpty()
        {
            return new RuleCheckResultDetails(new List<string>());
        }
    }
}