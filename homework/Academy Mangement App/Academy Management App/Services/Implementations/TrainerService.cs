using Data_Access.Interfaces;
using Domain_Models;
using Services.Interfaces;

namespace Services.Implementations
{
    public class TrainerService : ITrainerService
    {
        private readonly IUnitOfWork _unitOfWork;
        public TrainerService(IUnitOfWork unitOfWork) 
        {
            _unitOfWork = unitOfWork;
        }

        public List<Student> GetStudents(int trainerId) 
        {
            var students = new List<Student>();
            var trainer = _unitOfWork.UserRepository.GetById(trainerId);
            if (trainer == null)
            {
                //var trainersStudents = _unitOfWork.StudentRepository.GetAll().Where(x => x.Subjects.Any(x => x.SubjectName ==);
            }
            return students;
        }

    }
}
