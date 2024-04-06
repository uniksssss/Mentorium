namespace Mentorium.DataAccess
{
    public class GithubUser
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
