using StructureMap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
