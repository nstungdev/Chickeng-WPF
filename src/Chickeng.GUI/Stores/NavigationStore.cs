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
        public event Action? CurrentViewModelChanged;

        public ViewModelBase CurrentViewModel 
        { 
            get => _currentViewModel ?? throw new NullReferenceException("CurrentViewModel was null"); 
            set
            {
                _currentViewModel = value;
                OnCurrentViewModelChanged();
            }
        }

        public void OnCurrentViewModelChanged()
        {
            CurrentViewModelChanged?.Invoke();
        }
    }
}
