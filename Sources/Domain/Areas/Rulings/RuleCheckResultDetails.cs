using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mmu.Was.Domain.Areas.Rulings
{
    public class RuleCheckResultDetails
    {
        public RuleCheckResultDetails(IReadOnlyCollection<string> report)
        {
            Report = report;
        }

        public static RuleCheckResultDetails CreateEmpty() => new RuleCheckResultDetails(new List<string>());

        public IReadOnlyCollection<string> Report { get; }
    }
}
