using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Telerik.XamarinForms.Primitives;
using Xam.Plugin.TabView;
using System.Collections.Generic;
using AC.ViewModels;
using AC.Models;
using System.Collections.ObjectModel;

namespace AC.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
    {
        ItemsViewModel viewModel = new ItemsViewModel();
        ObservableCollection<Image> Images = new ObservableCollection<Image>();
        int Column = 3;
        public MainPage()
        {
           

              
            Images.Add(new Image { Source = "spanie" });
            Images.Add(new Image { Source = "picie" });
            //Images.Add(viewModel.Groups[0].Items[2].Image);
            InitializeComponent();
            viewModel.LoadItemsCommand.Execute(null);
            InitializeTabs();
            UpdateGrid(viewModel.Groups[0].Items);
            //VerticalPictures.SetBinding(VerticalPictures.ItemTemplate, "Images");


        }
        private void InitializeTabs()
        {
            foreach (var group in viewModel.Groups)
            {
                SwitchTab.Children.Add(new Label { Text = group.Title });
            }
        }
        private void SegmentedControl_ItemTapped(object sender, int groupIterator)
        {
            UpdateGrid(viewModel.Groups[groupIterator].Items);
        }
        public void UpdateGrid(List<Item> group)
        {
            CleanGirdLayout();
            for (int i = 0; i < Column; i++)
                GirdLayout.ColumnDefinitions.Add(new ColumnDefinition());

            for (int i = 0; i < group.Count / Column; i++)
                GirdLayout.RowDefinitions.Add(new RowDefinition());

            for (int j = 0; j < group.Count / Column; j++)
                for (int i = 0; i < Column; i++)
                    GirdLayout.Children.Add(GetImageWithProperParams(group, i + (j * Column)), i, j);
        }
        private void CleanGirdLayout()
        {
            GirdLayout.Children.Clear();
            GirdLayout.ColumnDefinitions.Clear();
            GirdLayout.RowDefinitions.Clear();
        }
        private Image GetImageWithProperParams(List<Item> group, int currentIndex)
        {
            var tapGestureRecognizer = new TapGestureRecognizer();

            tapGestureRecognizer.Tapped += (s, e) => {
                TextField.Text += group[currentIndex].Text + " ";
                Images.Add(group[currentIndex].Image);
            };
            group[currentIndex].Image.GestureRecognizers.Clear();
            group[currentIndex].Image.GestureRecognizers.Add(tapGestureRecognizer);

            return group[currentIndex].Image;
        }
    }
}