using Data_Access.Interfaces;
using Domain_Models;
using Microsoft.EntityFrameworkCore;

namespace Data_Access.Implementations
{
    public class StudentRepository : Repository<Student>, IStudentRepository
    {
        private readonly AcademyManagementDbContext _context;
        private readonly DbSet<Student> _table;
        public StudentRepository(AcademyManagementDbContext context) : base(context)
        {
            _context = context;
            _table = _context.Set<Student>();
        }

        public Student GetDetailedStudentById(int id)
        {
            var student = _table.Include(x => x.Subjects)
                                .Include(x => x.Grades)
                                .FirstOrDefault(x => x.Id == id);
            return student;
        }
    }
}
