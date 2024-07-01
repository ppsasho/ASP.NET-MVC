using Microsoft.EntityFrameworkCore;
using Models;
using Storage.Interfaces;

namespace Storage.Implementations
{
    public class Storage<T> : IStorage<T> where T : Base
    {
        protected VideoRentalDbContext _dbContext;
        public Storage(VideoRentalDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public List<T> GetAll()
        {
            return _dbContext.Set<T>().AsNoTracking().ToList();
        }

        public T GetById(int id)
        {
            var item = _dbContext.Set<T>().AsNoTracking().FirstOrDefault(x => x.Id == id) ?? throw new Exception($"Entity with id ({id}) was not found!");
            return item;
        }
        public void Add(T item)
        {
            _dbContext.Add(item);
            _dbContext.SaveChanges();
        }
        public void Update(T item)
        {
            _dbContext.Update(item);
            _dbContext.SaveChanges();
        }

        public void Delete(T item)
        {
            _dbContext.Remove(item);
            _dbContext.SaveChanges();
        }

        public void DeleteById(int id)
        {
            var item = GetById(id);
            Delete(item);
        }


    }
}
