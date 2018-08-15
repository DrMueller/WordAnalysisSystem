using Microsoft.Office.Interop.Word;

namespace Mmu.Was.DomainServices.Shell.Areas.Servants
{
    public interface IWordDocumentTextServant
    {
        string GetNextSentenceText(Document document, Range range);

        string GetTrimmedText(Range range);
    }
}