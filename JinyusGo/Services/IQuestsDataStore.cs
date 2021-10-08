using System.Collections.Generic;
using System.Threading.Tasks;
using JinyusGo.Models;

namespace JinyusGo.Services
{
    public interface IQuestsDataStore : IDataStore<Quest>
    {
        Task<Quest> GetNewestQuestAsync();
        List<DojoQuest> GetDojoQuests();
        DojoQuest GetDojoQuestFromQuest(Quest quest);
    }
}