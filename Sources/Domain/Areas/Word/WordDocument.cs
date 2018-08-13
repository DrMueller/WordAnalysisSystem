using System.Collections.Generic;
using Mmu.Mlh.LanguageExtensions.Areas.Invariance;

namespace Mmu.Was.Domain.Areas.Word
{
    public class WordDocument
    {
        public WordDocument(
            IReadOnlyCollection<Word> words,
            IReadOnlyCollection<Table> tables,
            IReadOnlyCollection<Graphic> graphics
        )
        {
            Guard.ObjectNotNull(() => words);

            ////Guard.ObjectNotNull(() => tables);
            ////Guard.ObjectNotNull(() => graphics);

            Words = words;
            Tables = tables;
            Graphics = graphics;
        }

        public IReadOnlyCollection<Graphic> Graphics { get; }
        public IReadOnlyCollection<Table> Tables { get; }
        public IReadOnlyCollection<Word> Words { get; }
    }
}