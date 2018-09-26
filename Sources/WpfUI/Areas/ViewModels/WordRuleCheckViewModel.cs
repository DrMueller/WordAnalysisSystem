using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;
using Mmu.Mlh.WpfExtensions.Areas.MvvmShell.Commands;
using Mmu.Mlh.WpfExtensions.Areas.MvvmShell.ViewModels.Behaviors;
using Mmu.Mlh.WpfExtensions.Areas.MvvmShell.ViewModels.Models;
using Mmu.Mlh.WpfExtensions.Areas.ViewExtensions.Components.CommandBars.ViewData;
using Mmu.Was.WpfUI.Areas.ViewData;
using Mmu.Was.WpfUI.Areas.ViewModels.ViewModelCommands;

namespace Mmu.Was.WpfUI.Areas.ViewModels
{
    public class WordRuleCheckViewModel : ViewModelBase, IMainNavigationViewModel, IViewModelWithHeading, IInitializableViewModel
    {
        private readonly WordRuleCheckViewModelCommands _commandsContainer;
        private IReadOnlyCollection<RuleCheckResultViewData> _ruleCheckResults;
        private string _wordFilePath;
        public CommandsViewData Commands => _commandsContainer.Commands;
        public ICommand CopyReportEntry => _commandsContainer.CopyReportEntry;
        public string HeadingText => "Word check";
        public string NavigationDescription => "Word check";
        public int NavigationSequence => 1;

        public IReadOnlyCollection<RuleCheckResultViewData> RuleCheckResults
        {
            get => _ruleCheckResults;
            set
            {
                _ruleCheckResults = value;
                OnPropertyChanged();
            }
        }

        public ViewModelCommand SearchWordDocument => _commandsContainer.SearchWordDocument;
        public RuleCheckResultViewData SelectedEntry { get; set; }

        public string WordFilePath
        {
            get => _wordFilePath;
            set
            {
                _wordFilePath = value;
                OnPropertyChanged();
            }
        }

        public WordRuleCheckViewModel(WordRuleCheckViewModelCommands commandsContainer)
        {
            _commandsContainer = commandsContainer;
        }

        public async Task InitializeAsync()
        {
            await _commandsContainer.InitializeAsync(this);
        }
    }
}