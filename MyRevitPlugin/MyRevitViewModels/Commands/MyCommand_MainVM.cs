namespace MyRevitViewModels
{
    public class MyCommand_MainVM : _Command<MainVM>
    {
        public MyCommand_MainVM(MainVM observable)
            : base(observable)
        {
        }

        protected override void TryExecute(object parameter)
        {
            observable.Logger.Information("Hello from MyCommand_MainVM");
        }
    }
}
