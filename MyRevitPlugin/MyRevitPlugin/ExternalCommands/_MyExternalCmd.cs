using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;

namespace MyRevitPlugin
{
    public abstract class _MyExternalCmd : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            try
            {
                TryExecute(commandData);
            }
            catch (Exception exception)
            {
                TaskDialog.Show(exception.GetType().Name, exception.Message);
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
