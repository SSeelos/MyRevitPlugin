using CommunityToolkit.Mvvm.ComponentModel;
using Serilog;
using System.Windows.Input;

namespace MyRevitViewModels
{
    public class MainVM : ObservableObject
    {
        private string _myProperty;
        public string MyProperty
        {
            get => _myProperty;
            set => SetProperty(ref _myProperty, value);
        }
        public readonly ILogger Logger;

        private string myPropertyB = nameof(myPropertyB);
        public string MyPropertyB
        {
            get => myPropertyB;
            set => SetProperty(ref myPropertyB, value);
        }


        private string _logData;
        public string LogData
        {
            get => _logData;
            set => SetProperty(ref _logData, value);
        }



        public MainVM()
        {

        }
        public MainVM(ILogger logger)
        {
            this.Logger = logger;

            WPFTextblockSink.OnWPFTextBlockLog += WPFTextblockSink_OnWPFTextBlockLog;

            logger.Information("Hello from MainVM");

        }

        private void WPFTextblockSink_OnWPFTextBlockLog(string logData)
        {
            LogData = logData;
        }

        public ICommand MyCommand => new MyCommand_MainVM(this);
        public ICommand MyThrowingCommand => new MyThrowingCmd(this);
    }
}
