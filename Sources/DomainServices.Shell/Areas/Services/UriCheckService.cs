using System.Collections.Generic;
using Mmu.Was.Domain.Areas.Word;
using Mmu.Was.DomainServices.Areas.Services;
using Mmu.Was.DomainServices.Shell.Areas.Services.Servants;

namespace Mmu.Was.DomainServices.Shell.Areas.Services
{
    public class UriCheckService : IUriCheckService
    {
        public IReadOnlyCollection<Hyperlink> CheckInvalidUris(IReadOnlyCollection<Hyperlink> hyperlinks)
        {
            var result = new List<Hyperlink>();
            using (var webClient = new HeadWebClient())
            {
                foreach (var hyperLink in hyperlinks)
                {
                    try
                    {
                        webClient.DownloadData(hyperLink.Address);
                    }
                    catch
                    {
                        result.Add(hyperLink);
                    }
                }
            }

            return result;
        }
    }
}