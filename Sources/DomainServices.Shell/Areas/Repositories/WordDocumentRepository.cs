using Mmu.Was.Domain.Areas;
using Mmu.Was.Domain.Areas.Word;
using Mmu.Was.DomainServices.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mmu.Was.DomainServices.Shell.Areas.Repositories
{
    public class WordDocumentRepository : IWordDocumentRepository
    {
        public WordDocument Load(string filePath)
        {
            Microsoft.Office.Interop.Word.Application app = new Microsoft.Office.Interop.Word.Application();
            var wordDocument = app.Documents.Open(filePath);

            var nativeWords = wordDocument.Words.Cast<object>().Select(w => w.ToString()).ToList();

            return new WordDocument(nativeWords, null, null);
        }
    }
}
