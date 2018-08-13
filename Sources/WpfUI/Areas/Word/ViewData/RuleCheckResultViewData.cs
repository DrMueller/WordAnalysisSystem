using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mmu.Was.WpfUI.Areas.Word.ViewData
{
    public class RuleCheckResultViewData
    {
        public RuleCheckResultViewData(bool rulePassed, string ruleName, string resultOverview, IReadOnlyCollection<string> details)
        {
            RulePassed = rulePassed;
            RuleName = ruleName;
            ResultOverview = CreateOverviewMessage(resultOverview, details);
            Details = details;
        }

        public IReadOnlyCollection<string> Details { get; }
        public string ResultOverview { get; }
        public string RuleName { get; }
        public bool RulePassed { get; }

        public string RulePassedImageSource
        {
            get
            {
                if (RulePassed)
                {
                    return "/Mmu.Was.WpfUI;component/Infrastructure/Assets/FA_Ok.png";
                }

                return "/Mmu.Was.WpfUI;component/Infrastructure/Assets/FA_Warn.png";
            }
        }

        private static string CreateOverviewMessage(string resultOverview, IReadOnlyCollection<string> details)
        {
            var sb = new StringBuilder(resultOverview);
            for (var i = 0; i < details.Count; i++)
            {
                if (i == 0)
                {
                    sb.AppendLine();
                }

                sb.AppendLine(details.ElementAt(i));
            }

            return sb.ToString();
        }
    }
}