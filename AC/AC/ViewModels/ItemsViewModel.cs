using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;

using Xamarin.Forms;
using AC.Models;
using AC.Views;
using AC.Services;

namespace AC.ViewModels
{
    public class ItemsViewModel : BaseViewModel
    {
        public ObservableCollection<GroupOfItems> Groups { get; set; }
        public Command LoadItemsCommand { get; set; }
        public string Text { get; set; }
        private ISpeechToText SpeechToText;
        private ITextToSpeech TextToSpeech;

        public ItemsViewModel()
        {
            Title = "AC";
            Groups = new ObservableCollection<GroupOfItems>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
            try{
                SpeechToText = DependencyService.Get<ISpeechToText>();
                TextToSpeech = DependencyService.Get<ITextToSpeech>();
            }
            catch (Exception ex){
                Text = ex.Message;
                UpdateText();
            } 
            SetUpSubscribes();       
        }

        private void UpdateText()
        {
            MessagingCenter.Send(this, "UpdateText", Text);
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

        private void SetUpSubscribes()
        {
            MessagingCenter.Subscribe<ISpeechToText, string>(this, "STT", (sender, args) =>
            {
                Text += args;
                UpdateText();
            });

            MessagingCenter.Subscribe<MainPage>(this, "Speech_Clicked", (sender) =>
            {
                try
                {
                    SpeechToText.StartSpeechToText();
                }
                catch (Exception ex)
                {
                    Text = ex.Message;
                    UpdateText();
                }
            });

            MessagingCenter.Subscribe<IMessageSender, string>(this, "STT", (sender, args) =>
            {
                Text = args;
                UpdateText();
            });

            MessagingCenter.Subscribe<NewItemPage, GroupOfItems>(this, "AddItem", async (obj, item) =>
            {
                var newItem = item as GroupOfItems;
                Groups.Add(newItem);
                await DataStore.AddItemAsync(newItem);
            });

            MessagingCenter.Subscribe<MainPage, Item>(this, "ClickPicture", (obj, item) =>
            {
                Text += item.Text + " ";
                UpdateText();
            });

            MessagingCenter.Subscribe<MainPage>(this, "Listen_Clicked", (sender) =>
            {
                TextToSpeech.Speak(Text);
            });
        }
    }
}