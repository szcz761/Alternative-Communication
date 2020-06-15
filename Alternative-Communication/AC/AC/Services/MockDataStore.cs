using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AC.Models;
using Android;
using Android.Content;
using Android.Widget;
using FFImageLoading;
using FFImageLoading.Forms;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;

namespace AC.Services
{
    public class MockDataStore : IDataStore<GroupOfItems>
    {
        //List<Item> items =new List<Item>();
      List<GroupOfItems> Groups;

        public MockDataStore()
        {
            Groups = new List<GroupOfItems>();

            Groups.Add(GenerateGroupOgolne());
            Groups.Add(GenerateGroupOsoby());
            Groups.Add(GenerateGroupCzynnosci());
            Groups.Add(GenerateGroupRzeczy());
            Groups.Add(GenerateGroupEmocje());
            Groups.Add(GenerateGroupMiejsca());
        }

        GroupOfItems GenerateGroupCzynnosci()
        {
            var group = new GroupOfItems(new List<Item>{
                new Item { Id = Guid.NewGuid().ToString(), WordType = WordType.noun, Text = "czytać", Description = "", Image = new CachedImage { Source = "czytac" } },
                new Item { Id = Guid.NewGuid().ToString(), WordType = WordType.noun, Text = "grać", Description = "", Image = new CachedImage { Source = "grac" } },
                new Item { Id = Guid.NewGuid().ToString(), WordType = WordType.noun, Text = "jeść", Description = "", Image = new CachedImage { Source = "jesc" } },
                new Item { Id = Guid.NewGuid().ToString(), WordType = WordType.noun, Text = "pić", Description = "", Image = new CachedImage { Source = "pic" } },
                new Item { Id = Guid.NewGuid().ToString(), WordType = WordType.noun, Text = "pisać", Description = "", Image = new CachedImage { Source = "pisac" } },
                new Item { Id = Guid.NewGuid().ToString(), WordType = WordType.noun, Text = "słuchać", Description = "", Image = new CachedImage { Source = "sluchac" } },
                new Item { Id = Guid.NewGuid().ToString(), WordType = WordType.noun, Text = "spać", Description = "", Image = new CachedImage { Source = "spac" } },
                });
          
           group.Title = "czynności";
            group.Image = new Image { Source = "czynnosci" };
            return group;
        }
        GroupOfItems GenerateGroupOgolne()
        {
            var group = new GroupOfItems(new List<Item>{
                new Item { Id = Guid.NewGuid().ToString(), WordType = WordType.noun, Text = "chcieć", Description = "", Image = new CachedImage { Source = "chciec" } },
                new Item { Id = Guid.NewGuid().ToString(), WordType = WordType.noun, Text = "gdzie", Description = "", Image = new CachedImage { Source = "gdzie" } },
                new Item { Id = Guid.NewGuid().ToString(), WordType = WordType.noun, Text = "nie", Description = "", Image = new CachedImage { Source = "nie" } },
                new Item { Id = Guid.NewGuid().ToString(), WordType = WordType.noun, Text = "pomoc", Description = "", Image = new CachedImage { Source = "pomoc" } },
                new Item { Id = Guid.NewGuid().ToString(), WordType = WordType.noun, Text = "tak", Description = "", Image = new CachedImage { Source = "tak" } },
                new Item { Id = Guid.NewGuid().ToString(), WordType = WordType.noun, Text = "z", Description = "", Image = new CachedImage { Source = "z" } },
                });
            group.Title = "ogólne";
            group.Image = new Image { Source = "ogolne" };
            return group;
        }
        GroupOfItems GenerateGroupEmocje()
        {
            var group = new GroupOfItems(new List<Item>{
                new Item { Id = Guid.NewGuid().ToString(), WordType = WordType.noun, Text = "ból", Description = "", Image = new CachedImage { Source = "bol" } },
                new Item { Id = Guid.NewGuid().ToString(), WordType = WordType.noun, Text = "szczęscie", Description = "", Image = new CachedImage { Source = "szczescie" } },
                new Item { Id = Guid.NewGuid().ToString(), WordType = WordType.noun, Text = "złość", Description = "", Image = new CachedImage { Source = "zlosc" } },
                new Item { Id = Guid.NewGuid().ToString(), WordType = WordType.noun, Text = "zmęczenie", Description = "", Image = new CachedImage { Source = "zmeczenie" } },
                new Item { Id = Guid.NewGuid().ToString(), WordType = WordType.noun, Text = "znudzenie", Description = "", Image = new CachedImage { Source = "znudzenie" } },
                });
            group.Title = "emocje";
            group.Image = new Image { Source = "emocje" };
            return group;
        }
        GroupOfItems GenerateGroupMiejsca()
        {
            var group = new GroupOfItems(new List<Item>{
                new Item { Id = Guid.NewGuid().ToString(), WordType = WordType.noun, Text = "dom", Description = "", Image = new CachedImage { Source = "dom" } },
                new Item { Id = Guid.NewGuid().ToString(), WordType = WordType.noun, Text = "kuchnia", Description = "", Image = new CachedImage { Source = "kuchnia" } },
                new Item { Id = Guid.NewGuid().ToString(), WordType = WordType.noun, Text = "praca", Description = "", Image = new CachedImage { Source = "praca" } },
                new Item { Id = Guid.NewGuid().ToString(), WordType = WordType.noun, Text = "szkoła", Description = "", Image = new CachedImage { Source = "szkola" } },
                });
            group.Title = "miejsca";
            group.Image = new Image { Source = "miejsca" };
            return group;
        }
        GroupOfItems GenerateGroupOsoby()
        {
            var group = new GroupOfItems(new List<Item>{
                new Item { Id = Guid.NewGuid().ToString(), WordType = WordType.noun, Text = "ja", Description = "", Image = new CachedImage { Source = "ja" } },
                new Item { Id = Guid.NewGuid().ToString(), WordType = WordType.noun, Text = "ty", Description = "", Image = new CachedImage { Source = "ty" } },
                new Item { Id = Guid.NewGuid().ToString(), WordType = WordType.noun, Text = "my", Description = "", Image = new CachedImage { Source = "my" } },
                new Item { Id = Guid.NewGuid().ToString(), WordType = WordType.noun, Text = "wy", Description = "", Image = new CachedImage { Source = "wy" } },
                new Item { Id = Guid.NewGuid().ToString(), WordType = WordType.noun, Text = "mama", Description = "", Image = new CachedImage { Source = "mama" } },
                new Item { Id = Guid.NewGuid().ToString(), WordType = WordType.noun, Text = "tata", Description = "", Image = new CachedImage { Source = "tata" } },
                new Item { Id = Guid.NewGuid().ToString(), WordType = WordType.noun, Text = "babcia", Description = "", Image = new CachedImage { Source = "babcia" } },
                new Item { Id = Guid.NewGuid().ToString(), WordType = WordType.noun, Text = "siostra", Description = "", Image = new CachedImage { Source = "siostra" } },
                });
            group.Title = "osoby";
            group.Image = new Image { Source = "osoby" };
            return group;
        }
        GroupOfItems GenerateGroupRzeczy()
        {
            var group = new GroupOfItems(new List<Item>{
                new Item { Id = Guid.NewGuid().ToString(), WordType = WordType.noun, Text = "komputer", Description = "", Image = new CachedImage { Source = "komputer" } },
                new Item { Id = Guid.NewGuid().ToString(), WordType = WordType.noun, Text = "pies", Description = "", Image = new CachedImage { Source = "pies" } },
                new Item { Id = Guid.NewGuid().ToString(), WordType = WordType.noun, Text = "kot", Description = "", Image = new CachedImage { Source = "kot" } },
                new Item { Id = Guid.NewGuid().ToString(), WordType = WordType.noun, Text = "pomrańcza", Description = "", Image = new CachedImage { Source = "pomarancz" } },
                new Item { Id = Guid.NewGuid().ToString(), WordType = WordType.noun, Text = "ręka", Description = "", Image = new CachedImage { Source = "reka" } },
                new Item { Id = Guid.NewGuid().ToString(), WordType = WordType.noun, Text = "sofa", Description = "", Image = new CachedImage { Source = "sofa" } },
                new Item { Id = Guid.NewGuid().ToString(), WordType = WordType.noun, Text = "sól", Description = "", Image = new CachedImage { Source = "sol" } },
                new Item { Id = Guid.NewGuid().ToString(), WordType = WordType.noun, Text = "zbawka", Description = "", Image = new CachedImage { Source = "zabawka" } },
                new Item { Id = Guid.NewGuid().ToString(), WordType = WordType.noun, Text = "zadanie domowe", Description = "", Image = new CachedImage { Source = "zadanieDomowe" } },
                new Item { Id = Guid.NewGuid().ToString(), WordType = WordType.noun, Text = "zeszyt", Description = "", Image = new CachedImage { Source = "zeszyt" } },
                });
            group.Title = "rzeczy";
            group.Image = new Image { Source = "rzeczy" };
            return group;
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