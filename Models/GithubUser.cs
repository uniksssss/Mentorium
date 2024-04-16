using System.ComponentModel.DataAnnotations.Schema;

namespace Mentorium.Models
{
    public class GithubUser
    {
        public int GithubUserId { get; set; }
        [ForeignKey("User")]
        public int UserId { get; set; }
        public User User { get; set; }
    }
}