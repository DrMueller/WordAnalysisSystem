using Mmu.Mlh.WpfExtensions.Areas.MvvmShell.Commands;
using Mmu.Mlh.WpfExtensions.Areas.ViewExtensions.Dialogs.FileDialogs.Services;
using Mmu.Was.Application.Areas.RuleChecking;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Mmu.Was.WpfUI.Areas.Word.ViewModels.ViewModelCommands
{
    public class WordRuleCheckViewModelCommands : IViewModelCommandContainer<WordRuleCheckViewModel>
    {
        private WordRuleCheckViewModel _context;
        private readonly IFileDialogService _fileDialogService;
        private readonly IRuleCheckingService _ruleCheckingService;

        public WordRuleCheckViewModelCommands(IFileDialogService fileDialogService, IRuleCheckingService ruleCheckingService)
        {
            _fileDialogService = fileDialogService;
            _ruleCheckingService = ruleCheckingService;
        }

        public ViewModelCommand SearchWordDocument
        {
            get
            {
                return new ViewModelCommand("..", new RelayCommand(() =>
                {
                    var fileDialogResult = _fileDialogService.SelectFileName("Word Files|*.doc;*.docx");
                    if (fileDialogResult.OkClicked)
                    {
                        _context.WordFilePath = fileDialogResult.FilePath;
                    }
                }));
            }
        }

        public ViewModelCommand CheckWordDocument
        {
            get
            {
                return new ViewModelCommand("Check document", new RelayCommand(() =>
                {
                    try
                    {
                        _context.RuleCheckResults = _ruleCheckingService
                        .CheckRules(_context.WordFilePath)
                        .Select(dto => new RuleCheckResultViewModel(dto.RuleCheckPassed, dto.ResultOverview, dto.Details))
                        .ToList();
                    }
                    catch (Exception ex)
                    {
                        Debugger.Break();
                    }

                }, () => !string.IsNullOrEmpty(_context.WordFilePath)));
            }
        }

        public Task InitializeAsync(WordRuleCheckViewModel context)
        {
            _context = context;
            return Task.CompletedTask;
        }
    }
}
