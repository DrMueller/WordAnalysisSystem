using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Mmu.Mlh.ApplicationExtensions.Areas.InformationHandling.Models;
using Mmu.Mlh.ApplicationExtensions.Areas.InformationHandling.Services;
using Mmu.Mlh.WpfExtensions.Areas.MvvmShell.Commands;
using Mmu.Mlh.WpfExtensions.Areas.ViewExtensions.Components.CommandBars.ViewData;
using Mmu.Mlh.WpfExtensions.Areas.ViewExtensions.Dialogs.FileDialogs.Services;
using Mmu.Was.WpfUI.Areas.Services;

namespace Mmu.Was.WpfUI.Areas.ViewModels.ViewModelCommands
{
    public class WordRuleCheckViewModelCommands : IViewModelCommandContainer<WordRuleCheckViewModel>
    {
        private readonly IFileDialogService _fileDialogService;
        private readonly IInformationPublishingService _informationPublishingService;
        private readonly IRuleCheckingService _ruleCheckingService;
        private WordRuleCheckViewModel _context;
        private bool _ruleCheckInProgress;

        public CommandsViewData Commands => new CommandsViewData(
            new List<ViewModelCommand>
            {
                CheckWordDocument
            });

        public ICommand CopyReportEntry
        {
            get
            {
                return new RelayCommand(
                    () =>
                    {
                        Clipboard.SetText(_context.SelectedEntry.ResultOverview);
                        _informationPublishingService.Publish(InformationEntry.CreateSuccess("Copied to Clipboard.", false));
                    },
                    () => _context.SelectedEntry != null);
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

        private ViewModelCommand CheckWordDocument
        {
            get
            {
                return new ViewModelCommand(
                    "Check document",
                    new RelayCommand(
                        async () =>
                        {
                            _ruleCheckInProgress = true;
                            _informationPublishingService.Publish(InformationEntry.CreateInfo("Checking rules..", true));
                            _context.RuleCheckResults = await _ruleCheckingService.CheckRulesAsync(_context.WordFilePath);
                            _informationPublishingService.Publish(InformationEntry.CreateInfo("Rules checked", false, 5));
                            _ruleCheckInProgress = false;
                        },
                        () => !string.IsNullOrEmpty(_context.WordFilePath) && !_ruleCheckInProgress));
            }
        }

        public WordRuleCheckViewModelCommands(IFileDialogService fileDialogService, IRuleCheckingService ruleCheckingService, IInformationPublishingService informationPublishingService)
        {
            _fileDialogService = fileDialogService;
            _ruleCheckingService = ruleCheckingService;
            _informationPublishingService = informationPublishingService;
        }

        public Task InitializeAsync(WordRuleCheckViewModel context)
        {
            _context = context;
            return Task.CompletedTask;
        }
    }
}