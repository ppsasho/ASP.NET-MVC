namespace Domain_Models
{
    public class Subject : BaseEntity
    {
        public string SubjectName { get; set; }
        public virtual List<Student> StudentsEnrolled { get; set; }
    }
}