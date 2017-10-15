using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BasicSportStoreWpfApp
{
    public class RelayCommand : ICommand
    {
        Action _targetExecuteMethod;
        Func<bool> _targetCanExecuteMethod;

        public RelayCommand(Action executeMethod)
        {
            _targetExecuteMethod = executeMethod;
        }

        public RelayCommand(Action executeMethod, Func<bool> CanExecuteMethod)
        {
            _targetExecuteMethod = executeMethod;
            _targetCanExecuteMethod = CanExecuteMethod;
        }

        public void RasieCanExecuteChange()
        {
            CanExecuteChanged(this, EventArgs.Empty);
        }
        #region ICommand Members
        public event EventHandler CanExecuteChanged = delegate { };
        public bool CanExecute(object parameter)
        {
            if (_targetCanExecuteMethod != null)
            {
                return _targetCanExecuteMethod();
            }
            if (_targetExecuteMethod != null)
            {
                return true;
            }
            return false;
        }

        public void Execute(object parameter)
        {
            if (_targetExecuteMethod != null)
            {
                _targetExecuteMethod();
            }
        }
        #endregion
    }

    public class RelayCommand<T> : ICommand
    {
        Action<T> _targetExecuteMethod;
        Func<T, bool> _targetCanExecuteMethod;

        public RelayCommand(Action<T> executeMethod)
        {
            _targetExecuteMethod = executeMethod;
        }

        public RelayCommand(Action<T> executeMethod, Func<T, bool> CanExecuteMethod)
        {
            _targetExecuteMethod = executeMethod;
            _targetCanExecuteMethod = CanExecuteMethod;
        }

        public void RasieCanExecuteChange()
        {
            CanExecuteChanged(this, EventArgs.Empty);
        }
        #region ICommand Members
        public event EventHandler CanExecuteChanged = delegate { };
        public bool CanExecute(object parameter)
        {
            if (_targetCanExecuteMethod != null)
            {
                T tempParam = (T)parameter;
                return _targetCanExecuteMethod(tempParam);
            }
            if (_targetExecuteMethod != null)
            {
                return true;
            }
            return false;
        }

        public void Execute(object parameter)
        {
            if (_targetExecuteMethod != null)
            {
                _targetExecuteMethod((T)parameter);
            }
        }
        #endregion
    }
}
