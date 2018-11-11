using AC.iOS;
using AC.Services;
using Foundation;

[assembly: Xamarin.Forms.Dependency(typeof(PackageNameIOS))]
namespace AC.iOS
{
    public class PackageNameIOS : IPackageName
    {

        public PackageNameIOS()
        {
        }

        public string[] PackageName()
        {
            return null;
        }

    }
}