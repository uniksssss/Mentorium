using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Mentorium.Models
{
    [PrimaryKey("MentorInfoId", "MentoriumStackId")]
    public class MentorInfoStack
    {
        [ForeignKey("MentorInfo")]
        public int MentorInfoId { get; set; }
        public MentorInfo MentorInfo { get; set; }
        [ForeignKey("MentoriumStack")]
        public int MentoriumStackId { get; set; }
        public MentoriumStack MentoriumStack { get; set; }
    }
}