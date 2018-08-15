using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Word;
using Mmu.Was.Domain.Areas.Word;

namespace Mmu.Was.DomainServices.Shell.Areas.Servants.Implementation
{
    public class WordDocumentWordsServant : IWordDocumentWordsServant
    {
        private readonly IWordDocumentTextServant _textServant;

        public WordDocumentWordsServant(IWordDocumentTextServant textServant) => _textServant = textServant;

        public async Task<IReadOnlyCollection<Word>> GetWordsAsync(Document nativeDocument)
        {
            var words = new ConcurrentBag<Word>();

            await System.Threading.Tasks.Task.Run(
                () =>
                {
                    Parallel.ForEach(
                        nativeDocument.Content.Words.Cast<Range>(),
                        nativeWord =>
                        {
                            var trimmedText = _textServant.GetTrimmedText(nativeWord);
                            if (!string.IsNullOrEmpty(trimmedText))
                            {
                                words.Add(new Word(nativeWord.Start, trimmedText));
                            }
                        });
                });

            var sortedWords = words.OrderBy(word => word.StartPosition).ToList();
            return sortedWords;
        }
    }
}