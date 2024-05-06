namespace Mentorium.Models;

public class Chat
{
    public int ChatId { get; set; }
    public ICollection<User> Users { get; set; } = [];
}