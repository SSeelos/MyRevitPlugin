using Serilog.Core;
using Serilog.Events;
using Serilog.Formatting;
using Serilog.Formatting.Display;
using System.IO;

namespace MyRevitViewModels
{
    public class RevitErrorFileSink : ILogEventSink
    {
        private readonly string _logFilePath;
        private readonly ITextFormatter _textFormatter;

        public RevitErrorFileSink(string logFilePath, string outputTemplate)
        {
            _logFilePath = logFilePath;
            _textFormatter = new MessageTemplateTextFormatter(outputTemplate, null);
        }

        public void Emit(LogEvent logEvent)
        {
            if (logEvent.Level < LogEventLevel.Error)
                return;

            string message = $"{logEvent.RenderMessage()}";
            using (StringWriter writer = new StringWriter())
            {
                _textFormatter.Format(logEvent, writer);
                message = $"{writer.ToString()}\n";
            }
            string directory = Path.GetDirectoryName(_logFilePath);
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }
            File.AppendAllText(_logFilePath, message);
        }
    }
}
