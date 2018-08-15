using System.Collections.Generic;
using Mmu.Mlh.LanguageExtensions.Areas.Invariance;

namespace Mmu.Was.Domain.Areas.Word
{
    public class WordDocument
    {
        public WordDocument(
            IReadOnlyCollection<Word> words,
            IReadOnlyCollection<Table> tables,
            IReadOnlyCollection<Shape> shapes,
            IReadOnlyCollection<Hyperlink> hyperLinks
        )
        {
            Guard.ObjectNotNull(() => words);
            Guard.ObjectNotNull(() => tables);
            Guard.ObjectNotNull(() => shapes);
            Guard.ObjectNotNull(() => hyperLinks);

            Words = words;
            Tables = tables;
            Shapes = shapes;
            HyperLinks = hyperLinks;
        }

        public IReadOnlyCollection<Hyperlink> HyperLinks { get; }
        public IReadOnlyCollection<Shape> Shapes { get; }
        public IReadOnlyCollection<Table> Tables { get; }
        public IReadOnlyCollection<Word> Words { get; }
    }
}