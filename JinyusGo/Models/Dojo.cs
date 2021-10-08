using System.Collections.Generic;
using System.Reflection;
using System.Security.Principal;
using JinyusGo.Helpers;

namespace JinyusGo.Models
{
    public class Dojo
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public string ContactName { get; set; }
        public string EmailAddress { get; set; }
        public string PhoneNumber { get; set; }
        public string Description { get; set; }

        public string ImageUrl { get; set; }
        public string BackgroundColor { get; set; }
        public string LabelColor { get; set; }
        public string TextColor { get; set; }

        public Dojo()
        {
            Id = Helper.GetRandomGuid();
            TextColor = "#000000";
            LabelColor = "0010EF";
        }
    }
}