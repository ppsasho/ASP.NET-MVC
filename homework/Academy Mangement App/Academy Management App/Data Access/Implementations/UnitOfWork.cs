using Data_Access.Interfaces;
using Domain_Models;

namespace Data_Access.Implementations
{
    public class UnitOfWork : IDisposable
    {
        private readonly AcademyManagementDbContext  _context;

        private IStudentRepository _studentRepository;
        private ISubjectRepository? _subjectRepository;
        private IGradeRepository? _gradeRepository;
        private IUserRepository? _userRepository;
        public UnitOfWork(
            AcademyManagementDbContext context,
            ISubjectRepository subjectRepository,
            IStudentRepository studentRepo,
            IGradeRepository gradeRepository,
            IUserRepository userRepository)
        {
            _context = context;
            _studentRepository = studentRepo;
            _subjectRepository = subjectRepository;
            _gradeRepository = gradeRepository;
            _userRepository = userRepository;
        }
        public void Save()
        {
            _context.SaveChanges();
        }
        private bool disposed = false;
        protected virtual void Dispose(bool disposing) 
        {
            if (!disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
