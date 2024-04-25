using Microsoft.EntityFrameworkCore;

namespace Mentorium.Models
{
    [Index(nameof(GithubId), IsUnique = true)]
    public class User
    {
        public int UserId { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string? Description { get; set; }
        public int? GithubId { get; set; }
        public string? TelegramId { get; set; }
        public bool IsMentor { get; set; }
    }
}