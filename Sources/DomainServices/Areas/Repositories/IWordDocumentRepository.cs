using System.Threading.Tasks;
using Mmu.Was.Domain.Areas.Word;

namespace Mmu.Was.DomainServices.Areas.Repositories
{
    public interface IWordDocumentRepository
    {
        Task<WordDocument> LoadAsync(string filePath);
    }
}