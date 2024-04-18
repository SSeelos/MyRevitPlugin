using System.IO;

namespace WixSharp
{
    public static class FileInfoExt
    {
        public static void Write(this FileInfo file, string content)
        {
            System.IO.File.WriteAllText(file.FullName, content);
        }
    }
}
