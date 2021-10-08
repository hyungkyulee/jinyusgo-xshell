namespace JinyusGo.Models
{
    public class DojoQuest : Quest
    {
        public Dojo Dojo { get; set; }

        public string BackgroundColor => Dojo?.BackgroundColor;

        public DojoQuest(Dojo dojo) : base()
        {
            Dojo = dojo;
        }

        public DojoQuest(Quest quest, Dojo dojo) : base()
        {
            Id = quest.Id;
            Course = quest.Course;
            Subject = quest.Subject;
            Category = quest.Category;
            Level = quest.Level;
            Question = quest.Question;
            Answer = quest.Answer;

            DojoId = quest.DojoId;
            Dojo = dojo;
            Tags = quest.Tags.GetRange(0, quest.Tags.Count);
        }
    }
}