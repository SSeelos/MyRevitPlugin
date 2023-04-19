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
                Execute(commandData);
            }
            catch (Exception exception)
            {
                TaskDialog.Show(exception.GetType().Name, exception.Message);
                return Result.Failed;
            }

            return Result.Succeeded;
        }
        public abstract void Execute(ExternalCommandData commandData);
    }
}
