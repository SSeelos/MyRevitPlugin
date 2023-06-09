﻿using Autodesk.Revit.UI;
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
                if(logEvent.Level == LogEventLevel.Error)
                {
                    TaskDialog.Show(logEvent.Level.ToString(), msg);
                }
            }
            catch
            {
                //...
            }
        }
    }
}
