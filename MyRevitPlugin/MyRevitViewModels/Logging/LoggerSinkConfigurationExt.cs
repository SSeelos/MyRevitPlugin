using Serilog;
using Serilog.Configuration;

namespace MyRevitViewModels
{
    public static class LoggerSinkConfigurationExt
    {
        public static void RevitSink(this LoggerSinkConfiguration cfg)
            => cfg.Sink<RevitSink>();

        public static LoggerConfiguration WPFTextblockSink(this LoggerSinkConfiguration cfg, string outputTemplate = "{Timestamp:yyyy-MM-dd HH:mm:ss} [{Level}]: {Message}")
            => cfg.Sink(new WPFTextblockSink(outputTemplate));

        public static LoggerConfiguration RevitErrorFileSink(this LoggerSinkConfiguration cfg, string logfilePath, string outputTemplate = "{Timestamp:yyyy-MM-dd HH:mm:ss} [{Level}]: {Message}")
            => cfg.Sink(new RevitErrorFileSink(logfilePath, outputTemplate));
    }
}
