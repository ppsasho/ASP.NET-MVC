using System;

namespace Data_Access.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IStudentRepository StudentRepository { get; }
        ISubjectRepository SubjectRepository { get; }
        IGradeRepository GradeRepository { get; }
        IUserRepository UserRepository { get; }

        void Save();
    }
}
