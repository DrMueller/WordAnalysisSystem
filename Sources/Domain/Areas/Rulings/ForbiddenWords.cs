using Mmu.Mlh.DomainExtensions.Areas.DomainModeling;
using Mmu.Mlh.LanguageExtensions.Areas.Invariance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mmu.Was.Domain.Areas
{
    public class ForbiddenWords
    {
        public ForbiddenWords(IReadOnlyCollection<string> words)
        {
            Guard.ObjectNotNull(() => words);

            Words = words;
        }

        public IReadOnlyCollection<string> Words { get; }

        public static ForbiddenWords CreateDefault() => new ForbiddenWords(
            new List<string>
            {
                "Test"
            });
    }
}
