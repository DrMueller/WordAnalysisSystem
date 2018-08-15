using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Word;
using Mmu.Was.Domain.Areas.Word;

namespace Mmu.Was.DomainServices.Shell.Areas.Servants
{
    public interface IWordDocumentWordsServant
    {
        Task<IReadOnlyCollection<Word>> GetWordsAsync(Document nativeDocument);
    }
}