namespace Domain_Models
{
    public class Grade : BaseEntity
    {
        public int StudentId { get; set; }
        public int SubjectId { get; set; }
        public int GradeAmount { get; set; }
        public virtual Student Student { get; set; }
        public virtual Subject Subject { get; set; }
    }
}