using Chickeng.GUI.Commands;
using Chickeng.GUI.Stores;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Chickeng.GUI.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private readonly NavigationStore _navigationStore;
        private readonly NavigationService<HomeViewModel> _navHome;
        public MainViewModel(NavigationStore navigationStore, 
            NavigationService<HomeViewModel> navHome)
        {
            _navigationStore = navigationStore;
            _navigationStore.CurrentViewModelChanged += OnCurrentViewModelChanged;
            _navHome = navHome;

            QuitCommand = new AsyncCommand(QuitActionAsync);
            BackToHomeCommand = new AsyncCommand(BackToHomeActionAsync);
        }

        private void OnCurrentViewModelChanged()
        {
            OnPropertyChanged(nameof(CurrentViewModel));
        }

        #region Commands
        public ICommand BackToHomeCommand { get; }
        private Task BackToHomeActionAsync(object? @param)
        {
            if (CurrentViewModel.GetType() != typeof(HomeViewModel))
                _navHome.Navigate();
            return Task.CompletedTask;
        }

        public ICommand QuitCommand { get; }
        private Task QuitActionAsync(object? @param)
        {
            var dialog = MessageBox.Show("Are you sure?", "Exit Chickeng", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (dialog == MessageBoxResult.No)
            {
                return Task.CompletedTask;
            }
            Application.Current.Shutdown();
            return Task.CompletedTask;
        }
        #endregion
        public double EffectWidth { get => 40; }
        public double EffectHeight { get => 40; }
        public double OriginWidth { get => 35; }
        public double OriginHeight { get => 35; }
        public ViewModelBase CurrentViewModel => _navigationStore.CurrentViewModel;
    }
}
