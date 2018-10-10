using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using AC.Models;
using AC.Views;
using AC.ViewModels;

namespace AC.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ItemsPage : ContentPage
    {
     /*   ItemsViewModel viewModel = new ItemsViewModel();
        int Column = 3;
   
    
        public ItemsPage()
        { 
            InitializeComponent();
            viewModel.LoadItemsCommand.Execute(null);
            InitializeGird();
        }

        private void InitializeGird()
        {
            girdLayout.RowDefinitions.Add(new RowDefinition());
            for (int i = 0; i < Column; i++)
                girdLayout.ColumnDefinitions.Add(new ColumnDefinition());

            for (int i = 0; i < viewModel.Groups.Count / Column; i++)
                girdLayout.RowDefinitions.Add(new RowDefinition());

            for (int j = 0; j < viewModel.Groups.Count / Column; j++)
                for (int i = 0; i < Column; i++)
                    girdLayout.Children.Add(GetImageWithProperParams(i, j), i, j);
        }

        private Image GetImageWithProperParams(int i, int j)
        {
            var tapGestureRecognizer = new TapGestureRecognizer();
            var currentIndex = i + (j * Column);

            tapGestureRecognizer.Tapped += async (s, e) => {
                await Navigation.PushAsync(new ItemDetailPage(new ItemDetailViewModel(viewModel.Groups[currentIndex])));
            };
            viewModel.Groups[currentIndex].Image.GestureRecognizers.Add(tapGestureRecognizer);

            return viewModel.Groups[currentIndex].Image;
        }

        async void AddItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new NewItemPage()));
        }

        protected override void OnAppearing()
        {
            //girdLayout.Children.Clear();
            base.OnAppearing();

            if (viewModel.Groups.Count == 0)
                viewModel.LoadItemsCommand.Execute(null);
        }

       /* protected override void OnSizeAllocated(double width, double height)
        {
            base.OnSizeAllocated(width, height);
            Column = (int)width/30;
        }*/
    }
}