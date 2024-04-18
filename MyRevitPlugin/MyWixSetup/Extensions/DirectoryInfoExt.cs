using System.IO;

namespace WixSharp
{
    public static class DirectoryInfoExt
    {

        public static string ToFilePath(this DirectoryInfo directory, string fullFileName)
            => $@"{directory.FullName}\{fullFileName}";
        public static FileInfo NewFileInfo(this DirectoryInfo directory, string fullFileName)
            => new FileInfo(directory.ToFilePath(fullFileName));

    }
}
