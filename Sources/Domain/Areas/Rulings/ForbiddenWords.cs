using System.Collections.Generic;
using Mmu.Mlh.LanguageExtensions.Areas.Invariance;

namespace Mmu.Was.Domain.Areas.Rulings
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
                "Einfach",
                "Wichtig",
                "Welche",
                "Natürlich",
                "Logischerweise",
                "Selbstverständlich",
                "Schön",
                "fantastisch",
                "super",
                "unglaublich",
                "verrückt",
                "hässlich",
                "Wunderbar",
                "sehr",
                "extrem",
                "wirklich",
                "voll",
                "super",
                "unglaublich"
            });
    }
}