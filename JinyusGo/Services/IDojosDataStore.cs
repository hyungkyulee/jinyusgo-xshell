using System.Collections.Generic;
using System.Threading.Tasks;
using JinyusGo.Models;

namespace JinyusGo.Services
{
    public interface IDojosDataStore : IDataStore<Dojo>
    {
        Task<Dojo> GetNewestDojoAsync();
    }
}