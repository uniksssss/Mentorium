using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Mentorium.Models
{
    [PrimaryKey("StudentInfoId", "MentoriumStackId")]
    public class StudentInfoStack
    {
        [ForeignKey("StudentInfo")]
        public int StudentInfoId { get; set; }
        public StudentInfo StudentInfo { get; set; }
        [ForeignKey("MentoriumStack")]
        public int MentoriumStackId { get; set; }
        public MentoriumStack MentoriumStack { get; set; }
    }
}