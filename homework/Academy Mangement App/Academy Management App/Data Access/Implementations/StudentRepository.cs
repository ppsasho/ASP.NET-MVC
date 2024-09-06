using Data_Access.Interfaces;
using Domain_Models;

namespace Data_Access.Implementations
{
    public class StudentRepository : Repository<Student>, IStudentRepository
    {
        public StudentRepository(AcademyManagementDbContext context) : base(context)
        {
        }
    }
}
