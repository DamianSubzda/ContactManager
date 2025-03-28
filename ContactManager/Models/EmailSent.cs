namespace ContactManager.Models
{
    public class EmailSent
    {
        public int Id { get; set; }

        public int ContactId { get; set; }
        public Contact Contact { get; set; }

        public int? EmailCampaignId { get; set; }
        public EmailCampaign? EmailCampaign { get; set; }

        public string? SubjectSnapshot { get; set; }
        public string? MessageSnapshot { get; set; }
    }
}
