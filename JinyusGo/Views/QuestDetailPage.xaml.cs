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
    public partial class QuestDetailPage : ContentPage
    {
        public QuestDetailPage()
        {
            InitializeComponent();
        }

        public QuestDetailPage(QuestDetailViewModel viewModel) : this()
        {
            BindingContext = viewModel;
        }
    }
}

