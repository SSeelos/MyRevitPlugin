using System;
using System.IO;
using System.Reflection;

namespace MyRevitPlugin
{
    public static class AssemblyExt
    {
        public static Assembly LoadDll(string dllPath)
        {
            Assembly dllAssembly = null;
            try
            {
                byte[] dllBytes = File.ReadAllBytes(dllPath);
                dllAssembly = Assembly.Load(dllBytes);

            }
            catch (BadImageFormatException) { /*ignore invalid dll*/ }
            catch (Exception)
            {
                throw;
            }

            return dllAssembly;
        }
    }
}
