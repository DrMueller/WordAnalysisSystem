using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Word;

namespace Mmu.Was.DomainServices.Shell.Areas.Servants.Implementation
{
    public class WordDocumentHyperlinksServant : IWordDocumentHyperlinksServant
    {
        public async Task<IReadOnlyCollection<Domain.Areas.Word.Hyperlink>> GetHyperLinksAsync(Document nativeDocument)
        {
            return await System.Threading.Tasks.Task.Run(
                () =>
                {
                    return nativeDocument
                        .Hyperlinks
                        .Cast<Hyperlink>()
                        .Where(hyperLink => !string.IsNullOrEmpty(hyperLink.Address))
                        .Select(hyperLink => hyperLink.Address)
                        .Select(str => new Uri(str))
                        .Select(uri => new Domain.Areas.Word.Hyperlink(uri))
                        .ToList();
                });
        }
    }
}