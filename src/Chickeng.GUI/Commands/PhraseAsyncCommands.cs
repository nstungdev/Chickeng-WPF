using Chickeng.GUI.Stores;
using Chickeng.GUI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chickeng.GUI.Commands
{
    public class PhraseTableViewAsyncCommands : AsyncCommandBase
    {
        private readonly NavigationService<PhraseTableViewModel> _navigationService;

        public PhraseTableViewAsyncCommands(NavigationService<PhraseTableViewModel> navigationService)
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
