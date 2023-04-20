using System.IO;
using System.Reflection;

namespace MyRevitPlugin
{
    public static class ObjectExt
    {
        public static Assembly GetAssembly(this object subject)
            => subject.GetType().Assembly;
        public static string GetDirectory(this object subject)
            => Path.GetDirectoryName(subject.GetAssembly().Location);

    }
}
