using Mmu.Was.Domain.Areas;
using Mmu.Was.Domain.Areas.Word;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mmu.Was.DomainServices.Repositories
{
    public interface IWordDocumentRepository
    {
        WordDocument Load(string filePath);
    }
}
