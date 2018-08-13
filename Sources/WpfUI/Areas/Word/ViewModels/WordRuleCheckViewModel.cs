using System.Collections.Generic;
using System.Threading.Tasks;
using Mmu.Mlh.WpfExtensions.Areas.MvvmShell.Commands;
using Mmu.Mlh.WpfExtensions.Areas.MvvmShell.ViewModels.Behaviors;
using Mmu.Mlh.WpfExtensions.Areas.MvvmShell.ViewModels.Models;
using Mmu.Was.WpfUI.Areas.Word.ViewData;
using Mmu.Was.WpfUI.Areas.Word.ViewModels.ViewModelCommands;

namespace Mmu.Was.WpfUI.Areas.Word.ViewModels
{
    public class WordRuleCheckViewModel : ViewModelBase, IMainNavigationViewModel, IViewModelWithHeading, IInitializableViewModel
    {
        private readonly WordRuleCheckViewModelCommands _commands;

        private IReadOnlyCollection<RuleCheckResultViewData> _ruleCheckResults;

        private string _wordFilePath;

        public WordRuleCheckViewModel(WordRuleCheckViewModelCommands commands) => _commands = commands;

        public ViewModelCommand CheckWordDocument => _commands.CheckWordDocument;
        public string HeadingText => "Word check";
        public string NavigationDescription => "Word check";
        public int NavigationSequence => 1;

        public ViewModelCommand TestInfo => _commands.TestInfo;

        public IReadOnlyCollection<RuleCheckResultViewData> RuleCheckResults
        {
            get => _ruleCheckResults;
            set
            {
                _ruleCheckResults = value;
                OnPropertyChanged();
            }
        }

        public ViewModelCommand SearchWordDocument => _commands.SearchWordDocument;

        public string WordFilePath
        {
            get => _wordFilePath;
            set
            {
                _wordFilePath = value;
                OnPropertyChanged();
            }
        }

        public async Task InitializeAsync()
        {
            await _commands.InitializeAsync(this);
        }
    }
}