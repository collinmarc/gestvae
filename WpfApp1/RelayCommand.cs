using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace WpfApp1
{
    public class RelayCommand<T> : ICommand
    {
        #region Fields

        private readonly Action<T> _execute = null;
        private readonly Predicate<T> _canExecute = null;

        #endregion

        #region Constructors

        /// <summary>
        /// Creates a new command that can always execute.
        /// </summary>
        /// <param name="execute">The execution logic.</param>
        public RelayCommand(Action<T> execute)
            : this(execute, null)
        {
        }

        /// <summary>
        /// Creates a new command with conditional execution.
        /// </summary>
        /// <param name="execute">The execution logic.</param>
        /// <param name="canExecute">The execution status logic.</param>
        public RelayCommand(Action<T> execute, Predicate<T> canExecute)
        {
            if (execute == null)
                throw new ArgumentNullException("execute");

            _execute = execute;
            _canExecute = canExecute;
        }

        #endregion

        #region ICommand Members

        public bool CanExecute(object parameter)
        {
            return _canExecute == null ? true : _canExecute((T)parameter);
        }

        public event EventHandler CanExecuteChanged
        {
            add
            {
                if (_canExecute != null)
                    CommandManager.RequerySuggested += value;
            }
            remove
            {
                if (_canExecute != null)
                    CommandManager.RequerySuggested -= value;
            }
        }

        public void Execute(object parameter)
        {
            _execute((T)parameter);
        }

        #endregion
    }

    public class RAZPersonCommand : ICommand
    {
        private readonly Action<person> _execute = null;
        private readonly Predicate<person> _canexecute = null;


        public RAZPersonCommand(Action<person> pAction, Predicate<person> pCanExecute = null)
        {
            _execute = pAction;
            _canexecute = pCanExecute;
        }

        public bool CanExecute(object parameter)
        {
            //            person p = parameter as person;
            //            return (p != null);
            if (_canexecute == null)
            {
                return true;
            }
            else
            {
                person p = parameter as person;
                return _canexecute(p);
            }
        }

        public void Execute(object parameter)
        {
            person p = parameter as person;
            _execute(p);
        }

        public event EventHandler CanExecuteChanged
        {
            add
            {
                if (_canexecute != null)
                    CommandManager.RequerySuggested += value;
            }
            remove
            {
                if (_canexecute != null)
                    CommandManager.RequerySuggested -= value;
            }
        }

    }

}

