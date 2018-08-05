using Mmu.Was.Domain.Areas.Rulings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mmu.Was.DomainServices.Areas.Services
{
    public interface IRuleCheckService
    {
        IReadOnlyCollection<RuleCheckResult> CheckRules(string wordFilePath);
    }
}
