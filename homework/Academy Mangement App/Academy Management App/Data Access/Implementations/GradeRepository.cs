using Data_Access.Interfaces;
using Domain_Models;

namespace Data_Access.Implementations
{
    public class GradeRepository : Repository<Grade>, IGradeRepository
    {
        public GradeRepository(AcademyManagementDbContext context) : base(context)
        {
        }
    }
}
