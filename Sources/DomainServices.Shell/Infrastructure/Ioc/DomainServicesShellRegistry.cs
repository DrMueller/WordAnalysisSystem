using Mmu.Was.DomainServices.Repositories;
using Mmu.Was.DomainServices.Shell.Areas.Repositories;
using StructureMap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
