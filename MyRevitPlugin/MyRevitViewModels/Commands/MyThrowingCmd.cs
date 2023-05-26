namespace MyRevitViewModels
{
    public class MyThrowingCmd : _Command<MainVM>
    {
        public MyThrowingCmd(MainVM mainVM)
            : base(mainVM)
        {
            this.observable = mainVM;
            this.OnException += LogException;
        }

        private void LogException(System.Exception exception)
        {
            this.observable.Logger.Error(exception, "Error from MyCommand_MainVM");
        }
        protected override void TryExecute(object parameter)
        {
            throw new System.NotImplementedException();
        }
    }
}
