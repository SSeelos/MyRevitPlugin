using Serilog.Core;
using Serilog.Events;
using Serilog.Formatting;
using Serilog.Formatting.Display;
using System;
using System.IO;

namespace MyRevitViewModels
{
    public class WPFTextblockSink : ILogEventSink
    {
        public string LogData;
        public static event Action<string> OnWPFTextBlockLog;
        private readonly ITextFormatter _textFormatter;

        public WPFTextblockSink(string outputTemplate)
        {
            _textFormatter = new MessageTemplateTextFormatter(outputTemplate, null);
        }

        public void Emit(LogEvent logEvent)
        {
            string message = logEvent.RenderMessage();
            using (StringWriter writer = new StringWriter())
            {
                _textFormatter.Format(logEvent, writer);
                message = writer.ToString();
            }
            LogData = $"{message}\n{LogData}";
            OnWPFTextBlockLog?.Invoke(LogData);
        }
    }
}
