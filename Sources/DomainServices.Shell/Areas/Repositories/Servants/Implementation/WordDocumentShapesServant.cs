using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Word;

namespace Mmu.Was.DomainServices.Shell.Areas.Servants.Implementation
{
    public class WordDocumentShapesServant : IWordDocumentShapesServant
    {
        private readonly IWordDocumentTextServant _textServant;

        public WordDocumentShapesServant(IWordDocumentTextServant textServant) => _textServant = textServant;

        public async Task<IReadOnlyCollection<Domain.Areas.Word.Shape>> GetShapesAsync(Document nativeDocument)
        {
            var result = new List<Domain.Areas.Word.Shape>();

            await System.Threading.Tasks.Task.Run(
                () =>
                {
                    foreach (InlineShape shape in nativeDocument.InlineShapes)
                    {
                        var captionText = _textServant.GetNextSentenceText(nativeDocument, shape.Range);
                        result.Add(new Domain.Areas.Word.Shape(captionText));
                    }
                });

            return result;
        }
    }
}