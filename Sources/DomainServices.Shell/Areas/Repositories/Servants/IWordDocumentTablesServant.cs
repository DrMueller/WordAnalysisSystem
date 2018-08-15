using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Word;

namespace Mmu.Was.DomainServices.Shell.Areas.Servants
{
    public interface IWordDocumentTablesServant
    {
        Task<IReadOnlyCollection<Domain.Areas.Word.Table>> GetTablesAsync(Document nativeDocument);
    }
}