using Data_Access.Interfaces;
using Domain_Models;

namespace Data_Access.Implementations
{
    public class SubjectRepository : Repository<Subject>, ISubjectRepository
    {
        public SubjectRepository(AcademyManagementDbContext context) : base(context)
        {
        }
    }
}
