namespace Domain_Models
{
    public class Grade : BaseEntity
    {
        public Student Student { get; set; }
        public Subject Subject { get; set; }
        public int GradeAmount { get; set; }
    }
}