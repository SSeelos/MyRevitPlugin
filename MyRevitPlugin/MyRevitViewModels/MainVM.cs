using CommunityToolkit.Mvvm.ComponentModel;
using Serilog;
using System.Windows.Input;

namespace MyRevitViewModels
{
    public class MainVM : ObservableObject
    {
        [ObservableProperty]
        string myProperty = nameof(myProperty);
        public readonly ILogger Logger;


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
