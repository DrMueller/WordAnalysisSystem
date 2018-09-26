using System.Collections.Generic;
using Mmu.Mlh.WordAccess.Areas.Models;

namespace Mmu.Was.DomainServices.Areas.Services
{
    public interface IUriCheckService
    {
        IReadOnlyCollection<Hyperlink> CheckInvalidUris(IReadOnlyCollection<Hyperlink> hyperlinks);
    }
}