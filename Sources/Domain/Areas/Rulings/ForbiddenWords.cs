using System.Collections.Generic;
using Mmu.Mlh.LanguageExtensions.Areas.Invariance;

namespace Mmu.Was.Domain.Areas.Rulings
{
    public class ForbiddenWords
    {
        public IReadOnlyCollection<string> Words { get; }

        public ForbiddenWords(IReadOnlyCollection<string> words)
        {
            Guard.ObjectNotNull(() => words);

            Words = words;
        }

        public static ForbiddenWords CreateDefault()
        {
            return new ForbiddenWords(
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
}