namespace Mentorium.DataAccess
{
    public class MentorInfoStack
    {
        public int Id { get; set; }
        public int MentorInfoId { get; set; }
        public MentorInfo MentorInfo { get; set; }
        public int StackId { get; set; }
        public MentoriumStacks Stack { get; set; }
    }
}