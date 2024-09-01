using Data_Access.Interfaces;
using Domain_Models;
using Microsoft.EntityFrameworkCore;

namespace Data_Access.Implementations
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly AcademyManagementDbContext _context;
        private readonly DbSet<T> table;
        public Repository(AcademyManagementDbContext context) 
        {
            _context = context;
            table = context.Set<T>();
        }

        public void Add(T entity)
        {
            table.Add(entity);
            
        }

        public void Delete(T entity) => DeleteById(entity.Id);

        public void DeleteById(int id)
        {
            var entityToDelete = GetById(id);
            if (entityToDelete != null)
            {
                table.Remove(entityToDelete);
            }
        }

        public List<T> GetAll()
        {
            return table.AsNoTracking().ToList();
        }

        public T GetById(int id)
        {
            return table.AsNoTracking().FirstOrDefault(x => x.Id.Equals(id));
        }

        public void Update(T entity)
        {
            table.Update(entity);
            _context.Entry(entity).State = EntityState.Modified;
        }
    }
}
