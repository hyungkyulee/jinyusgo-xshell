using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using JinyusGo.Models;

namespace JinyusGo.Services
{
    public interface IDataStore<T>
    {
        Task<T> GetItemAsync(string id);
        Task<IEnumerable<T>> GetItemsAsync(bool forceRefresh = false);
    }
}
