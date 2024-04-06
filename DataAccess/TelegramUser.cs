namespace Mentorium.DataAccess
{
    public class TelegramUser
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
