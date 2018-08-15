using System.Collections.Generic;
using Mmu.Was.Domain.Areas.Word;

namespace Mmu.Was.DomainServices.Areas.Services
{
    public interface IUriCheckService
    {
        IReadOnlyCollection<Hyperlink> CheckInvalidUris(IReadOnlyCollection<Hyperlink> hyperlinks);
    }
}