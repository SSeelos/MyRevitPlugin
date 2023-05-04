using CommunityToolkit.Mvvm.ComponentModel;
using Serilog;
using System.Windows.Input;

namespace MyRevitViewModels
{
    public class MainVM : ObservableObject
    {
        [ObservableProperty]
        private string myObservableProperty;
        public readonly ILogger Logger;

        private string myPropertyB = nameof(myPropertyB);
        public string MyPropertyB
        {
            get => myPropertyB;
            set => SetProperty(ref myPropertyB, value);
        }


        public MainVM()
        {

        }
        public MainVM(ILogger logger)
        {
            this.Logger = logger;

            logger.Information("Hello from MainVM");

        }
        public ICommand MyCommand => new MyCommand_MainVM(this);
    }
}
