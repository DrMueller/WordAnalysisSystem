using System;
using Mmu.Mlh.LanguageExtensions.Areas.Invariance;

namespace Mmu.Was.Domain.Areas.Word
{
    public class Hyperlink
    {
        public Hyperlink(Uri address)
        {
            Guard.ObjectNotNull(() => address);

            Address = address;
        }

        public Uri Address { get; }
    }
}