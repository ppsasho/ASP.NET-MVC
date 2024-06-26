using DataAccess.Interface;
using DomainModels;

namespace DataAccess.Implementation
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        protected PizzaAppDbContext _dbContext;
        public Repository(PizzaAppDbContext dbContext) 
        {
            _dbContext = dbContext;
        }
        public T GetById(int id)
        {
            var item = _dbContext.Set<T>().Where(x => x.Id == id).FirstOrDefault() ?? throw new Exception($"Entity with id {id} was not found!");

            return item;
        }

        public List<T> GetAll()
        {
            return _dbContext.Set<T>().ToList();
        }
        public void Add(T entity)
        {
            _dbContext.Add<T>(entity);
            _dbContext.SaveChanges();
        }
        public void DeleteById(int id)
        {
            Delete(GetById(id));
        }

        public void Delete(T entity)
        {
            _dbContext.Remove<T>(entity);
            _dbContext.SaveChanges();
        }
        public void Update(T entity)
        {
            _dbContext.Update<T>(entity);
            _dbContext.SaveChanges();
        }
    }
}
