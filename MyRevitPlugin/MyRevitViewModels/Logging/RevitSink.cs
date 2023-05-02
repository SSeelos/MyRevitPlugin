using Autodesk.Revit.UI;
using Serilog.Core;
using Serilog.Events;

namespace MyRevitViewModels
{
    public class RevitSink : ILogEventSink
    {
        public void Emit(LogEvent logEvent)
        {
            var msg = logEvent.RenderMessage();
            try
            {
                TaskDialog.Show(logEvent.Level.ToString(), msg);
            }
            catch
            {
                //...
            }
        }
    }
}
