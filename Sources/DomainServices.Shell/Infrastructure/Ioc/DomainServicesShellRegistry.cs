using Mmu.Was.DomainServices.Areas.Repositories;
using Mmu.Was.DomainServices.Shell.Areas.Repositories;
using StructureMap;

namespace Mmu.Was.DomainServices.Shell.Infrastructure.Ioc
{
    public class DomainServicesShellRegistry : Registry
    {
        public DomainServicesShellRegistry()
        {
            Scan(
                scanner =>
                {
                    scanner.AssemblyContainingType(typeof(DomainServicesShellRegistry));
                    scanner.WithDefaultConventions();
                });

            For<IWordDocumentRepository>().Use<WordDocumentRepository>();
        }
    }
}