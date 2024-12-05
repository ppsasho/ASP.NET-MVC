using Data_Access.Interfaces;
using Domain_Models;
using Services.Interfaces;

namespace Services.Implementations
{
    public class StudentService : IStudentService
    {
        private readonly IUnitOfWork _unitOfWork;
        public StudentService(IUnitOfWork unitOfWork) 
        {
            _unitOfWork = unitOfWork;
        }

        public List<Subject> GetStudentSubjects(int studentId)
        {
            var subjects = new List<Subject>();

            var student = _unitOfWork.StudentRepository.GetDetailedStudentById(studentId);

            if (student != null)
                return student.Subjects;

            return subjects;
        }

        public List<Grade> GetStudentGradesBySubjectId(int studentId, int subjectId)
        {
            var grades = new List<Grade>();

            var subject = _unitOfWork.SubjectRepository.GetById(subjectId);
            var student = _unitOfWork.StudentRepository.GetDetailedStudentById(studentId);

            if (subject != null && student != null)
            {
                var subjectGrades = student.Grades.Where(x => x.SubjectId == subjectId).ToList();
                return subjectGrades;
            }

            return grades;
        }

        public List<Grade> GetStudentGrades(int studentId)
        {
            var grades = new List<Grade>();

            var student = _unitOfWork.StudentRepository.GetDetailedStudentById(studentId);

            if (student != null)
                return student.Grades;

            return grades;
        }

    }
}
