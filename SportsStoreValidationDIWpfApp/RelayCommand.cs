using System;
using System.Windows.Input;

namespace SportStoreValidationDIWpfApp
{
  public class RelayCommand : ICommand
  {
    Action _targetExecuteMethod;
    Func<bool> _targetCanExecuteMethod;

    public RelayCommand(Action executeMethod) { _targetExecuteMethod = executeMethod; }

    public RelayCommand(Action executeMethod, Func<bool> canExecuteMethod)
    {
      _targetExecuteMethod = executeMethod;
      _targetCanExecuteMethod = canExecuteMethod;
    }

    public void RaiseCanExecuteChanged()
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

    public RelayCommand(Action<T> executeMethod) { _targetExecuteMethod = executeMethod; }

    public RelayCommand(Action<T> executeMethod, Func<T, bool> canExecuteMethod)
    {
      _targetExecuteMethod = executeMethod;
      _targetCanExecuteMethod = canExecuteMethod;
    }

    public void RaiseCanExecuteChanged()
    {
      CanExecuteChanged(this, EventArgs.Empty);
    }

    #region ICommand Members
    public event EventHandler CanExecuteChanged = delegate { };

    public bool CanExecute(object parameter)
    {
      if (_targetCanExecuteMethod != null)
      {
        T tempParameter = (T)parameter;
        return _targetCanExecuteMethod(tempParameter);
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

