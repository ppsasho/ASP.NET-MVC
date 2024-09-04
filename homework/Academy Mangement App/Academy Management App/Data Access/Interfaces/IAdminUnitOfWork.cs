using Microsoft.EntityFrameworkCore;

namespace Data_Access.Interfaces
{
    public interface IAdminUnitOfWork : IDisposable
    {
        public void Save();
    }
}
