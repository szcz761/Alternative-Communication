using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using System.Collections.Generic;
using AC.ViewModels;
using AC.Models;
using System.Collections.ObjectModel;
using AC.Services;

namespace AC.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
    {
        ItemsViewModel viewModel;
        int Column = 3;
        public MainPage()
        {
            BindingContext = viewModel = new ItemsViewModel();
            InitializeComponent();
            viewModel.LoadItemsCommand.Execute(null);
            InitializeTabs();
            UpdateGrid(viewModel.Groups[0].Items);
            MessagingCenter.Subscribe<ItemsViewModel, string>(this, "UpdateText", (obj, text) => {
                    TextField.Text = text;
            });
        }

        private void InitializeTabs()
        {
            foreach (var group in viewModel.Groups)
            {
                SwitchTab.Children.Add(new Label { Text = group.Title ,FontSize=17, TextColor=Color.White});
            }
        }

        private void SegmentedControl_ItemTapped(object sender, int groupIterator)
        {
            UpdateGrid(viewModel.Groups[groupIterator].Items);
        }

        private void UpdateGrid(List<Item> group)
        {
            CleanGirdLayout();

            for (int i = 0; i < Column; i++)
                ContentGridLayout.ColumnDefinitions.Add(new ColumnDefinition());

            for (int i = 0; i < group.Count / Column; i++)
                ContentGridLayout.RowDefinitions.Add(new RowDefinition());

            for (int j = 0; j < group.Count / Column; j++)
                for (int i = 0; i < Column; i++)
                    ContentGridLayout.Children.Add(GetImageWithProperParams(group, i + (j * Column)), i, j);

            if (group.Count % Column != 0)           
                AddExtraRow(group);
        }

        private void AddExtraRow(List<Item> group)
        {
            ContentGridLayout.RowDefinitions.Add(new RowDefinition());
            int row = ContentGridLayout.RowDefinitions.Count - 1;
            for (int i = 0; i < group.Count % Column; i++)
                ContentGridLayout.Children.Add(GetImageWithProperParams(group, i + row * Column), i, row);
        }

        private void CleanGirdLayout()
        {
            ContentGridLayout.Children.Clear();
            ContentGridLayout.ColumnDefinitions.Clear();
            ContentGridLayout.RowDefinitions.Clear();
        }
        async void AddItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NewItemPage());
        }

        async void AddGroup_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NewItemPage());
        }

        private Image GetImageWithProperParams(List<Item> group, int currentIndex)
        {
            var tapGestureRecognizer = new TapGestureRecognizer();
            tapGestureRecognizer.Tapped += (s, e) => {
                MessagingCenter.Send(this,  "ClickPicture", group[currentIndex]);
                AddImage(new Image { Source = group[currentIndex].Image.Source });
            };
            group[currentIndex].Image.GestureRecognizers.Clear();
            group[currentIndex].Image.GestureRecognizers.Add(tapGestureRecognizer);

            return group[currentIndex].Image;
        }
        private void AddImage(Image image)
        {
            image.WidthRequest = ContentGridLayout.Children[0].Width * 0.4;
            image.HeightRequest = ContentGridLayout.Children[0].Height * 0.8;
            GridText.ColumnDefinitions.Add(new ColumnDefinition ());
            GridText.Children.Add(image, GridText.ColumnDefinitions.Count - 1, 0);
        }

        public void DeleteImage_Click(object sender, EventArgs e)
        {
            if(GridText.Children.Count==0)
                return;
            GridText.Children.RemoveAt(GridText.Children.Count - 1);
            GridText.ColumnDefinitions.RemoveAt(GridText.ColumnDefinitions.Count - 1);

        }

        private void ToolbarItem_Clicked(object sender, EventArgs e)
        {

        }

        private void Speech_Clicked(object sender, EventArgs e)
        {
            MessagingCenter.Send(this, "Speech_Clicked");
        }

    }
}
