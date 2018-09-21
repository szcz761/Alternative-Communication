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
        ItemsViewModel viewModel;
        int Column = 3;
        public ItemsPage()
        {
            InitializeComponent();
            viewModel = new ItemsViewModel();
            viewModel.LoadItemsCommand.Execute(null);
            InitializeGird();
        }

        private void InitializeGird()
        {
            for (int i = 0; i < Column; i++)
                girdLayout.ColumnDefinitions.Add(new ColumnDefinition());

            for (int i = 0; i < viewModel.Items.Count / Column; i++)
                girdLayout.RowDefinitions.Add(new RowDefinition());

            for (int j = 0; j < viewModel.Items.Count / Column; j++)
                for (int i = 0; i < Column; i++)
                    girdLayout.Children.Add(GetButtonWithProperParams(i, j), i, j);
        }

        private Button GetButtonWithProperParams(int i, int j)
        {
            Item actualItem = viewModel.Items[i + (j * Column)];
            Button button = new Button { Image = actualItem.Icon.Source.ToString().Remove(0, 6) };//Source::toString metod return "file: <name>" so we have to delete "file: "
            button.Command = new Command<Item>(Butoon_Clicked); 
            button.CommandParameter = actualItem;
            return button;
        }

        async void Butoon_Clicked(Item item) {

            if (item == null)
                return;

            await Navigation.PushAsync(new ItemDetailPage(new ItemDetailViewModel(item)));
        }

        async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var item = args.SelectedItem as Item;
            if (item == null)
                return;

            await Navigation.PushAsync(new ItemDetailPage(new ItemDetailViewModel(item)));

            // Manually deselect item.
            //ItemsListView.SelectedItem = null;
        }

        async void AddItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new NewItemPage()));
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.Items.Count == 0)
                viewModel.LoadItemsCommand.Execute(null);
        }
    }
}