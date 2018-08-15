using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Word;
using Mmu.Was.Domain.Areas.Word;
using Mmu.Was.DomainServices.Areas.Repositories;
using Mmu.Was.DomainServices.Shell.Areas.Servants;

namespace Mmu.Was.DomainServices.Shell.Areas.Repositories
{
    public class WordDocumentRepository : IWordDocumentRepository
    {
        private readonly IWordDocumentHyperlinksServant _hyperlinksServant;

        private readonly IWordDocumentShapesServant _shapesServant;

        private readonly IWordDocumentTablesServant _tablesServant;

        private readonly IWordDocumentWordsServant _wordsServant;

        public WordDocumentRepository(
            IWordDocumentShapesServant shapesServant,
            IWordDocumentTablesServant tablesServant,
            IWordDocumentWordsServant wordsServant,
            IWordDocumentHyperlinksServant hyperlinksServant)
        {
            _shapesServant = shapesServant;
            _tablesServant = tablesServant;
            _wordsServant = wordsServant;
            _hyperlinksServant = hyperlinksServant;
        }

        public Task<WordDocument> LoadAsync(string filePath)
        {
            return System.Threading.Tasks.Task.Run(
                async () =>
                {
                    Application app = null;
                    try
                    {
                        app = new Application();
                        var nativeDocument = app.Documents.Open(filePath);
                        var words = await _wordsServant.GetWordsAsync(nativeDocument);
                        var tables = await _tablesServant.GetTablesAsync(nativeDocument);
                        var shapes = await _shapesServant.GetShapesAsync(nativeDocument);
                        var hyperlinks = await _hyperlinksServant.GetHyperLinksAsync(nativeDocument);

                        return new WordDocument(words, tables, shapes, hyperlinks);
                    }
                    finally
                    {
                        if (app != null)
                        {
                            Marshal.ReleaseComObject(app);
                        }
                    }
                });
        }
    }
}