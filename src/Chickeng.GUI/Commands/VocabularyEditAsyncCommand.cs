using Chickeng.GUI.Stores;
using Chickeng.GUI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chickeng.GUI.Commands
{
    public class VocabularyEditAsyncCommand : AsyncCommandBase
    {
        private readonly NavigationService<VocabularyEditViewModel> _navigationService;
        public VocabularyEditAsyncCommand(NavigationService<VocabularyEditViewModel> navigationService)
        {
            _navigationService = navigationService;
        }
        public override Task ExecuteAsync(object? parameter)
        {
            _navigationService.Navigate();
            return Task.CompletedTask;
        }
    }
}
