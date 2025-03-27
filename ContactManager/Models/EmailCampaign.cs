namespace ContactManager.Models
{
    public class EmailCampaign
    {
        public int Id { get; set; }
        public required string Subject { get; set; }
        public required string Message { get; set; }
        public int GroupId { get; set; }
        public Group? Group { get; set; }
    }
}
