namespace Mentorium.DataAccess
{
    public class StudentInfoStack
    {
        public int Id { get; set; }
        public int StudentInfoId { get; set; }
        public StudentInfo StudentInfo { get; set; }
        public int StackId { get; set; }
        public MentoriumStacks Stack { get; set; }
    }
}