using Serilog.Configuration;

namespace MyRevitViewModels
{
    public static class LoggerSinkConfigurationExt
    {
        public static void RevitSink(this LoggerSinkConfiguration cfg)
            => cfg.Sink<RevitSink>();
    }
}
