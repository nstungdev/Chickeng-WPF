using Chickeng.GUI.Commands;
using Chickeng.GUI.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Chickeng.GUI.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private readonly NavigationStore _navigationStore;
        public MainViewModel(NavigationStore navigationStore)
        {
            _navigationStore = navigationStore;
            QuitCommand = new QuitApplicationAsyncCommand();
            _navigationStore.CurrentViewModelChanged += OnCurrentViewModelChanged;
        }

        private void OnCurrentViewModelChanged()
        {
            OnPropertyChanged(nameof(CurrentViewModel));
        }
        public ICommand QuitCommand { get; set; }
        public ViewModelBase CurrentViewModel => _navigationStore.CurrentViewModel;
    }
}
