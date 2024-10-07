using Data_Access.Interfaces;
using Domain_Models;

namespace Data_Access.Implementations
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AcademyManagementDbContext  _context;

        public IStudentRepository StudentRepository { get; }
        public ISubjectRepository SubjectRepository { get; }
        public IGradeRepository GradeRepository { get; }
        public IUserRepository UserRepository { get; }
        public UnitOfWork(
            AcademyManagementDbContext context,
            ISubjectRepository subjectRepository,
            IStudentRepository studentRepo,
            IGradeRepository gradeRepository,
            IUserRepository userRepository)
        {
            _context = context;
            StudentRepository = studentRepo;
            SubjectRepository = subjectRepository;
            GradeRepository = gradeRepository;
            UserRepository = userRepository;
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
