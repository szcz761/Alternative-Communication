using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AC.Models;

namespace AC.Services
{
    public class MockDataStore : IDataStore<GroupOfItems>
    {
        //List<Item> items =new List<Item>();
      List<GroupOfItems> Groups;

        public MockDataStore()
        {
            GroupOfItems GenerateGroup(string title)
            {
                var group = new GroupOfItems(new List<Item>{
                new Item { Id = Guid.NewGuid().ToString(), WordType = WordType.noun, Text = "Jeść", Description = "Chce mi się jeść", Image = new Xamarin.Forms.Image { Source = "jedzenie" } },
                new Item { Id = Guid.NewGuid().ToString(), WordType = WordType.noun, Text = "Czytać", Description = "Chce mi się czytać", Image = new Xamarin.Forms.Image { Source = "czytanie" } },
                new Item { Id = Guid.NewGuid().ToString(), WordType = WordType.verb, Text = "Pić", Description = "Chce mi się pić", Image = new Xamarin.Forms.Image { Source = "picie" } },
                new Item { Id = Guid.NewGuid().ToString(), WordType = WordType.adjective, Text = "Spać", Description = "Chce mi się spać", Image = new Xamarin.Forms.Image { Source = "spanie" } },
                new Item { Id = Guid.NewGuid().ToString(), WordType = WordType.noun, Text = "Jeść", Description = "Chce mi się jeść", Image = new Xamarin.Forms.Image { Source = "jedzenie" } },
                new Item { Id = Guid.NewGuid().ToString(), WordType = WordType.adjective, Text = "Czytać", Description = "Chce mi się czytać", Image = new Xamarin.Forms.Image { Source = "czytanie" } },
                new Item { Id = Guid.NewGuid().ToString(), WordType = WordType.verb, Text = "Pić", Description = "Chce mi się pić", Image = new Xamarin.Forms.Image { Source = "picie" } },
                new Item { Id = Guid.NewGuid().ToString(), WordType = WordType.noun, Text = "Spać", Description = "Chce mi się spać", Image = new Xamarin.Forms.Image { Source = "spanie" } },
                new Item { Id = Guid.NewGuid().ToString(), WordType = WordType.adjective, Text = "Jeść", Description = "Chce mi się jeść", Image = new Xamarin.Forms.Image { Source = "jedzenie" } },
                new Item { Id = Guid.NewGuid().ToString(), WordType = WordType.verb, Text = "Czytać", Description = "Chce mi się czytać", Image = new Xamarin.Forms.Image { Source = "czytanie" } },
                new Item { Id = Guid.NewGuid().ToString(), WordType = WordType.noun, Text = "Pić", Description = "Chce mi się pić", Image = new Xamarin.Forms.Image { Source = "picie" } },
                new Item { Id = Guid.NewGuid().ToString(), WordType = WordType.noun, Text = "Jeść", Description = "Chce mi się jeść", Image = new Xamarin.Forms.Image { Source = "jedzenie" } },
                new Item { Id = Guid.NewGuid().ToString(), WordType = WordType.adjective, Text = "Czytać", Description = "Chce mi się czytać", Image = new Xamarin.Forms.Image { Source = "czytanie" } },
                new Item { Id = Guid.NewGuid().ToString(), WordType = WordType.verb, Text = "Pić", Description = "Chce mi się pić", Image = new Xamarin.Forms.Image { Source = "picie" } },
                new Item { Id = Guid.NewGuid().ToString(), WordType = WordType.adjective, Text = "Spać", Description = "Chce mi się spać", Image = new Xamarin.Forms.Image { Source = "spanie" } },
                new Item { Id = Guid.NewGuid().ToString(), WordType = WordType.noun, Text = "Jeść", Description = "Chce mi się jeść", Image = new Xamarin.Forms.Image { Source = "jedzenie" } },
                new Item { Id = Guid.NewGuid().ToString(), WordType = WordType.adjective, Text = "Czytać", Description = "Chce mi się czytać", Image = new Xamarin.Forms.Image { Source = "czytanie" } },
                new Item { Id = Guid.NewGuid().ToString(), WordType = WordType.noun, Text = "Pić", Description = "Chce mi się pić", Image = new Xamarin.Forms.Image { Source = "picie" } },
                new Item { Id = Guid.NewGuid().ToString(), WordType = WordType.verb, Text = "Spać", Description = "Chce mi się spać", Image = new Xamarin.Forms.Image { Source = "spanie" } }
                });
            
                group.Title = title;
                return group;
            }
        
    
            Groups = new List<GroupOfItems>();
            var mockGroup = new List<GroupOfItems>
            {
                GenerateGroup("Rzeczownik"),
                GenerateGroup("Czasownik"),
                GenerateGroup("Przymiotnik"),
                //GenerateGroup("Inne"),
            };

            foreach (var item in mockGroup)
            {
                Groups.Add(item);
            }
        }

        public async Task<bool> AddItemAsync(GroupOfItems item)
        {
            Groups.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(GroupOfItems item)
        {
            var oldItem = Groups.Where((GroupOfItems arg) => arg.Title == item.Title).FirstOrDefault();
            Groups.Remove(oldItem);
            Groups.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string title)
        {
            var oldItem = Groups.Where((GroupOfItems arg) => arg.Title == title).FirstOrDefault();
            Groups.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<GroupOfItems> GetItemAsync(string title)
        {
            return await Task.FromResult(Groups.FirstOrDefault(s => s.Title == title));
        }

        public async Task<IEnumerable<GroupOfItems>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(Groups);
        }
    }
}