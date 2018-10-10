using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AC.Services
{
    public interface IDataStore<T>
    {
        Task<bool> AddItemAsync(T item);
        Task<bool> UpdateItemAsync(T item);
        Task<bool> DeleteItemAsync(string title);
        Task<T> GetItemAsync(string title);
        Task<IEnumerable<T>> GetItemsAsync(bool forceRefresh = false);
    }
}
