using Mmu.Was.Application.Areas.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mmu.Was.Application.Areas.RuleChecking
{
    public interface IRuleCheckingService
    {
        IReadOnlyCollection<RuleCheckResultDto> CheckRules(string wordFilePath);
    }
}
