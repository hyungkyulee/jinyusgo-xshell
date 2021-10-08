using System;
using System.Collections.Generic;
using JinyusGo.ViewModels;
using JinyusGo.Views;
using Xamarin.Forms;

namespace JinyusGo
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
        }

        private void MenuItem_OnClicked(object sender, EventArgs e)
        {
            FlyoutIsPresented = false;
            DisplayAlert("Rate!", "Please give your feedback to this app.", "Ok");
        }
    }
}
