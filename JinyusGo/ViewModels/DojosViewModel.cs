using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using JinyusGo.Models;
using JinyusGo.Services;
using Xamarin.Forms;

namespace JinyusGo.ViewModels
{
    public class DojosViewModel : BaseViewModel
    {
        public IDojosDataStore DataStore => ((App) App.Current).DojosDataStore;
        public ObservableCollection<Dojo> Dojos { get; set; }
        public Command LoadDojosCommand { get; set; }

        public DojosViewModel()
        {
            Title = "Browse Dojos";
            Dojos = new ObservableCollection<Dojo>();
            LoadDojosCommand = new Command(async () => await ExecuteLoadDojosCommand());
        }
        private async Task ExecuteLoadDojosCommand()
        {
            if (IsBusy) return;

            IsBusy = true;

            try
            {
                Dojos.Clear();
                var dojos = await DataStore.GetItemsAsync(true);
                foreach (var dojo in dojos)
                {
                    Dojos.Add(dojo);
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
