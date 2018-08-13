using System.Diagnostics;
using System.Globalization;
using System.Linq;
using Mmu.Mlh.LanguageExtensions.Areas.Collections;

namespace Mmu.Was.Application.Areas.Services.Implementation
{
    public class WordDocumentService : IWordDocumentService
    {
        public void ClearWordDocumentInstances()
        {
            Process
                .GetProcesses()
                .Where(f => f.ProcessName.ToUpper(CultureInfo.CurrentCulture).Contains("WINWORD"))
                .ForEach(proc => proc.Kill());
        }
    }
}