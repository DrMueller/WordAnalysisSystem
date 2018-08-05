using StructureMap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
