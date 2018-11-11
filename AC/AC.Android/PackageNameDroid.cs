using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Android.Speech;
using Xamarin.Forms;
using AC.Services;
using Xamarin.Essentials;
using Android.Runtime;
using AC.Droid;
using Android.Content.Res;

[assembly: Xamarin.Forms.Dependency(typeof(PackageNameDroid))]
namespace AC.Droid
{
    public class PackageNameDroid :  IPackageName
    {
        public PackageNameDroid()
        {
        }

        public string[] PackageName()
        {
            /*AssetManager assets = MainActivity.AssetManager;
            var listAssets = assets.List("/czynnosci");
            foreach (var file in listAssets)
                Android.Util.Log.Info("MyLogTag", file);
            return listAssets;*/
            return null;
        }
    }
}