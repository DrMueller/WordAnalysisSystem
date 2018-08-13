using StructureMap;

namespace Mmu.Was.Application.Infrastructure.Ioc
{
    public class ApplicationRegistry : Registry
    {
        public ApplicationRegistry()
        {
            Scan(
                scanner =>
                {
                    scanner.AssemblyContainingType(typeof(ApplicationRegistry));
                    scanner.WithDefaultConventions();
                });
        }
    }
}