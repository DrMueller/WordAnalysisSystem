using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Word;

namespace Mmu.Was.DomainServices.Shell.Areas.Servants
{
    public interface IWordDocumentHyperlinksServant
    {
        Task<IReadOnlyCollection<Domain.Areas.Word.Hyperlink>> GetHyperLinksAsync(Document nativeDocument);
    }
}