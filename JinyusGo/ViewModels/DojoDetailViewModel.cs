using System;
using System.Collections.Generic;
using System.Windows.Input;
using JinyusGo.Models;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace JinyusGo.ViewModels
{
    public class DojoDetailViewModel : BaseViewModel
    {
        public Dojo Dojo { get; set; }
        public ICommand SendEmailCommand { get; private set; }
        public ICommand PhoneCallCommand { get; private set; }

        public DojoDetailViewModel(Dojo dojo = null)
        {
            Title = dojo?.Name;
            Dojo = dojo;

            SendEmailCommand = new Command(async () =>
            {
                try
                {
                    var message = new EmailMessage
                    {
                        Subject = "Interested in subscription of next quests",
                        Body = "",
                        To = new List<string> { Dojo.EmailAddress }
                    };

                    await Email.ComposeAsync(message);
                }
                catch (FeatureNotSupportedException ex)
                {
                    // Email is not supported on this device
                }
                catch (Exception ex)
                {
                    // some other exception occurred
                }
            });

            PhoneCallCommand = new Command(async () =>
            {
                try
                {
                    PhoneDialer.Open(Dojo.PhoneNumber);
                }
                catch (ArgumentNullException ex)
                {
                    // Number was null or white space
                }
                catch (FeatureNotSupportedException ex)
                {
                    // Email is not supported on this device
                }
                catch (Exception ex)
                {
                    // some other exception occurred
                }
            });
        }
    }
}
