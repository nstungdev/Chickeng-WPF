using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Chickeng.GUI.Commands
{
    public class QuitApplicationAsyncCommand : AsyncCommandBase
    {
        public override Task ExecuteAsync(object? parameter)
        {
            Application.Current.Shutdown();
            return Task.CompletedTask;
        }
    }
}
