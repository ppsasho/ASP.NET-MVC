using Domain_Models;

namespace Repository.Interfaces
{
    public interface IRepository<T> where T : BaseEntity
    {
        public List<T> GetAll();
        public T GetById(int id);
        public void Add(T entity);
        public void Update(T entity);
        public void Delete(T entity);


    }
}
