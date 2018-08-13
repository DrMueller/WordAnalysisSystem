using System.Windows.Controls;
using Mmu.Mlh.WpfExtensions.Areas.MvvmShell.Views.Models;
using Mmu.Was.WpfUI.Areas.Word.ViewModels;

namespace Mmu.Was.WpfUI.Areas.Word.Views
{
    /// <summary>
    ///     Interaction logic for WordRuleCheckView.xaml
    /// </summary>
    public partial class WordRuleCheckView : UserControl, IViewMap<WordRuleCheckViewModel>
    {
        public WordRuleCheckView()
        {
            InitializeComponent();
        }
    }
}