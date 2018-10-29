using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using AC.Views;

[assembly: XamlCompilation (XamlCompilationOptions.Compile)]
namespace AC
{
    public partial class App : Application
    {

        public App()
        {
            try
            {
                InitializeComponent();
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }

            MainPage = new NavigationPage(new MainPage());
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
