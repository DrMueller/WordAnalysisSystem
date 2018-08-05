using Mmu.Mlh.WpfExtensions.Areas.MvvmShell.Commands;
using Mmu.Mlh.WpfExtensions.Areas.MvvmShell.ViewModels.Behaviors;
using Mmu.Mlh.WpfExtensions.Areas.MvvmShell.ViewModels.Models;
using Mmu.Was.WpfUI.Areas.Word.ViewModels.ViewModelCommands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Mmu.Was.WpfUI.Areas.Word.ViewModels
{
    public class WordRuleCheckViewModel : ViewModelBase, IMainNavigationViewModel, IViewModelWithHeading, IInitializableViewModel
    {
        private readonly WordRuleCheckViewModelCommands _commands;

        public WordRuleCheckViewModel(WordRuleCheckViewModelCommands commands)
        {
            _commands = commands;
        }

        private string _wordFilePath;

        public string WordFilePath
        {
            get
            {
                return _wordFilePath;
            }
            set
            {
                _wordFilePath = value;
                OnPropertyChanged();
            }
        }

        public ViewModelCommand CheckWordDocument => _commands.CheckWordDocument;

        public ViewModelCommand SearchWordDocument => _commands.SearchWordDocument;

        public  IReadOnlyCollection<RuleCheckResultViewModel> RuleCheckResults { get; set; }

        public string HeadingText => "Word check";

        public string NavigationDescription => "Word check";

        public int NavigationSequence => 1;

        public async Task InitializeAsync()
        {
            await _commands.InitializeAsync(this);
        }
    }
}
