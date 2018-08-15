using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Word;

namespace Mmu.Was.DomainServices.Shell.Areas.Servants.Implementation
{
    public class WordDocumentTablesServant : IWordDocumentTablesServant
    {
        private readonly IWordDocumentTextServant _textServant;

        public WordDocumentTablesServant(IWordDocumentTextServant textServant) => _textServant = textServant;

        public async Task<IReadOnlyCollection<Domain.Areas.Word.Table>> GetTablesAsync(Document nativeDocument)
        {
            return await System.Threading.Tasks.Task.Run(
                () =>
                {
                    return nativeDocument.Tables.Cast<Table>()
                        .Select(nativeTable => CreateFromNativeTable(nativeDocument, nativeTable))
                        .ToList();
                });
        }

        private Domain.Areas.Word.Table CreateFromNativeTable(Document nativeDocument, Table nativeTable)
        {
            var cells = nativeTable.Range.Cells.Cast<Cell>()
                .Select(
                    nativeCell =>
                        new Domain.Areas.Word.Cell(nativeCell.ColumnIndex, nativeCell.RowIndex, _textServant.GetTrimmedText(nativeCell.Range)))
                .ToList();

            var captionText = _textServant.GetNextSentenceText(nativeDocument, nativeTable.Range);

            return new Domain.Areas.Word.Table(captionText, cells);
        }
    }
}