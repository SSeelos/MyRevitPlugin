using MyRevitExtensions.AddInFile;
using System.Collections.Generic;

namespace MyRevitPlugin
{
    public static class AddInDef
    {
        public static RevitAddIns GetAddIns(string directory)
            => new RevitAddIns()
            {
                AddIns = new List<AddIn>()
                {
                    GetAddIn(directory)
                }
            };
        public static AddIn GetAddIn(string directory = null)
            => new Application()
            {
                Name = nameof(MyExternalApp),
                Assembly = $@"{directory ?? nameof(MyRevitPlugin)}\{nameof(MyRevitPlugin)}.dll",
                AddInId = MyExternalApp.AddInId,
                //FullClassName = typeof(MyExternalApp).FullName,
                FullClassName = $"{nameof(MyRevitPlugin)}.{nameof(MyExternalApp)}",
                VendorId = "MyVendorId",
                VendorDescription = "MyVendorDescription"
            };

    }
}
