using System.IO;

namespace WixSharp
{
    public static class StringExt
    {
        public static StringReader NewStringReader(this string str)
            => new StringReader(str);
    }
}
