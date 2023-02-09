using Chickeng.GUI.Stores;
using Chickeng.GUI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chickeng.GUI.Commands
{
    public class PhraseEditAsyncCommand : AsyncCommandBase
    {
        private readonly NavigationService<PhraseEditViewModel> _navigationService;
        public PhraseEditAsyncCommand(NavigationService<PhraseEditViewModel> navigationService)
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
