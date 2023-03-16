using Chickeng.GUI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chickeng.GUI.Stores
{
    public class NavigationStore
    {
        private ViewModelBase? _currentViewModel;
        private Stack<ViewModelBase> _viewModelStack;
        public event Action? CurrentViewModelChanged;
        public NavigationStore()
        {
            _viewModelStack = new Stack<ViewModelBase>();
        }
        public ViewModelBase CurrentViewModel 
        { 
            get => _currentViewModel ?? throw new NullReferenceException("CurrentViewModel was null"); 
            set
            {
                PushToStackViewModel(_currentViewModel);
                _currentViewModel = value;
                OnCurrentViewModelChanged();
            }
        }

        public bool HasPreviousModelView => _viewModelStack.Count > 0;

        public void ToPreviousViewModel()
        {
            if (_viewModelStack.Count > 0)
            {
                _currentViewModel = _viewModelStack.Pop();
                OnCurrentViewModelChanged();
            }
        }

        public void OnCurrentViewModelChanged()
        {
            CurrentViewModelChanged?.Invoke();
        }

        private void PushToStackViewModel(ViewModelBase? currentViewModel)
        {
            if (currentViewModel == null) 
                return;
            _viewModelStack.Push(currentViewModel);
        }
    }
}
