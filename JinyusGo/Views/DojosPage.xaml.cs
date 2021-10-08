using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JinyusGo.Models;
using JinyusGo.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace JinyusGo.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DojosPage : ContentPage
    {
        private readonly DojosViewModel _viewModel;
        public DojosPage()
        {
            InitializeComponent();
            BindingContext = _viewModel = new DojosViewModel();
        }

        async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            if (args.SelectedItem is Dojo dojo)
            {
                await Navigation.PushAsync(new DojoDetailPage(new DojoDetailViewModel(dojo)));
            }
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            
            if (_viewModel.Dojos.Count == 0)
                _viewModel.LoadDojosCommand.Execute(null);
        }
        private void ListViewDojos_OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            
        }
    }
}

