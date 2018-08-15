using System.Collections.Generic;
using Mmu.Mlh.LanguageExtensions.Areas.Invariance;

namespace Mmu.Was.Domain.Areas.Word
{
    public class Table : IElementWithCaption
    {
        public Table(string captionText, IReadOnlyCollection<Cell> cells)
        {
            Guard.ObjectNotNull(() => cells);

            CaptionText = captionText;
            Cells = cells;
        }

        public string CaptionText { get; }
        public IReadOnlyCollection<Cell> Cells { get; }
    }
}