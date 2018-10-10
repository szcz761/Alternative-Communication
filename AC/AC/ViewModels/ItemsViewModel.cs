using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;

using Xamarin.Forms;

using AC.Models;
using AC.Views;

namespace AC.ViewModels
{
    public class ItemsViewModel : BaseViewModel
    {
        public ObservableCollection<GroupOfItems> Groups { get; set; }
        public Command LoadItemsCommand { get; set; }

        public ItemsViewModel()
        {
            Title = "Browse";
            Groups = new ObservableCollection<GroupOfItems>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());

            MessagingCenter.Subscribe<NewItemPage, GroupOfItems>(this, "AddItem", async (obj, item) =>
            {
                var newItem = item as GroupOfItems;
                Groups.Add(newItem);
                await DataStore.AddItemAsync(newItem);
            });
        }

        async Task ExecuteLoadItemsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                Groups.Clear();
                var items = await DataStore.GetItemsAsync(true);
                foreach (var item in items)
                {
                    Groups.Add(item);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}