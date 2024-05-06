namespace Mentorium.Models;

public class Chat
{
    public int ChatId { get; set; }

    public List<User> Users { get; set; } = [];
}