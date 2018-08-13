using System.Collections.Concurrent;
using System.Linq;
using System.Runtime.Caching;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Word;
using Mmu.Was.Domain.Areas.Word;
using Mmu.Was.DomainServices.Areas.Repositories;

namespace Mmu.Was.DomainServices.Shell.Areas.Repositories
{
    public class WordDocumentRepository : IWordDocumentRepository
    {

        public Task<WordDocument> LoadAsync(string filePath)
        {
            return System.Threading.Tasks.Task.Run(
                () =>
                {
                    var app = new Application();
                    var wordDocument = app.Documents.Open(filePath);
                    var words = new ConcurrentBag<Word>();

                    Parallel.ForEach(
                        wordDocument.Content.Words.Cast<Range>(),
                        nativeWord =>
                        {
                            var trimmedText = nativeWord.Text?.Trim();
                            if (!string.IsNullOrEmpty(trimmedText))
                            {
                                words.Add(new Word(nativeWord.Start, trimmedText));
                            }
                        });

                    return new WordDocument(words, null, null);
                });
        }
    }
}