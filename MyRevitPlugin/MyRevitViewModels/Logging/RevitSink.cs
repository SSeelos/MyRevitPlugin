using Autodesk.Revit.UI;
using Serilog.Core;
using Serilog.Events;

namespace MyRevitViewModels
{
    public class RevitSink : ILogEventSink
    {
        public void Emit(LogEvent logEvent)
        {
            if (logEvent.Level != LogEventLevel.Error)
                return;

            try
            {
                var msg = logEvent.RenderMessage();
                TaskDialog.Show(logEvent.Level.ToString(), msg);
            }
            catch
            {
                //...
            }
        }
    }
}
