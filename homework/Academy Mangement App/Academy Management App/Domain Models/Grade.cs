using System.ComponentModel.DataAnnotations.Schema;

namespace Domain_Models
{
    public class Grade : BaseEntity
    {
        [ForeignKey(nameof(Student))]
        public int StudentId { get; set; }

        [ForeignKey(nameof(Subject))]
        public int SubjectId { get; set; }
        public int GradeAmount { get; set; }
        public virtual Student Student { get; set; }
        public virtual Subject Subject { get; set; }
    }
}