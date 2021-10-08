using System.Collections.Generic;
using JinyusGo.Helpers;

namespace JinyusGo.Models
{
    public class Quest
    {
        public string Id { get; set; }
        public string DojoId { get; set; }
        

        public string Course { get; set; }
        public string Subject { get; set; }
        public string Category { get; set; }
        public int Level { get; set; }
        public string Question { get; set; }
        public string Answer { get; set; }

        public List<string> Tags { get; set; }
        public string FormattedTags => Tags == null ? string.Empty : string.Join(", ", Tags);
    }
}