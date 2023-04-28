using System;
using System.Windows.Input;

namespace MyRevitViewModels
{
    public abstract class _Command : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public virtual bool CanExecute(object parameter) => true;

        protected abstract void TryExecute(object parameter);
        public void Execute(object parameter)
        {
            try
            {
                TryExecute(parameter);
            }
            catch (Exception)
            {
                //todo?
            }
        }

    }
}
