using System.Threading.Tasks;
using Mmu.Mlh.ApplicationExtensions.Areas.InformationHandling.Models;
using Mmu.Mlh.ApplicationExtensions.Areas.InformationHandling.Services;
using Mmu.Mlh.WpfExtensions.Areas.MvvmShell.Commands;
using Mmu.Mlh.WpfExtensions.Areas.ViewExtensions.Dialogs.FileDialogs.Services;
using Mmu.Was.WpfUI.Areas.Word.Services;

namespace Mmu.Was.WpfUI.Areas.Word.ViewModels.ViewModelCommands
{
    public class WordRuleCheckViewModelCommands : IViewModelCommandContainer<WordRuleCheckViewModel>
    {
        private readonly IFileDialogService _fileDialogService;

        private readonly IInformationPublishingService _informationPublishingService;

        private readonly IRuleCheckingService _ruleCheckingService;

        private WordRuleCheckViewModel _context;

        private bool _ruleCheckInProgress;

        public WordRuleCheckViewModelCommands(IFileDialogService fileDialogService, IRuleCheckingService ruleCheckingService, IInformationPublishingService informationPublishingService)
        {
            _fileDialogService = fileDialogService;
            _ruleCheckingService = ruleCheckingService;
            _informationPublishingService = informationPublishingService;
        }

        public ViewModelCommand CheckWordDocument
        {
            get
            {
                return new ViewModelCommand(
                    "Check document",
                    new RelayCommand(
                        async () =>
                        {
                            _ruleCheckInProgress = true;
                            _context.RuleCheckResults = await _ruleCheckingService.CheckRulesAsync(_context.WordFilePath);
                            _ruleCheckInProgress = false;
                        },
                        () => !string.IsNullOrEmpty(_context.WordFilePath) && !_ruleCheckInProgress));
            }
        }

        public ViewModelCommand SearchWordDocument
        {
            get
            {
                return new ViewModelCommand(
                    "..",
                    new RelayCommand(
                        () =>
                        {
                            var fileDialogResult = _fileDialogService.SelectFileName("Word Files|*.doc;*.docx");
                            if (fileDialogResult.OkClicked)
                            {
                                _context.WordFilePath = fileDialogResult.FilePath;
                            }
                        }));
            }
        }

        public ViewModelCommand TestInfo
        {
            get
            {
                return new ViewModelCommand(
                    "Test Info",
                    new RelayCommand(
                        async () =>
                        {
                            _informationPublishingService.Publish(InformationEntry.CreateInfo("Loading..", true));
                            await Task.Delay(10000);
                            _informationPublishingService.Publish(InformationEntry.CreateSuccess("Finished", false));
                        }));
            }
        }

        public Task InitializeAsync(WordRuleCheckViewModel context)
        {
            _context = context;
            return Task.CompletedTask;
        }
    }
}