using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AC.Models;

namespace AC.Services
{
    public class MockDataStore : IDataStore<Item>
    {
        List<Item> items;

        public MockDataStore()
        {
            items = new List<Item>();
            var mockItems = new List<Item>
            {
                new Item { Id = Guid.NewGuid().ToString(), Text = "Jeść", Description="Chce mi się jeść", Icon = new Xamarin.Forms.Image{ Source = "jedzenie" } },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Czytać", Description="Chce mi się czytać", Icon = new Xamarin.Forms.Image{ Source = "czytanie" } },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Pić", Description="Chce mi się pić", Icon = new Xamarin.Forms.Image{ Source = "picie" } },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Spać", Description="Chce mi się spać", Icon = new Xamarin.Forms.Image{ Source = "spanie" } }

            };

            foreach (var item in mockItems)
            {
                items.Add(item);
            }
        }

        public async Task<bool> AddItemAsync(Item item)
        {
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(Item item)
        {
            var oldItem = items.Where((Item arg) => arg.Id == item.Id).FirstOrDefault();
            items.Remove(oldItem);
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            var oldItem = items.Where((Item arg) => arg.Id == id).FirstOrDefault();
            items.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<Item> GetItemAsync(string id)
        {
            return await Task.FromResult(items.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Item>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(items);
        }
    }
}