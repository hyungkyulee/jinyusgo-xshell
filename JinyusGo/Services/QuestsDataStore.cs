using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JinyusGo.Models;

namespace JinyusGo.Services
{
    public class QuestsDataStore : IQuestsDataStore
    {
        private List<Quest> _quests;
        private readonly IEnumerable<Dojo> _dojos;

        public QuestsDataStore(IEnumerable<Dojo> dojos)
        {
            _dojos = dojos;
            _quests = GetQuests();
        }

        public async Task<Quest> GetItemAsync(string id)
        {
            return await Task.FromResult(_quests.FirstOrDefault(q => q.Id == id));
        }

        public async Task<IEnumerable<Quest>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(_quests);
        }

        public DojoQuest GetDojoQuestFromQuest(Quest quest)
        {
            var dojo = _dojos.FirstOrDefault(d => d.Id == quest.DojoId);
            return new DojoQuest(quest, dojo);
        }

        public async Task<Quest> GetNewestQuestAsync()
        {
            return await Task.FromResult(_quests.LastOrDefault());
        }
        public List<DojoQuest> GetDojoQuests()
        {
            return _quests.Select(q => GetDojoQuestFromQuest(q)).ToList();
        }

        private List<Quest> GetQuests()
        {
            _quests = new List<Quest>();
            var d1 = _dojos.FirstOrDefault();
            var d2 = _dojos.Skip(1).FirstOrDefault();
            var d3 = _dojos.Skip(2).FirstOrDefault();
            
            _quests.Add(new Quest
            {
                DojoId = d1?.Id,
                Course = "11+",
                Subject = "verbal-reasoning",
                Category = "vocabulary",
                Level = 1,
                Question = "Select(Underline) the correct homophone to complete the sentence. > Rob planted a ___ tree. A) ewe, B) yew",
                Answer = "B",
                Tags = new List<string>{ "voca, select, underline, homophone" }
            });
            
            _quests.Add(new Quest
            {
                DojoId = d2?.Id,
                Course = "11+",
                Subject = "verbal-reasoning",
                Category = "vocabulary",
                Level = 1,
                Question = "Find the world that is a synonym, or nearly a synonym, of the word on the left. > unwelcome: unavoidable, unacceptable, regrettable, undesirable",
                Answer = "undesirable",
                Tags = new List<string>{ "voca, synonym" }
            });
            
            _quests.Add(new Quest
            {
                DojoId = d2?.Id,
                Course = "11+",
                Subject = "verbal-reasoning",
                Category = "vocabulary",
                Level = 1,
                Question = "Find the world that is a synonym, or nearly a synonym, of the word on the left. > reinstate: summon, restore, uncover, redeem",
                Answer = "undesirable",
                Tags = new List<string>{ "voca, find, synonym" }
            });
            
            _quests.Add(new Quest
            {
                DojoId = d3?.Id,
                Course = "11+",
                Subject = "verbal-reasoning",
                Category = "vocabulary",
                Level = 1,
                Question = "Complete the world on the right so that it is an antonym, or nearly an antonym, of the world on the left. > implausible: c__dib_e",
                Answer = "credible",
                Tags = new List<string>{ "voca, complete, antonym" }
            });
            
            _quests.Add(new Quest
            {
                DojoId = d3?.Id,
                Course = "11+",
                Subject = "verbal-reasoning",
                Category = "vocabulary",
                Level = 1,
                Question = "Complete the world on the right so that it is an antonym, or nearly an antonym, of the world on the left. > gratify: _is_le_se",
                Answer = "displease",
                Tags = new List<string>{ "voca, complete, antonym" }
            });
            
            _quests.Add(new Quest
            {
                DojoId = d3?.Id,
                Course = "11+",
                Subject = "verbal-reasoning",
                Category = "vocabulary",
                Level = 1,
                Question = "Complete the world on the right so that it is an antonym, or nearly an antonym, of the world on the left. > expressive: _nem_t__na_",
                Answer = "unemotional",
                Tags = new List<string>{ "voca, complete, antonym" }
            });

            return _quests;
        }
    }
}