using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using JinyusGo.Services;
using JinyusGo.Views;

namespace JinyusGo
{
    public partial class App : Application
    {
        private IDojosDataStore _dojosDataStore;
        public IDojosDataStore DojosDataStore => GetDojosDataStore();

        private IQuestsDataStore _questsDataStore;
        public IQuestsDataStore QuestsDataStore => GetQuestsDataStore();

        private IDojosDataStore GetDojosDataStore()
        {
            return _dojosDataStore ?? (_dojosDataStore = new DojosDataStore());
        }
        
        private IQuestsDataStore GetQuestsDataStore()
        {
            return _questsDataStore ?? (_questsDataStore = new QuestsDataStore(DojosDataStore.GetItemsAsync().Result));
        }

        public App()
        {
            InitializeComponent();

            // DependencyService.Register<MockDataStore>();
            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
