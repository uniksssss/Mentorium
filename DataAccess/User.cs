namespace Mentorium.DataAccess
{
    public class User
    {
        public int Id { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Descriotion { get; set; }
        public int MentorInfoId { get; set; }
        public MentorInfo MentorInfo { get; set; }
        public int StudentInfoId { get; set; }
        public StudentInfo StudentInfo { get; set; }
    }
}