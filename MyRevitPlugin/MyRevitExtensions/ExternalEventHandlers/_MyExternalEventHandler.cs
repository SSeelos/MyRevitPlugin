using Autodesk.Revit.UI;
using System;

namespace MyRevitExtensions
{
    public abstract class _MyExternalEventHandler : IExternalEventHandler
    {
        private readonly ExternalEvent _event;
        public _MyExternalEventHandler()
        {
            _event = ExternalEvent.Create(this);
        }
        public virtual string GetName()
            => GetType().Name;
        /// <summary>
        /// Calling <see cref="Autodesk.Revit.UI.ExternalEvent.Raise"/>
        /// will prompt Revit to call <see cref="Execute"/>
        /// </summary>
        public virtual ExternalEventRequest Raise()
            => _event.Raise();
        protected abstract void TryExecute(UIApplication app);
        /// <summary>
        /// Gets called by Revit
        /// after calling <see cref="Autodesk.Revit.UI.ExternalEvent.Raise"/>
        /// </summary>
        public void Execute(UIApplication app)
        {
            try
            {
                TryExecute(app);
            }
            catch (Exception e)
            {
                TaskDialog.Show(e.GetType().Name, e.Message);
            }
        }

    }
}
