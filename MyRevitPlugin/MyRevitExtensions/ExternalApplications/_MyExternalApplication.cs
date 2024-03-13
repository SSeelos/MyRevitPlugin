using Autodesk.Revit.UI;
using System;

namespace MyRevitPlugin
{
    public abstract class _MyExternalApplication : IExternalApplication
    {
        protected UIControlledApplication UIControlledApplication { get; private set; }
        protected UIApplication UIApplication
            => this.UIControlledApplication.GetUIApplication();
        protected abstract void TryOnStartup();
        public Result OnStartup(UIControlledApplication application)
        {
            this.UIControlledApplication = application;
            try
            {
                TryOnStartup();
            }
            catch (Exception ex)
            {
                TaskDialog.Show(ex.GetType().Name, $"{ex.Message}{Environment.NewLine}{ex.StackTrace}");
                return Result.Failed;
            }
            return Result.Succeeded;
        }
        protected virtual void TryOnShutdown() { }
        public Result OnShutdown(UIControlledApplication application)
        {
            this.UIControlledApplication = application;
            try
            {
                TryOnShutdown();
            }
            catch (Exception ex)
            {
                TaskDialog.Show(ex.GetType().Name, ex.Message);
                return Result.Failed;
            }
            return Result.Succeeded;
        }
    }
}
