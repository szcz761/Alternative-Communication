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
    public partial class NewItemPage : ContentPage
    {
        ItemsViewModel ViewModel;
        public NewItemPage(ItemsViewModel viewModel)
        {
            InitializeComponent();
            ViewModel = viewModel;

            PickerGroup.ItemsSource = ViewModel.Groups;

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
            if (PickerGroup.SelectedIndex == -1 || image.Source == null)
                return;
            var item = new Item { Id = Guid.NewGuid().ToString(), WordType = WordType.noun, Text = TextField.Text, Description = "", Image = new CachedImage { Source = image.Source }, WhichGroup = PickerGroup.SelectedIndex };
            DisplayAlert("Dodano Obrazek!", "Prawdopodobnie prawidłowo dodano Piktogram", "OK");
            MessagingCenter.Send(this, "AddItem", item);
        }

    }
}
