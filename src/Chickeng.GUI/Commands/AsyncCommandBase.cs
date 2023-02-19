using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Chickeng.GUI.Commands
{
    public abstract class AsyncCommandBase : CommandBase
    {
        private bool _isExecuting;
        private bool IsExecuting
        {
            get
            {
                return _isExecuting;
            }
            set
            {
                _isExecuting = value;
                OnCanExecutedChanged();
            }
        }

        public override bool CanExecute(object? parameter)
        {
            return !IsExecuting && base.CanExecute(parameter);
        }

        public override async void Execute(object? parameter)
        {
            IsExecuting = true;

            try
            {
                await ExecuteAsync(parameter);
            }
            finally
            {
                IsExecuting = false;
            }
        }

        public abstract Task ExecuteAsync(object? parameter);
    }

    public class AsyncCommand : ICommand
    {
        public event EventHandler? CanExecuteChanged;
        private Func<object?, Task> _executorAsync;
        private bool _isExecuted;
        private Func<object?, bool> _canExecute;
        private bool IsExecuted
        {
            get
            {
                return _isExecuted;
            }
            set
            {
                _isExecuted = value;
                OnCanExecutedChanged();
            }
        }
        public AsyncCommand(Func<object?, Task> executorAsync)
        {
            _executorAsync = executorAsync;
            _canExecute = (@param) => true;
        }
        public AsyncCommand(Func<object?, Task> executorAsync, Func<object?, bool> canExecute)
        {
            _executorAsync = executorAsync;
            _canExecute = canExecute;
        }
        public bool CanExecute(object? parameter)
        {
            return !IsExecuted && _canExecute.Invoke(parameter);
        }

        public async void Execute(object? parameter)
        {
            IsExecuted = true;
            try
            {
                await _executorAsync.Invoke(parameter);
            }
            finally
            {
                IsExecuted = false;
            }
        }

        protected void OnCanExecutedChanged()
        {
            CanExecuteChanged?.Invoke(this, new EventArgs());
        }
    }
}
