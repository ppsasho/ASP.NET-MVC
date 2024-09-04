using Data_Access.Interfaces;
using Domain_Models;

namespace Data_Access.Implementations
{
    public class AdminUnitOfWork : IDisposable , IAdminUnitOfWork
    {
        private readonly AcademyManagementDbContext  _context;

        private Repository<Student>? _studentRepository;
        private Repository<Subject>? _subjectRepository;
        private Repository<User>? _userRepository;
        public AdminUnitOfWork(AcademyManagementDbContext context)
        {
            _context = context;
        }
        public Repository<Student> StudentRepository
        {
            get
            {
                if (_studentRepository != null)
                {
                    return _studentRepository;
                }
                _studentRepository = new Repository<Student>(_context);
                return _studentRepository;
            }
        }
        public Repository<Subject> SubjectRepository
        {
            get
            {
                if (_subjectRepository != null)
                {
                    return _subjectRepository;
                }
                _subjectRepository = new Repository<Subject>(_context);
                return _subjectRepository;
            }
        }
        public Repository<User> UserRepository
        {
            get
            {
                if (_userRepository != null)
                {
                    return _userRepository;
                }
                _userRepository = new Repository<User>(_context);
                return _userRepository;
            }
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
