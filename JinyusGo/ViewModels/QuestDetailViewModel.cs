using System;
using System.Collections.Generic;
using System.Windows.Input;
using JinyusGo.Models;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace JinyusGo.ViewModels
{
    public class QuestDetailViewModel : BaseViewModel
    {
        public DojoQuest Quest { get; set; }
        public ICommand SendEmailCommand { get; private set; }
        public ICommand PhoneCallCommand { get; private set; }

        public QuestDetailViewModel(DojoQuest quest)
        {
            Title = quest?.Category;
            Quest = quest;

            SendEmailCommand = new Command(async () =>
            {
                try
                {
                    var message = new EmailMessage
                    {
                        Subject = $"There is a question of the quest: {quest.Id}",
                        Body = "",
                        To = new List<string> { quest.Dojo.EmailAddress }
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
                    PhoneDialer.Open(quest?.Dojo.PhoneNumber);
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
