using Domain_Models;

namespace Data_Access.Interfaces
{
    public interface IStudentRepository : IRepository<Student>
    {
        public Student GetDetailedStudentById(int id);
    }
}
