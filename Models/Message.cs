namespace Mentorium.Models
{
    public class Message
    {
        public int MessageId { get; set; }
        public int ChatId { get; set; }
        public int UserId { get; set; }
        public DateTime DateTime { get; set; } = DateTime.UtcNow;
        public string Text { get; set; }
    }
}
