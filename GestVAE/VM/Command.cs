﻿using GestVAEcls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace GestVAE.VM
{
    public class SaveCommand : RelayCommand<Candidat>
    {

        public SaveCommand(Action<Candidat> pAction, Predicate<Candidat> pCanExecute = null) : base(pAction, pCanExecute)
        {

        }



    }

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

 
    }



