using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BootWPF.Helpers
{
    public class DelegateCommand : ICommand
    {
        #region Fields
        readonly Action<object> _execute;

        readonly Predicate<object> _canExecute;
        #endregion

        #region Constructs

        public DelegateCommand(Action<object> execute):this(execute, null)
        {

        }

        public DelegateCommand(Action<object> execute, Predicate<object> canExecute)
        {
            if (execute == null)
                throw new ArgumentNullException("execute");

            _execute = execute;
            _canExecute = canExecute;
        }

        #endregion

        #region ICommand members

        public bool CanExecute(object paramentr)
        {
            return _canExecute?.Invoke(paramentr) ?? true;
        }

        public void Execute(object parameter)
        {
            _execute(parameter);
        }

        public event EventHandler CanExecuteChanged
        {
            add
            {
                CommandManager.RequerySuggested += value;
            }
            remove
            {
                CommandManager.RequerySuggested -= value;
            }
        }

        #endregion
    }
}
