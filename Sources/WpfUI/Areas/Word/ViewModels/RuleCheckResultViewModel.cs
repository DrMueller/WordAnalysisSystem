using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mmu.Was.WpfUI.Areas.Word.ViewModels
{
    public class RuleCheckResultViewModel
    {
        public RuleCheckResultViewModel(bool rulePassed, string resultOverview, IReadOnlyCollection<string> details)
        {
            RulePassed = rulePassed;
            ResultOverview = resultOverview;
            Details = details;
        }

        public string RulePassedImageSource
        {
            get
            {
                return "/Mmu.Was.WpfUI;component/Infrastructure/Assets/M.png";
            }
        }

        public bool RulePassed { get; }
        public string ResultOverview { get; }
        public IReadOnlyCollection<string> Details { get; }
    }
}
