using System.ComponentModel.DataAnnotations.Schema;

namespace Mentorium.Models
{
    public class TelegramUser
    {
        public int TelegramUserId { get; set; }
        [ForeignKey("User")]
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
