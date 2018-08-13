using StructureMap;

namespace Mmu.Was.DomainServices.Infrastructure.Ioc
{
    public class DomainServicesRegistry : Registry
    {
        public DomainServicesRegistry()
        {
            Scan(
                scanner =>
                {
                    scanner.AssemblyContainingType(typeof(DomainServicesRegistry));
                    scanner.WithDefaultConventions();
                });
        }
    }
}