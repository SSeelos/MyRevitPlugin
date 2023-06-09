﻿namespace MyRevitViewModels
{
    public class MyCommand_MainVM : _Command<MainVM>
    {
        public MyCommand_MainVM(MainVM observable)
            : base(observable)
        {
            OnException += LogException;
        }

        private void LogException(System.Exception exception)
        {
            this.observable.Logger.Error(exception, "Error from MyCommand_MainVM");
        }

        protected override void TryExecute(object parameter)
        {
            observable.Logger.Information("Hello from MyCommand_MainVM");
        }
    }
}
