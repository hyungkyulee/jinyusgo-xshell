using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using JinyusGo.Models;
using JinyusGo.Services;
using Xamarin.Forms;

namespace JinyusGo.ViewModels
{
    public class QuestsViewModel : BaseViewModel
    {
        public IQuestsDataStore DataStore;
        public ObservableCollection<DojoQuest> Quests { get; set; }
        public Command LoadQuestsCommand { get; set; }

        public QuestsViewModel()
        {
            DataStore = ((App) App.Current).QuestsDataStore;

            Title = "Browse Quests";
            Quests = new ObservableCollection<DojoQuest>();
            LoadQuestsCommand = new Command(async () => await ExecuteLoadQuestsCommand());
        }
        private async Task ExecuteLoadQuestsCommand()
        {
            if (IsBusy) return;

            IsBusy = true;

            try
            {
                Quests.Clear();
                var quests = await DataStore.GetItemsAsync(true);
                foreach (var quest in quests)
                {
                    Quests.Add(DataStore.GetDojoQuestFromQuest(quest));
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
