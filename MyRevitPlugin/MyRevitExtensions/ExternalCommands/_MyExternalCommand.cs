using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;

namespace MyRevitPlugin
{
    public abstract class _MyExternalCommand : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            try
            {
                TryExecute(commandData);
            }
            catch (Exception ex)
            {
                TaskDialog.Show(ex.GetType().Name, $"{ex.Message}{Environment.NewLine}{ex.StackTrace}");
                return Result.Failed;
            }

            return Result.Succeeded;
        }
        /// <summary>
        /// try execute (catch exception)
        /// </summary>
        public abstract void TryExecute(ExternalCommandData commandData);
    }
}
