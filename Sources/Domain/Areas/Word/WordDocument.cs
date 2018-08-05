using Mmu.Mlh.DomainExtensions.Areas.DomainModeling;
using Mmu.Mlh.LanguageExtensions.Areas.Invariance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mmu.Was.Domain.Areas.Word
{
    public class WordDocument
    {
        public WordDocument(
            IReadOnlyCollection<string> words,
            IReadOnlyCollection<Table> tables,
            IReadOnlyCollection<Graphic> graphics
            ) 
        {
            Guard.ObjectNotNull(() => words);
            //Guard.ObjectNotNull(() => tables);
            //Guard.ObjectNotNull(() => graphics);

            Words = words;
            Tables = tables;
            Graphics = graphics;
        }

        public IReadOnlyCollection<string> FindWord(string word)
        {
            return Words.Where(w => w.Equals(word, StringComparison.OrdinalIgnoreCase)).ToList();
        }

        public IReadOnlyCollection<string> Words { get; }
        public IReadOnlyCollection<Table> Tables { get; }
        public IReadOnlyCollection<Graphic> Graphics { get; }
    }
}
