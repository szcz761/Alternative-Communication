using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Plugin.Media;
using Plugin.Media.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using AC.ViewModels;
using AC.Models;
using FFImageLoading.Forms;
using System.IO;

namespace AC.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewGroupPage : ContentPage
    {
        ItemsViewModel ViewModel;
        public NewGroupPage(ItemsViewModel viewModel)
        {
            InitializeComponent();
            ViewModel = viewModel;

          

            PickPhoto.Clicked += async (sender, args) =>
                {
                    if (!CrossMedia.Current.IsPickPhotoSupported)
                    {
                        DisplayAlert("Photos Not Supported", ":( Permission not granted to photos.", "OK");
                        return;
                    }
                    var file = await CrossMedia.Current.PickPhotoAsync(new PickMediaOptions
                    {
                        PhotoSize = PhotoSize.Medium,

                    });

                    if (file == null)
                        return;

                    image.Source = file.Path;


                };
        }
        void Ok_clicked(object sender, EventArgs e)
        {
            if (image.Source == null)
                return;
            var item = new GroupOfItems { Image =new Image { Source = image.Source } , Title = TextField.Text};
            DisplayAlert("Dodano Grupe!", "Prawdopodobnie prawidłowo dodano grupe", "OK");
            MessagingCenter.Send(this, "AddGroup", item);
        }

    }
}
