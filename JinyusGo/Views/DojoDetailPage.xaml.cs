using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JinyusGo.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace JinyusGo.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DojoDetailPage : ContentPage
    {
        public DojoDetailPage()
        {
            InitializeComponent();
        }

        public DojoDetailPage(DojoDetailViewModel viewModel) : this()
        {
            BindingContext = viewModel;
        }
    }
}

