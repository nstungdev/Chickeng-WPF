using Chickeng.GUI.Commands;
using Chickeng.GUI.Stores;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Chickeng.GUI.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        #region DI fields
        private readonly NavigationStore _navigationStore;
        private readonly NavigationService<HomeViewModel> _navHome;
        #endregion

        #region Normal fields
        private bool _hasPreviousView = false;
        #endregion
        public MainViewModel(NavigationStore navigationStore, 
            NavigationService<HomeViewModel> navHome)
        {
            // DI fields
            _navigationStore = navigationStore;
            _navigationStore.CurrentViewModelChanged += OnCurrentViewModelChanged;
            _navHome = navHome;

            // commands
            QuitCommand = new AsyncCommand(QuitActionAsync);
            BackToHomeCommand = new AsyncCommand(BackToHomeActionAsync);
            PreviousViewCommand = new AsyncCommand(BackToPreviousView);
        }

        #region Event Actions
        private void OnCurrentViewModelChanged()
        {
            HasPreviousView = _navigationStore.HasPreviousModelView;
            OnPropertyChanged(nameof(CurrentViewModel));
        }
        #endregion

        #region Commands
        public ICommand BackToHomeCommand { get; }
        public ICommand PreviousViewCommand { get; }
        public ICommand QuitCommand { get; }
        #endregion

        #region Actions
        private Task BackToHomeActionAsync(object? @param)
        {
            if (CurrentViewModel.GetType() != typeof(HomeViewModel))
                _navHome.Navigate();
            return Task.CompletedTask;
        }
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

        private Task BackToPreviousView(object? @param)
        {
            _navigationStore.ToPreviousViewModel();
            return Task.CompletedTask;
        }
        #endregion

        #region Properties
        public double EffectWidth { get => 30; }
        public double EffectHeight { get => 30; }
        public double OriginWidth { get => 25; }
        public double OriginHeight { get => 25; }
        public bool HasPreviousView
        {
            get => _hasPreviousView;
            set
            {
                _hasPreviousView = value;
                OnPropertyChanged(nameof(HasPreviousView));
            }
        }
        public ViewModelBase CurrentViewModel => _navigationStore.CurrentViewModel;
        #endregion
    }
}
