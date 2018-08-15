using System;
using System.Net;

namespace Mmu.Was.DomainServices.Shell.Areas.Services.Servants
{
    // https://stackoverflow.com/questions/153451/how-to-check-if-system-net-webclient-downloaddata-is-downloading-a-binary-file#156750
    internal class HeadWebClient : WebClient
    {
        protected override WebRequest GetWebRequest(Uri address)
        {
            var baseRequest = base.GetWebRequest(address);

            if (baseRequest != null)
            {
                baseRequest.Method = "HEAD";
            }

            return baseRequest;
        }
    }
}