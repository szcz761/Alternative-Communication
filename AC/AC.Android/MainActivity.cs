using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Android.Speech;
using Xamarin.Forms;
using AC.Services;
using Xamarin.Essentials;
using Android.Runtime;
using Plugin.Permissions;
using Android.Content.Res;
using Plugin.CurrentActivity;

namespace AC.Droid
{
    [Activity(Label = "AC", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity , IMessageSender
    {
        private readonly int VOICE = 10;
        public static MainActivity Instance { get; private set; }
        //public static AssetManager AssetManager { get; private set; }

        protected override void OnCreate(Bundle savedInstanceState)
        {

            CrossCurrentActivity.Current.Init(this, savedInstanceState);

            FFImageLoading.Forms.Platform.CachedImageRenderer.Init(true);
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;
           
            base.OnCreate(savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            LoadApplication(new App());
            Instance = this;
           
            //AssetManager = this.Assets;
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {

            PermissionsImplementation.Current.OnRequestPermissionsResult(requestCode, permissions, grantResults);

        Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
        protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
    {

        if (requestCode == VOICE)
        {
            if (resultCode == Result.Ok)
            {
                var matches = data.GetStringArrayListExtra(RecognizerIntent.ExtraResults);
                if (matches.Count != 0)
                {
                    string textInput = matches[0];
                    MessagingCenter.Send<IMessageSender, string>(this, "STT", textInput);
                }
                else
                {
                    MessagingCenter.Send<IMessageSender, string>(this, "STT", "No input");
                }

            }
        }
        base.OnActivityResult(requestCode, resultCode, data);
    }
    }
}