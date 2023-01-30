using Chickeng.GUI.Stores;
using Chickeng.GUI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chickeng.GUI.Commands
{
    public class HomeAsyncCommands : AsyncCommandBase
    {
        private readonly NavigationService<HomeViewModel> _navigationService;
        public HomeAsyncCommands(NavigationService<HomeViewModel> navigationService)
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
