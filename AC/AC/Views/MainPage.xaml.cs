using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Telerik.XamarinForms.Primitives;
using Xam.Plugin.TabView;
using System.Collections.Generic;
using AC.ViewModels;
using AC.Models;

namespace AC.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
    {
        ItemsViewModel viewModel = new ItemsViewModel();
        List<Grid> GirdsLayouts = new List<Grid>();
        int Column = 3;
        Grid grid;
        public MainPage()
        {
            InitializeComponent();
            viewModel.LoadItemsCommand.Execute(null);
            //InitializeGirds();
            InitializeTabs();

            //var group = viewModel.Groups[groupIterator].Items;
           /* grid = new Grid();
            grid.ColumnDefinitions.Add(new ColumnDefinition());
            grid.ColumnDefinitions.Add(new ColumnDefinition());
            grid.RowDefinitions.Add(new RowDefinition());
            grid.RowDefinitions.Add(new RowDefinition());
            grid.Children.Add(new Label { Text = "dfsf1" }, 0, 0);
            grid.Children.Add(new Label { Text = "dfsf2" }, 1, 0);
            grid.Children.Add(new Label { Text = "dfsf3" }, 0, 1);
            grid.Children.Add(new Label { Text = "dfsf4" }, 1, 1);
            grid.IsVisible = true;
            GirdLayout = grid;*/
        }
        void InitializeGirds()
        {
            for (int i = 0; i < viewModel.Groups.Count; ++i)
                InitializeGird(i);
        }
        void InitializeGird(int groupIterator)
        {
            //Grid grid = new Grid();
            var group = viewModel.Groups[groupIterator].Items;
            GirdLayout.Children.Clear();
            GirdLayout.ColumnDefinitions.Clear();
            GirdLayout.RowDefinitions.Clear();
            //grid.RowDefinitions.Add(new RowDefinition());

            for (int i = 0; i < Column; i++)
                GirdLayout.ColumnDefinitions.Add(new ColumnDefinition());

             for (int i = 0; i < group.Count / Column; i++)
                GirdLayout.RowDefinitions.Add(new RowDefinition());

             for (int j = 0; j < group.Count / Column; j++)
                 for (int i = 0; i < Column; i++)
                    GirdLayout.Children.Add(GetImageWithProperParams(groupIterator, i + (j * Column)), i, j);

            //return grid;
        }
        private Image GetImageWithProperParams(int groupIterator, int currentIndex)
        {
            var items = viewModel.Groups[groupIterator].Items;
            var tapGestureRecognizer = new TapGestureRecognizer();

            tapGestureRecognizer.Tapped += (s, e) => {
                AddWordToText(items[currentIndex].Text);
            };
            items[currentIndex].Image.GestureRecognizers.Add(tapGestureRecognizer);

            return items[currentIndex].Image;
        }
        void AddWordToText(string word)
        {
            TextField.Text += word;
            TextField.Text += " ";
        }
        void InitializeTabs()
        {
            foreach(var group in viewModel.Groups)
            {
                SwitchTab.Children.Add(new Label { Text = group.Title });
            }
        }
        private void SegmentedControl_ItemTapped(object sender, int key)
        {
           
            InitializeGird(key);
        }
   /*     async void AddItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new NewItemPage()));
        }*/
        protected override void OnAppearing()
        {
            //girdLayout.Children.Clear();

            base.OnAppearing();
            if (viewModel.Groups.Count == 0)
                viewModel.LoadItemsCommand.Execute(null);
        }
    }
}