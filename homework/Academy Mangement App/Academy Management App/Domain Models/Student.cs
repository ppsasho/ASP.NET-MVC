using System.Security.Cryptography.X509Certificates;

namespace Domain_Models
{
    public class Student : User
    {
        public string Name { get; set; }
        public virtual List<Subject> Subjects { get; set; }
        public virtual List<Grade> Grades { get; set; }

    }
}
