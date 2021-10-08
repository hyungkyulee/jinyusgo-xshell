using System;
using System.Diagnostics;
using System.Threading.Tasks;
using JinyusGo.Models;
using JinyusGo.Services;
using Xamarin.Forms;

namespace JinyusGo.ViewModels
{
    public class HomeViewModel : BaseViewModel
    {
        public IDojosDataStore DojosDataStore => ((App) App.Current).DojosDataStore;
        public IQuestsDataStore QuestsDataStore => ((App) App.Current).QuestsDataStore;
        
        public Dojo NewestDojo { get; set; }
        public Quest NewestQuest { get; set; }
        
        public Command LoadDataCommand { get; set; }
        public Command OpenDojoCommand { get; set; }
        public Command OpenQuestCommand { get; set; }

        public HomeViewModel()
        {
            Title = "Home";
            LoadDataCommand = new Command(async () => await ExecuteLoadDataCommand());
        }
        private async Task ExecuteLoadDataCommand()
        {
            if (IsBusy) return;

            IsBusy = true;

            try
            {
                var NewestDojoTask = DojosDataStore.GetNewestDojoAsync();
                var NewestQuestTask = QuestsDataStore.GetNewestQuestAsync();

                await Task.WhenAll(NewestQuestTask, NewestDojoTask);

                NewestDojo = NewestDojoTask.Result;
                NewestQuest = NewestQuestTask.Result;
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
